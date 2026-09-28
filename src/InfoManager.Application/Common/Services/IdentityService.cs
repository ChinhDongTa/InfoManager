using InfoManager.Shared.Dtos.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InfoManager.Application.Common.Services;

public class IdentityService(UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             SignInManager<ApplicationUser> signInManager,
                             IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
                             IAuthorizationService authorizationService,
                             IConfiguration configuration,
                             IApplicationDbContext dbContext,
                             ILogger<IdentityService> logger) : IIdentityService
{
    // Lazy so a cookie-only host can construct this service without a JWT secret.
    // GenerateAccessToken / ValidateToken still require Jwt:SecretKey for WASM and mobile.
    private SymmetricSecurityKey Key => new(Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]
        ?? throw new InvalidOperationException("Jwt:SecretKey not configured")));

    public async Task<Result> AddToRoleAsync(RoleActionDto dto, CancellationToken ct = default)
    {
        if (!await roleManager.RoleExistsAsync(dto.Role))
        {
            return Result.NotFound(ErrorHelpers.GetErrorNotExists(dto.Role));
        }
        var user = await userManager.FindByIdAsync(dto.UserId);
        if (user == null)
        {
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        var result = await userManager.AddToRoleAsync(user, dto.Role);
        return result.Succeeded
            ? Result.Success(ResultStatus.Created)
            : Result.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Create, dto.Role));
    }

    public async Task<Result<UserDto?>> AuthenticateAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

        var userDto = await GetUserDtoByEmailUsingQueryAsync(request.Email, ct);
        if (userDto == null)
        {
            return Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        logger.LogInformation("User authenticated (login) successfully: {UserId}", user.Id);
        return Result<UserDto?>.Success(userDto);
    }

    public async Task<Result<UserDto?>> SignInWithCookieAsync(LoginRequest request, bool rememberMe, CancellationToken ct = default)
    {
        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, rememberMe, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            logger.LogInformation("Cookie sign-in succeeded for {Email}", request.Email);
            return await GetUserDtoByEmailAsync(request.Email, ct);
        }

        if (result.RequiresTwoFactor)
            return Result<UserDto?>.Error("cookie:2fa");
        if (result.IsLockedOut)
            return Result<UserDto?>.Error("cookie:locked");
        if (result.IsNotAllowed)
            return Result<UserDto?>.Error("cookie:not-allowed");

        return Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
    }

    public async Task<Result> SignOutCookieAsync()
    {
        await signInManager.SignOutAsync();
        logger.LogInformation("Cookie sign-out completed");
        return Result.Success(ResultStatus.NoContent);
    }

    public async Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return Result<bool>.Error(ErrorHelpers.GetErrorNotFound("User"));

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);
        var result = await authorizationService.AuthorizeAsync(principal, policyName);
        return Result<bool>.Success(result.Succeeded);
    }

    public async Task<Result> CreateRoleAsync(string roleName, CancellationToken ct = default)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var identityResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            return identityResult.Succeeded
                ? Result.Success(ResultStatus.Created)
                : Result.Error(GetIdentityErrors(identityResult).ToArray());
        }
        return Result.Error(ErrorHelpers.GetErrorAlreadyExists(roleName));
    }

    public async Task<Result<string>> CreateUserAsync(LoginRequest request, CancellationToken ct = default)
    {
        var existingUser = await userManager.FindByNameAsync(request.Email);
        if (existingUser != null)
            return Result<string>.Error(ErrorHelpers.GetErrorAlreadyExists(request.Email));

        var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            logger.LogInformation("User created successfully: {UserId}", user.Id);
            await AddToRoleAsync(new RoleActionDto(user.Id, RoleConstants.FamilyMember), ct);
            return Result<string>.Success(user.Id, "T\u1ea1o User th\u00e0nh c\u00f4ng !");
        }
        return Result<string>.Error([.. GetIdentityErrors(result)]);
    }

    public async Task<Result> DeleteUserAsync(string userId, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        var result = await userManager.DeleteAsync(user);
        return result.Succeeded ? Result.Success(ResultStatus.NoContent) : Result.Error(GetIdentityErrors(result).ToArray());
    }

    public string GenerateAccessToken(UserDto user, int expiresInMinutes = 15)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.UserNameOrEmail),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        foreach (var role in user.Roles ?? [])
            claims.Add(new Claim(ClaimTypes.Role, role));

        var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiresInMinutes),
            SigningCredentials = credentials
        };
        return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
    }

    public string GenerateRefreshToken(UserDto user, int expiresInDays = 7)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(expiresInDays),
            SigningCredentials = credentials
        };
        return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
    }

    public async Task<Result<List<string>>> GetRoleNamesAsync(CancellationToken ct = default)
    {
        var list = await roleManager.Roles.Where(r => r.Name != null).Select(r => r.Name!).ToListAsync(ct);
        return Result<List<string>>.Success(list);
    }

    public async Task<Result<IEnumerable<RoleDto>>> GetRolesAsync(CancellationToken ct = default)
        => Result<IEnumerable<RoleDto>>.Success((await roleManager.Roles.Select(x => new RoleDto(x.Id, x.Name!)).ToListAsync(ct)).AsEnumerable());

    public async Task<Result<UserDetailDto?>> GetUserDetailDtoByIdAsync(string userId, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return Result<UserDetailDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        var roles = await userManager.GetRolesAsync(user);
        return Result<UserDetailDto?>.Success(new UserDetailDto
        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            Roles = roles.ToList(),
            UserNameOrEmail = user.UserName
        });
    }

    public async Task<Result<UserDto?>> GetUserDtoByEmailAsync(string email, CancellationToken ct = default)
    {
        var user = await GetUserDtoByEmailUsingQueryAsync(email, ct);
        return user == null ? Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User")) : Result<UserDto?>.Success(user);
    }

    public async Task<Result<UserDto?>> GetUserDtoByIdAsync(string userId, CancellationToken ct = default)
    {
        var user = await dbContext.SqlQueryRaw<UserDto>($"""
            SELECT u.\"Id\", COALESCE(u.\"UserName\", '') AS \"UserNameOrEmail\", u.\"PhoneNumber\",
                   COALESCE(ARRAY_AGG(r.\"Name\") FILTER (WHERE r.\"Name\" IS NOT NULL), ARRAY[]::text[]) AS \"Roles\"
            FROM \"AspNetUsers\" u
            LEFT JOIN \"AspNetUserRoles\" ur ON u.\"Id\" = ur.\"UserId\"
            LEFT JOIN \"AspNetRoles\" r ON ur.\"RoleId\" = r.\"Id\"
            WHERE u.\"Id\" ='{userId}'
            GROUP BY u.\"Id\", u.\"UserName\", u.\"Email\", u.\"PhoneNumber\"
            ORDER BY u.\"UserName\"
            Limit 1
            """).FirstOrDefaultAsync(ct);
        return user == null ? Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User")) : Result<UserDto?>.Success(user);
    }

    public async Task<Result<string?>> GetUserNameAsync(string userId, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return Result<string?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        return Result<string?>.Success(user.UserName!);
    }

    public async Task<Result<bool>> IsInRoleAsync(RoleActionDto dto, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(dto.UserId);
        if (user == null)
            return Result<bool>.Error(ErrorHelpers.GetErrorNotFound("User"));
        return Result<bool>.Success(await userManager.IsInRoleAsync(user, dto.Role));
    }

    public async Task<Result> RemoveFromRoleAsync(RoleActionDto dto, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(dto.UserId);
        if (user == null)
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        var result = await userManager.RemoveFromRoleAsync(user, dto.Role);
        return result.Succeeded ? Result.Success(ResultStatus.NoContent) : Result.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Delete, dto.Role));
    }

    public async Task<Result<IEnumerable<UserDto>>> SearchAsync(string emailOrRole, CancellationToken ct = default)
    {
        var pattern = $"%{emailOrRole}%";
        var results = await dbContext.SqlQueryRaw<UserDto>($"""
                 SELECT u.\"Id\", COALESCE(u.\"UserName\", '') AS \"UserNameOrEmail\", u.\"PhoneNumber\",
                        COALESCE(ARRAY_AGG(r.\"Name\") FILTER (WHERE r.\"Name\" IS NOT NULL), ARRAY[]::text[]) AS \"Roles\"
                 FROM \"AspNetUsers\" u
                 LEFT JOIN \"AspNetUserRoles\" ur ON u.\"Id\" = ur.\"UserId\"
                 LEFT JOIN \"AspNetRoles\" r ON ur.\"RoleId\" = r.\"Id\"
                 WHERE u.\"Email\" ILIKE '{pattern}' OR u.\"UserName\" ILIKE '{pattern}' OR r.\"Name\" ILIKE '{pattern}'
                 GROUP BY u.\"Id\", u.\"UserName\", u.\"Email\", u.\"PhoneNumber\"
                 ORDER BY u.\"UserName\"
                 """).ToListAsync(ct);
        return Result<IEnumerable<UserDto>>.Success(results);
    }

    public async Task<Result> UpdateUserInfoAsync(string userId, UpdateUserDto dto, CancellationToken ct = default)
    {
        if (userId != dto.UserId)
            return Result.Error(ErrorHelpers.GetErrorInvalid("userId"));
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Result.Error(ErrorHelpers.GetErrorNotFound("user"));
        var result = await userManager.UpdateAsync(user);
        return result.Succeeded ? Result.Success(ResultStatus.NoContent) : Result.Error(GetIdentityErrors(result).ToArray());
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = Key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            return principal;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error validating token");
            return null;
        }
    }

    private static IEnumerable<string> GetIdentityErrors(IdentityResult identityResult)
        => identityResult.Errors.Select(x => x.Description);

    private async Task<UserDto?> GetUserDtoByEmailUsingQueryAsync(string email, CancellationToken ct)
    {
        var pattern = $"%{email}%";
        return await dbContext.SqlQueryRaw<UserDto>($"""
                SELECT u.\"Id\", COALESCE(u.\"UserName\", '') AS \"UserNameOrEmail\", u.\"PhoneNumber\",
                       COALESCE(ARRAY_AGG(r.\"Name\") FILTER (WHERE r.\"Name\" IS NOT NULL), ARRAY[]::text[]) AS \"Roles\"
                FROM \"AspNetUsers\" u
                LEFT JOIN \"AspNetUserRoles\" ur ON u.\"Id\" = ur.\"UserId\"
                LEFT JOIN \"AspNetRoles\" r ON ur.\"RoleId\" = r.\"Id\"
                WHERE u.\"Email\" ILIKE '{pattern}' OR u.\"UserName\" ILIKE '{pattern}'
                GROUP BY u.\"Id\", u.\"UserName\", u.\"Email\", u.\"PhoneNumber\"
                ORDER BY u.\"UserName\"
                LIMIT 1
                """).FirstOrDefaultAsync(ct);
    }

    public async Task<Result> UpdateRoleAsync(string id, UpdateRoleDto request, CancellationToken ct = default)
    {
        var role = await roleManager.FindByIdAsync(id);
        if (role is null)
            return Result.Error(ErrorHelpers.GetErrorNotFound("Role"));
        role.Name = request.Name;
        var result = await roleManager.UpdateAsync(role);
        return result.Succeeded ? Result.Success(ResultStatus.NoContent) : Result.Error(GetIdentityErrors(result).ToArray());
    }
}

internal class RoleConstants
{
    public const string FamilyAdmin = "familyadmin";
    public const string FamilyMember = "familymember";
    public const string Farmer = "farmer";
    public const string Admin = "admin";
}
