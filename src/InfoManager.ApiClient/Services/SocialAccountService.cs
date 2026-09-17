using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.ApiClient.Services;

internal class SocialAccountService(ISocialAccountApi api) : ISocialAccountService
{
    public async Task<ApiResult<string>> CreateSocialAccountAsync(CreateSocialAccountRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateSocialAccountAsync(request, ct));

    public async Task<ApiResult> DeleteSocialAccountAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteSocialAccountAsync(id, ct));

    public async Task<ApiResult<SocialAccountDto?>> GetSocialAccountByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetSocialAccountByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<SocialAccountDto>>> GetSocialAccountsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetSocialAccountsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult> UpdateSocialAccountAsync(string id, UpdateSocialAccountRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateSocialAccountAsync(id, request, ct));
}