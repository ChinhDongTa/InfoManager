using InfoManager.Shared.Dtos.UserProfiles;

namespace InfoManager.ApiClient.Api;

public interface IUserProfileApi
{
    [Get("/api/UserProfiles/{id}")]
    Task<ApiResponse<UserProfileDto?>> GetUserProfileByIdAsync(string id, CancellationToken ct = default);

    [Get("/api/UserProfiles")]
    Task<ApiResponse<PaginatedList<UserProfileDto>>> GetUserProfilesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    [Headers("Content-Type: application/json")]
    [Post("/api/UserProfiles")]
    Task<ApiResponse<string>> CreateUserProfileAsync([Body] CreateUserProfileRequest request, CancellationToken ct = default);

    [Headers("Content-Type: application/json")]
    [Put("/api/UserProfiles/{id}")]
    Task<IApiResponse> UpdateUserProfileAsync(string id, [Body] UpdateUserProfileRequest request, CancellationToken ct = default);

    [Delete("/api/UserProfiles/{id}")]
    Task<IApiResponse> DeleteUserProfileAsync(string id, CancellationToken ct = default);
}
