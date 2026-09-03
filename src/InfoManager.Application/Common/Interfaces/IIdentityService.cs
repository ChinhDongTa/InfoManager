
using InfoManager.Shared.Dtos.Auths;
using System.Security.Claims;

namespace InfoManager.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<string?>> GetUserNameAsync(string userId, CancellationToken ct = default);

    Task<Result<bool>> IsInRoleAsync(RoleActionDto dto, CancellationToken ct = default);

    Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct = default);

    Task<Result<string>> CreateUserAsync(LoginRequest request, CancellationToken ct = default);

    Task<Result> DeleteUserAsync(string userId, CancellationToken ct = default);

    Task<Result> CreateRoleAsync(string roleName, CancellationToken ct = default);

    Task<Result> UpdateUserInfoAsync(string userId, UpdateUserDto dto, CancellationToken ct = default);

    Task<Result> AddToRoleAsync(RoleActionDto dto, CancellationToken ct = default);

    Task<Result<UserDto?>> GetUserDtoByIdAsync(string userId, CancellationToken ct = default);

    Task<Result<UserDetailDto?>> GetUserDetailDtoByIdAsync(string userId, CancellationToken ct = default);

    Task<Result<UserDto?>> GetUserDtoByEmailAsync(string email, CancellationToken ct = default);

    Task<Result<List<string>>> GetRoleNamesAsync(CancellationToken ct = default);

    Task<Result<IEnumerable<RoleDto>>> GetRolesAsync(CancellationToken ct = default);

    Task<Result<UserDto?>> AuthenticateAsync(LoginRequest request, CancellationToken ct = default);

    string GenerateAccessToken(UserDto user, int expiresInMinutes = 15);

    string GenerateRefreshToken(UserDto user, int expiresInDays = 7);

    Task<Result<IEnumerable<UserDto>>> SearchAsync(string email, CancellationToken ct = default);

    ClaimsPrincipal? ValidateToken(string token);

    Task<Result> RemoveFromRoleAsync(RoleActionDto dto, CancellationToken ct = default);

    Task<Result> UpdateRoleAsync(string id, UpdateRoleDto request, CancellationToken ct);
}