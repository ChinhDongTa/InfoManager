using InfoManager.Enum;
using InfoManager.Helper;
using InfoManager.Shared.Dtos.Auths;
using InfoManager.Shared.Dtos.Common;
using InfoManager.Shared.Dtos.TokenBlacklists;
using System.Security.Claims;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing user identities, roles, and authentication.
/// </summary>
public class Identities : EndpointGroupBase
{
    public override string GroupName => "Identities";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        // User operations
        api.MapGet(GetUserByIdAsync, "users/{id}");
        api.MapGet(GetUserDetailsByIdAsync, "user-detail/{id}");
        api.MapGet(SearchUserByEmailAsync, pattern: "users/search/{email}");
        api.MapDelete(DeleteUserAsync, "users/{id}");
        api.MapPut(UpdateUserAsync, "users/{id}");

        // Role operations
        api.MapPost(RemoveFromRoleAsync, "remove-from-role");
        api.MapPost(AddToRoleAsync, "add-to-role");
        api.MapPost(CreateRoleAsync, "create-role");
        api.MapGet(GetRoleNamesAsync, "roleNames");
        api.MapGet(GetRolesAsync, "roles");

        // Session management
        api.MapPost(LogoutAsync, "logout");

        // Public endpoints (no authorization required)
        group.MapPost(LoginWithAsync, "login");
        group.MapPost(RegisterAsync, "register");
        group.MapPost(RefreshTokenAsync, "refresh");
    }
    // ==================== USER OPERATIONS ====================

    /// <summary>
    /// Gets user information by ID
    /// </summary>
    /// <response code="200">User found and returned</response>
    /// <response code="400">User not found or error occurred</response>
    public async Task<IResult> GetUserByIdAsync(string id, IIdentityService identityService, CancellationToken ct)
    {
        var result = await identityService.GetUserDtoByIdAsync(id.Trim(), ct);
        return result.Succeeded ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Not found");
    }

    /// <summary>
    /// Gets detailed user information by ID including roles and related data
    /// </summary>
    /// <response code="200">User details found and returned</response>
    /// <response code="400">User not found or error occurred</response>
    public async Task<IResult> GetUserDetailsByIdAsync(string id, IIdentityService identityService, CancellationToken ct)
    {
        var result = await identityService.GetUserDetailDtoByIdAsync(id, ct);
        return result.Succeeded ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Not found");
    }

    /// <summary>
    /// Searches for users by email address
    /// </summary>
    /// <param name="email">Email address to search for</param>
    /// <response code="200">Search completed, results returned</response>
    /// <response code="400">Invalid email or search error</response>
    public async Task<IResult> SearchUserByEmailAsync([FromRoute] string email, IIdentityService identityService, CancellationToken ct)
    {
        email = email?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(email))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("Email"));

        var result = await identityService.SearchAsync(email, ct);
        return result.Succeeded ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Search failed");
    }

    /// <summary>
    /// Deletes a user by ID
    /// </summary>
    /// <response code="204">User deleted successfully</response>
    /// <response code="400">Deletion failed</response>
    public async Task<IResult> DeleteUserAsync(string id, IIdentityService identityService, CancellationToken ct)
    {
        var result = await identityService.DeleteUserAsync(id, ct);
        return result.Succeeded ? TypedResults.NoContent() : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Delete failed");
    }

    /// <summary>
    /// Updates user information
    /// </summary>
    /// <response code="204">User updated successfully</response>
    /// <response code="400">Validation error or update failed</response>
    public async Task<IResult> UpdateUserAsync(string id, [FromBody] UpdateUserDto dto, IIdentityService identityService, CancellationToken ct)
    {
        if (id != dto.UserId)
            return TypedResults.BadRequest(ErrorHelpers.GetErrorMismatch("UserId"));

        var result = await identityService.UpdateUserInfoAsync(id, dto, ct);
        return result.Succeeded ? TypedResults.NoContent() : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Update failed");
    }

    // ==================== ROLE OPERATIONS ====================

    /// <summary>
    /// Removes a user from a role
    /// </summary>
    /// <response code="204">User removed from role successfully</response>
    /// <response code="400">Validation error or operation failed</response>
    public async Task<IResult> RemoveFromRoleAsync([FromBody] RoleActionDto request, IIdentityService identityService, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.UserId) || string.IsNullOrWhiteSpace(request.Role))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("UserId and Role"));

        var result = await identityService.RemoveFromRoleAsync(request.UserId.Trim(), request.Role.Trim(), ct);
        return result.Succeeded ? TypedResults.NoContent() : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Operation failed");
    }

    /// <summary>
    /// Adds a user to a role
    /// </summary>
    /// <response code="204">User added to role successfully</response>
    /// <response code="400">Validation error or operation failed</response>
    public async Task<IResult> AddToRoleAsync([FromBody] RoleActionDto request, IIdentityService identityService, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.UserId) || string.IsNullOrWhiteSpace(request.Role))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("UserId and Role"));

        var result = await identityService.AddToRoleAsync(request.UserId.Trim(), request.Role.Trim(), ct);
        return result.Succeeded ? TypedResults.NoContent() : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Operation failed");
    }

    /// <summary>
    /// Creates a new role
    /// </summary>
    /// <response code="201">Role created successfully</response>
    /// <response code="400">Validation error or creation failed</response>
    public async Task<IResult> CreateRoleAsync([FromBody] CreateRoleDto request, IIdentityService identityService, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Name))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("Role name"));

        var role = request.Name.Trim();
        var result = await identityService.CreateRoleAsync(role, ct);

        if (!result.Succeeded)
            return TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Create failed");

        var location = $"/{GroupName}/roles/";
        return TypedResults.Created(location);
    }

    /// <summary>
    /// Gets all role names
    /// </summary>
    /// <response code="200">List of role names</response>
    public async Task<IResult> GetRoleNamesAsync(IIdentityService identityService, CancellationToken ct)
    {
        var result = await identityService.GetRoleNamesAsync(ct);
        return result.Succeeded ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Query failed");
    }

    /// <summary>
    /// Gets all roles with details
    /// </summary>
    /// <response code="200">List of roles</response>
    public async Task<IResult> GetRolesAsync(IIdentityService identityService, CancellationToken ct)
    {
        var result = await identityService.GetRolesAsync(ct);
        return result.Succeeded ? TypedResults.Ok(result.Value) : TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Query failed");
    }

    // ==================== AUTHENTICATION ====================

    /// <summary>
    /// Authenticates a user and returns JWT tokens
    /// </summary>
    /// <response code="200">Login successful, tokens returned</response>
    /// <response code="400">Validation error (missing email/password)</response>
    /// <response code="401">Authentication failed (invalid credentials)</response>
    public async Task<IResult> LoginWithAsync(LoginRequest request, IIdentityService identityService, HttpContext httpContext, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("Email and password"));

        var result = await identityService.AuthenticateAsync(request.Email, request.Password, ct);
        if (result == null || result.Value == null)
            return TypedResults.Unauthorized();

        var accessToken = identityService.GenerateAccessToken(result.Value, expiresInMinutes: 15);
        var refreshToken = identityService.GenerateRefreshToken(result.Value, expiresInDays: 7);

        // Store refresh token in HTTP-only cookie (backup)
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        };
        httpContext.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

        // Return tokens in response body for Blazor WASM (stores in localStorage)
        return TypedResults.Ok(new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Email = result.Value.UserNameOrEmail,
            ExpiresIn = 900  // 15 minutes in seconds
        });
    }

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <response code="200">Registration successful</response>
    /// <response code="400">Validation error or registration failed</response>
    public async Task<IResult> RegisterAsync(LoginRequest request, IIdentityService identityService, CancellationToken ct)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("Email and password"));

        var result = await identityService.CreateUserAsync(request.Email, request.Password, ct);
        if (!result.Succeeded)
            return TypedResults.BadRequest(result.Errors?.FirstOrDefault() ?? "Registration failed");

        return TypedResults.Ok(new MessageResponse { Message = "Registration successful" });
    }

    /// <summary>
    /// Refreshes the access token using a valid refresh token
    /// </summary>
    /// <response code="200">Tokens refreshed successfully</response>
    /// <response code="400">Validation error (missing refresh token)</response>
    /// <response code="401">Invalid or expired refresh token</response>
    public async Task<IResult> RefreshTokenAsync([FromBody] RefreshRequest request, IIdentityService identityService, CancellationToken ct)
    {
        // Validate input
        if (request == null || string.IsNullOrWhiteSpace(request.RefreshToken))
            return TypedResults.BadRequest(ErrorHelpers.GetErrorRequired("Refresh token"));

        // Validate token structure and claims
        var principal = identityService.ValidateToken(request.RefreshToken);
        if (principal == null)
            return TypedResults.Unauthorized();

        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return TypedResults.Unauthorized();

        var result = await identityService.GetUserDtoByIdAsync(userId, ct);
        if (result == null || result.Value == null)
            return TypedResults.Unauthorized();

        var newAccessToken = identityService.GenerateAccessToken(result.Value, expiresInMinutes: 15);
        var newRefreshToken = identityService.GenerateRefreshToken(result.Value , expiresInDays: 7);

        // Return tokens in response body for Blazor WASM to save in localStorage
        return TypedResults.Ok(new TokenResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresIn = 900  // 15 minutes in seconds
        });
    }

    /// <summary>
    /// Logs out the user by blacklisting both access and refresh tokens
    /// </summary>
    /// <response code="200">Logout successful</response>
    /// <response code="401">Unauthorized - no valid token provided</response>
    public async Task<IResult> LogoutAsync(HttpContext httpContext, IIdentityService identityService, ITokenBlacklistService tokenBlacklistService, [FromBody] LogoutRequest? request, CancellationToken ct)
    {
        // Extract the access token from Authorization header
        var authHeader = httpContext.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return TypedResults.Unauthorized();

        var accessToken = authHeader["Bearer ".Length..].Trim();

        // Validate the access token and extract claims
        var principal = identityService.ValidateToken(accessToken);
        if (principal == null)
            return TypedResults.Unauthorized();

        // Extract required claims
        var accessJti = principal.FindFirst("jti")?.Value;
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var accessExpClaimStr = principal.FindFirst("exp")?.Value;

        if (string.IsNullOrEmpty(accessJti) || string.IsNullOrEmpty(userId))
            return TypedResults.Unauthorized();

        // Parse expiration time from access token exp claim (Unix timestamp)
        DateTimeOffset accessExpiresAt = DateTimeOffset.UtcNow.AddMinutes(15); // Default fallback
        if (long.TryParse(accessExpClaimStr, out var accessExpTimestamp))
        {
            accessExpiresAt = DateTimeOffset.FromUnixTimeSeconds(accessExpTimestamp);
        }

        // Blacklist access token
        var accessTokenDto = new CreateTokenBlacklistDto
        {
            Jti = accessJti,
            UserIdOfToken = userId,
            Reason = ReasonRevoke.Logout,
            Status = TokenStatus.Blacklisted,
            ExpiresAt = accessExpiresAt,
            TokenType = TokenType.Access
        };

        var accessBlacklistResult = await tokenBlacklistService.CreateAsync(accessTokenDto, ct);

        // Handle refresh token blacklisting
        var refreshToken = request?.RefreshToken ?? httpContext.Request.Cookies["refreshToken"];

        if (!string.IsNullOrEmpty(refreshToken))
        {
            // Validate and extract refresh token claims
            var refreshPrincipal = identityService.ValidateToken(refreshToken);
            if (refreshPrincipal != null)
            {
                var refreshJti = refreshPrincipal.FindFirst("jti")?.Value;
                var refreshExpClaimStr = refreshPrincipal.FindFirst("exp")?.Value;

                if (!string.IsNullOrEmpty(refreshJti))
                {
                    // Parse expiration time from refresh token exp claim
                    DateTimeOffset refreshExpiresAt = DateTimeOffset.UtcNow.AddDays(7); // Default fallback
                    if (long.TryParse(refreshExpClaimStr, out var refreshExpTimestamp))
                    {
                        refreshExpiresAt = DateTimeOffset.FromUnixTimeSeconds(refreshExpTimestamp);
                    }

                    // Blacklist refresh token
                    var refreshTokenDto = new CreateTokenBlacklistDto
                    {
                        Jti = refreshJti,
                        UserIdOfToken = userId,
                        Reason = ReasonRevoke.Logout,
                        Status = TokenStatus.Blacklisted,
                        ExpiresAt = refreshExpiresAt,
                        TokenType = TokenType.Refresh
                    };

                    await tokenBlacklistService.CreateAsync(refreshTokenDto, ct);
                }
            }
        }

        // Delete refresh token cookie
        httpContext.Response.Cookies.Delete("refreshToken");

        if (!accessBlacklistResult.Succeeded)
            return TypedResults.Ok(new MessageResponse { Message = ErrorHelpers.GetSuccessLoggedOut() + " (Token registration failed, but session cleared)" });

        return TypedResults.Ok(new MessageResponse { Message = ErrorHelpers.GetSuccessLoggedOut() });
    }
}
