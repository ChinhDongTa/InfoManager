using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.ApiClient.Services;

public class IntentionService(IIntentionApi api) : IIntentionService
{
    public  async Task<ApiResult<string>> CreateIntentionAsync(CreateIntentionRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateIntentionAsync(request, ct));
    }

    public  async Task<ApiResult<MessageResponse>> DeleteIntentionAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteIntentionAsync(id, ct));
    }

    public  async Task<ApiResult<IntentionDto?>> GetIntentionByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetIntentionByIdAsync(id, ct));
    }

    public  async Task<ApiResult<PaginatedList<IntentionSummaryDto>>> GetIntentionsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetIntentionsAsync(pageNumber, pageSize, ct));
    }

    public async Task<ApiResult<List<IntentionSummaryDto>>> GetTopIntentionsAsync(int top = 5, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetTopIntentionsAsync(top, ct));

    public async Task<ApiResult<PaginatedList<IntentionSummaryDto>>> SearchIntentionsAsync(SearchIntentionRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.SearchIntentionsAsync(request.SearchTerm,
                                                                                    request.CategoryId,
                                                                                    request.StartDate,
                                                                                    request.EndDate,
                                                                                    request.PageNumber,
                                                                                    request.PageSize,
                                                                                    ct));

    public async Task<ApiResult<MessageResponse>> UpdateIntentionAsync(string id, UpdateIntentionRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.UpdateIntentionAsync(id, request, ct));
}