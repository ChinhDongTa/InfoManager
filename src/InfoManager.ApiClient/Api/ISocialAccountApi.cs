using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.ApiClient.Api;

public interface ISocialAccountApi
{
    [Get("/api/SocialAccounts/{id}")]
    Task<ApiResponse<SocialAccountDto?>> GetSocialAccountByIdAsync(string id, CancellationToken ct = default);

    [Get("/api/SocialAccounts")]
    Task<ApiResponse<PaginatedList<SocialAccountDto>>> GetSocialAccountsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    [Headers("Content-Type: application/json")]
    [Post("/api/SocialAccounts")]
    Task<ApiResponse<string>> CreateSocialAccountAsync([Body] CreateSocialAccountRequest request, CancellationToken ct = default);

    [Headers("Content-Type: application/json")]
    [Put("/api/SocialAccounts/{id}")]
    Task<IApiResponse> UpdateSocialAccountAsync(string id, [Body] UpdateSocialAccountRequest request, CancellationToken ct = default);

    [Delete("/api/SocialAccounts/{id}")]
    Task<IApiResponse> DeleteSocialAccountAsync(string id, CancellationToken ct = default);
}