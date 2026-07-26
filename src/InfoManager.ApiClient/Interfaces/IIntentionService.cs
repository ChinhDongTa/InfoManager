using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.ApiClient.Interfaces;

public interface IIntentionService
{
    Task<ApiResult<PaginatedList<IntentionSummaryDto>>> GetIntentionsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default);
    Task<ApiResult<IntentionDto?>> GetIntentionByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<IntentionSummaryDto>>> GetTopIntentionsAsync(int top = 5, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<IntentionSummaryDto>>> SearchIntentionsAsync(SearchIntentionRequest request, CancellationToken ct = default);
    Task<ApiResult<string>> CreateIntentionAsync(CreateIntentionRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateIntentionAsync(string id, UpdateIntentionRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteIntentionAsync(string id, CancellationToken ct = default);
}