
using InfoManager.Shared.Dtos.Auths;
using System.Security.Claims;

namespace InfoManager.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<string?>> GetUserNameAsync(string userId, CancellationToken ct = default);

    Task<Result<bool>> IsInRoleAsync(string userId, string role, CancellationToken ct = default);

    Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct = default);

    Task<Result<string>> CreateUserAsync(string userName, string password, CancellationToken ct = default);

    Task<Result> DeleteUserAsync(string userId, CancellationToken ct = default);

    Task<Result> CreateRoleAsync(string roleName, CancellationToken ct = default);

    Task<Result> UpdateUserInfoAsync(string userId, UpdateUserDto dto, CancellationToken ct = default);

    Task<Result> AddToRoleAsync(string userId, string role, CancellationToken ct = default);

    Task<Result<UserDto?>> GetUserDtoByIdAsync(string userId, CancellationToken ct = default);

    Task<Result<UserDetailDto?>> GetUserDetailDtoByIdAsync(string userId, CancellationToken ct = default);

    Task<Result<UserDto?>> GetUserDtoByEmailAsync(string email, CancellationToken ct = default);

    Task<Result<List<string>>> GetRoleNamesAsync(CancellationToken ct = default);

    Task<Result<IEnumerable<RoleDto>>> GetRolesAsync(CancellationToken ct = default);

    Task<Result<UserDto?>> AuthenticateAsync(string email, string password, CancellationToken ct = default);

    string GenerateAccessToken(UserDto user, int expiresInMinutes = 15);

    string GenerateRefreshToken(UserDto user, int expiresInDays = 7);

    Task<Result<IEnumerable<UserDto>>> SearchAsync(string email, CancellationToken ct = default);

    ClaimsPrincipal? ValidateToken(string token);

    Task<Result> RemoveFromRoleAsync(string userId, string role, CancellationToken ct = default);
}