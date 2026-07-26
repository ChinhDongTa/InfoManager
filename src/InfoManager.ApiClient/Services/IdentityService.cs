using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ApiClient.Services;

public class IdentityService(IIdentityApi identityApi) : IIdentityService
{
    public async Task<ApiResult<MessageResponse>> AddToRoleAsync(RoleActionDto request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.AddToRoleAsync(request, ct));

    public async Task<ApiResult<string>> CreateRoleAsync(CreateRoleDto request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.CreateRoleAsync(request, ct));

    public async Task<ApiResult<MessageResponse>> DeleteUserAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.DeleteUserAsync(id, ct));

    public async Task<ApiResult<List<string>>> GetRoleNamesAsync(CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.GetRoleNamesAsync(ct));

    public async Task<ApiResult<List<RoleDto>>> GetRolesAsync(CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.GetRolesAsync(ct));

    public async Task<ApiResult<UserDto?>> GetUserByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.GetUserByIdAsync(id, ct));

    public async Task<ApiResult<UserDetailDto?>> GetUserDetailsByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.GetUserDetailsByIdAsync(id, ct));

    public async Task<ApiResult<MessageResponse>> RemoveFromRoleAsync(RoleActionDto request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.RemoveFromRoleAsync(request, ct));

    public async Task<ApiResult<List<UserDto?>>> SearchUserByEmailAsync(string email, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.SearchUserByEmailAsync(email, ct));

    public async Task<ApiResult<MessageResponse>> UpdateUserAsync(string id, UpdateUserDto dto, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await identityApi.UpdateUserAsync(id, dto, ct));
}