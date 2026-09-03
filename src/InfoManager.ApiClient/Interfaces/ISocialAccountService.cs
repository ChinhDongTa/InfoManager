using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.ApiClient.Interfaces;

public interface ISocialAccountService
{
    Task<ApiResult<SocialAccountDto?>> GetSocialAccountByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<SocialAccountDto>>> GetSocialAccountsAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateSocialAccountAsync(CreateSocialAccountRequest request, CancellationToken ct = default);
    Task<ApiResult> UpdateSocialAccountAsync(string id, UpdateSocialAccountRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteSocialAccountAsync(string id, CancellationToken ct = default);
}
