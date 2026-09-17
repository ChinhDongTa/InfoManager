using InfoManager.Shared.Dtos.UserProfiles;

namespace InfoManager.ApiClient.Services;

internal class UserProfileService(IUserProfileApi api) : IUserProfileService
{
    public async Task<ApiResult<string>> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateUserProfileAsync(request, ct));

    public async Task<ApiResult> DeleteUserProfileAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteUserProfileAsync(id, ct));

    public async Task<ApiResult<UserProfileDto?>> GetUserProfileByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetUserProfileByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<UserProfileDto>>> GetUserProfilesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetUserProfilesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult> UpdateUserProfileAsync(string id, UpdateUserProfileRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateUserProfileAsync(id, request, ct));
}