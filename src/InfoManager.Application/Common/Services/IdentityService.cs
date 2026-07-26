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

public class IdentityService( UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
    IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService, IConfiguration configuration, IApplicationDbContext dbContext) : IIdentityService
{
    private readonly SymmetricSecurityKey _key = new
       (Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("Jwt:SecretKey not configured")));

    public async Task<Result> AddToRoleAsync(string userId, string role, CancellationToken ct = default)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            return Result.NotFound(ErrorHelpers.GetErrorNotExists(role));
        }
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        var result = await userManager.AddToRoleAsync(user, role);
        return result.Succeeded
            ? Result.Success(ResultStatus.Created)
            : Result.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Create, role));
        
    }

    public async Task<Result<UserDto?>> AuthenticateAsync(string email, string password, CancellationToken ct = default)
    {
        // ✅ Optimized: Minimal DB reads
        // Query 1: Get user for password verification (must use UserManager for security)
        var user = await userManager.FindByEmailAsync(email);
        if (user == null || !await userManager.CheckPasswordAsync(user, password))
        {
            return Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

        // Query 2: Get full UserDTO with roles (happens only after password verification passes)
        var userDto = await GetUserDtoByEmailUsingQueryAsync(email, ct);
        if (userDto == null)
        {
            return Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

        return Result<UserDto?>.Success(userDto);
    }

    public async Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return Result<bool>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

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

    public async Task<Result<string>> CreateUserAsync(string userName, string password, CancellationToken ct = default)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            return Result<string>.Success(user.Id);
        }

        return Result<string>.Error(GetIdentityErrors(result).ToArray());

    }

    public async Task<Result> DeleteUserAsync(string userId, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

        var result = await userManager.DeleteAsync(user);
        return result.Succeeded ? Result.Success(ResultStatus.NoContent) : Result.Error(GetIdentityErrors(result).ToArray());

    }

    public string GenerateAccessToken(UserDto user, int expiresInMinutes = 15)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Email, user.UserNameOrEmail),
            new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        };

        // ✅ Add roles
        foreach (var role in user.Roles ?? [])
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
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
            new (ClaimTypes.NameIdentifier, user.Id),
            new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        };

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
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
        var list = await roleManager.Roles
        .Where(r => r.Name != null)
        .Select(r => r.Name!)
        .ToListAsync(ct);

        return Result<List<string>>.Success(list);
    }

    public async Task<Result<IEnumerable<RoleDto>>> GetRolesAsync(CancellationToken ct = default) 
        => Result<IEnumerable<RoleDto>>.Success ((await roleManager.Roles.Select(x => new RoleDto(x.Id, x.Name!)).ToListAsync(ct)).AsEnumerable());

    public async Task<Result<UserDetailDto?>> GetUserDetailDtoByIdAsync(string userId, CancellationToken ct = default)
    {
        // ✅ Optimized N+1 prevention:
        // This method uses UserManager (2 queries: FindByIdAsync + GetRolesAsync)
        // For better performance with large datasets, consider using GetUserDetailDtoByIdUsingQueryAsync
        // Trade-off: UserManager provides security features, direct EF query is faster

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result<UserDetailDto?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }

        // Get roles efficiently (UserManager.GetRolesAsync is reasonably optimized)
        var roles = await userManager.GetRolesAsync(user);

        return Result<UserDetailDto?>.Success(new UserDetailDto
        {
            FullName = user.UserName,
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            TelegramId = user.TelegramId,
            Roles = roles,
            UserNameOrEmail = user.UserName
        });
    }

    public async Task<Result<UserDto?>> GetUserDtoByEmailAsync(string email, CancellationToken ct = default)
    {
        var user = await GetUserDtoByEmailUsingQueryAsync(email, ct);
        return user == null
            ? Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"))
            : Result<UserDto?>.Success(user);
    }

    public async Task<Result<UserDto?>> GetUserDtoByIdAsync(string userId, CancellationToken ct = default)
    {
        var user = await dbContext.SqlQueryRaw<UserDto>($"""
            SELECT 
                u."Id",
                COALESCE(u."UserName", '') AS "UserNameOrEmail",
                u."PhoneNumber",
                COALESCE(
                    ARRAY_AGG(r."Name") FILTER (WHERE r."Name" IS NOT NULL),
                    ARRAY[]::text[]
                ) AS "Roles"
            FROM 
                "AspNetUsers" u
            LEFT JOIN 
                "AspNetUserRoles" ur ON u."Id" = ur."UserId"
            LEFT JOIN 
                "AspNetRoles" r ON ur."RoleId" = r."Id"
            WHERE u."Id" ='{userId}'
            GROUP BY 
                u."Id", u."UserName", u."Email", u."PhoneNumber"
            ORDER BY 
                u."UserName"
            Limit 1
            """).FirstOrDefaultAsync(ct);
        //return results;
        //var user = await userManager.FindByIdAsync(userId);
        return user == null
            ? Result<UserDto?>.Error(ErrorHelpers.GetErrorNotFound("User"))
            : Result<UserDto?>.Success(user);
    }

    public async Task<Result<string?>> GetUserNameAsync(string userId, CancellationToken ct = default)
    {
        var user = (await userManager.FindByIdAsync(userId));
        if (user == null)
        {
            return Result<string?>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        return Result<string?>.Success(user.UserName!);
    }

    public async Task<Result<bool>> IsInRoleAsync(string userId, string role, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result<bool>.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        var yes = await userManager.IsInRoleAsync(user, role);
        return Result<bool>.Success(yes);
    }

    public async Task<Result> RemoveFromRoleAsync(string userId, string role, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result.Error(ErrorHelpers.GetErrorNotFound("User"));
        }
        var result = await userManager.RemoveFromRoleAsync(user, role);
        return result.Succeeded
            ? Result.Success(ResultStatus.NoContent)
            : Result.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Delete, role));
    }

    public async Task<Result<IEnumerable<UserDto>>> SearchAsync(string email, CancellationToken ct = default)
    {
        var pattern = $"%{email}%";

        // Single SQL query with ARRAY_AGG to fetch users + roles in one roundtrip
        var results = await dbContext.SqlQueryRaw<UserDto>($"""
                 SELECT 
                     u."Id",
                     COALESCE(u."UserName", '') AS "UserNameOrEmail",
                     u."PhoneNumber",
                     COALESCE(
                         ARRAY_AGG(r."Name") FILTER (WHERE r."Name" IS NOT NULL),
                         ARRAY[]::text[]
                     ) AS "Roles"
                 FROM 
                     "AspNetUsers" u
                 LEFT JOIN 
                     "AspNetUserRoles" ur ON u."Id" = ur."UserId"
                 LEFT JOIN 
                     "AspNetRoles" r ON ur."RoleId" = r."Id"
                 WHERE u."Email" ILIKE '{pattern}' OR u."UserName" ILIKE '{pattern}'
                 GROUP BY 
                     u."Id", u."UserName", u."Email", u."PhoneNumber"
                 ORDER BY 
                     u."UserName"
                 """)
            .ToListAsync(ct);

        return Result<IEnumerable<UserDto>>.Success(results);
    }

    public async Task<Result> UpdateUserInfoAsync(string userId, UpdateUserDto dto, CancellationToken ct = default)
    {
        if (userId != dto.UserId)
            return Result.Error(ErrorHelpers.GetErrorInvalid("userId"));
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Result.Error(ErrorHelpers.GetErrorNotFound("user"));
        user.TelegramId = dto.TelegramId;
        user.FullName = dto.FullName;
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
                IssuerSigningKey = _key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            return principal;
        }
        catch
        {
            return null;
        }
    }
    private static IEnumerable<string> GetIdentityErrors(IdentityResult identityResult)
        => identityResult.Errors.Select(x => x.Description);
    /// <summary>
    /// Gets UserDTO with roles in a single optimized query using ARRAY_AGG
    /// This prevents N+1 queries that would occur if loading user and roles separately
    /// </summary>
    private async Task<UserDto?> GetUserDtoByEmailUsingQueryAsync(string email, CancellationToken ct)
    {
        var pattern = $"%{email}%";

        // ✅ Optimized: Single SQL query with ARRAY_AGG to fetch users + roles in one roundtrip
        var results = await dbContext.SqlQueryRaw<UserDto>($"""
                SELECT 
                    u."Id",
                    COALESCE(u."UserName", '') AS "UserNameOrEmail",
                    u."PhoneNumber",
                    COALESCE(
                        ARRAY_AGG(r."Name") FILTER (WHERE r."Name" IS NOT NULL),
                        ARRAY[]::text[]
                    ) AS "Roles"
                FROM 
                    "AspNetUsers" u
                LEFT JOIN 
                    "AspNetUserRoles" ur ON u."Id" = ur."UserId"
                LEFT JOIN 
                    "AspNetRoles" r ON ur."RoleId" = r."Id"
                WHERE u."Email" ILIKE '{pattern}' OR u."UserName" ILIKE '{pattern}'
                GROUP BY 
                    u."Id", u."UserName", u."Email", u."PhoneNumber"
                ORDER BY 
                    u."UserName"
                LIMIT 1
                """).FirstOrDefaultAsync(ct);
        return results;
    }
}
