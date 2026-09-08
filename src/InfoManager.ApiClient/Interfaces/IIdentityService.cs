using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ApiClient.Interfaces;

public interface IIdentityService
{
    Task<ApiResult<UserDto?>> GetUserByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> DeleteUserAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateUserAsync(string id, UpdateUserDto dto, CancellationToken ct = default);
    Task<ApiResult<UserDetailDto?>> GetUserDetailsByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<UserDto>>> SearchUserByEmailOrRoleAsync(string emailOrRole, CancellationToken ct = default);
    Task<ApiResult> RemoveFromRoleAsync(RoleActionDto request, CancellationToken ct = default);
    Task<ApiResult> AddToRoleAsync(RoleActionDto request, CancellationToken ct = default);
    Task<ApiResult<string>> CreateRoleAsync(CreateRoleDto request, CancellationToken ct = default);
    Task<ApiResult<List<string>>> GetRoleNamesAsync(CancellationToken ct = default);
    Task<ApiResult<List<RoleDto>>> GetRolesAsync(CancellationToken ct = default);
    Task<ApiResult> UpdateRoleAsync(string id, UpdateRoleDto request, CancellationToken ct = default);
}