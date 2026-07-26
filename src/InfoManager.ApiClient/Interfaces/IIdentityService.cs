using InfoManager.ApiClient.Models;
using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ApiClient.Interfaces;

public interface IIdentityService
{
    Task<ApiResult<UserDto?>> GetUserByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteUserAsync(string id, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateUserAsync(string id, UpdateUserDto dto, CancellationToken ct = default);
    Task<ApiResult<UserDetailDto?>> GetUserDetailsByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<UserDto?>>> SearchUserByEmailAsync(string email, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> RemoveFromRoleAsync(RoleActionDto request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> AddToRoleAsync(RoleActionDto request, CancellationToken ct = default);
    Task<ApiResult<string>> CreateRoleAsync(CreateRoleDto request, CancellationToken ct = default);
    Task<ApiResult<List<string>>> GetRoleNamesAsync(CancellationToken ct = default);
    Task<ApiResult<List<RoleDto>>> GetRolesAsync(CancellationToken ct = default);
}
