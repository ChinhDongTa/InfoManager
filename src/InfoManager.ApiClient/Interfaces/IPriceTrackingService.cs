using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.ApiClient.Interfaces;

public interface IPriceTrackingService
{
    Task<ApiResult<PriceTrackingDto?>> GetPriceTrackingByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<PriceTrackingSummaryDto>>> GetPriceTrackingsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default);
    Task<ApiResult<List<PriceTrackingSummaryDto>>> GetTopPriceTrackingsAsync(int top = 5, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<PriceTrackingSummaryDto>>> SearchPriceTrackingsAsync(SearchPriceTrackingRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdatePriceTrackingAsync(string id, UpdatePriceTrackingRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeletePriceTrackingAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreatePriceTrackingAsync(CreatePriceTrackingRequest request, CancellationToken ct = default);
    
}
