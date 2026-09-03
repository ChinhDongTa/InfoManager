using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.ApiClient.Services;

public class PriceTrackingService(IPriceTrackingApi api) : IPriceTrackingService
{
    public async Task<ApiResult<string>> CreatePriceTrackingAsync(CreatePriceTrackingRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.CreatePriceTrackingAsync(request, ct));

    public async Task<ApiResult> DeletePriceTrackingAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeletePriceTrackingAsync(id, ct));

    public async Task<ApiResult<PriceTrackingDto?>> GetPriceTrackingByIdAsync(string id, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetPriceTrackingByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PriceTrackingSummaryDto>>> GetPriceTrackingsAsync(int pageNumber = 1,
                                                                                                int pageSize = 20,
                                                                                                CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetPriceTrackingsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<List<PriceTrackingSummaryDto>>> GetTopPriceTrackingsAsync(int top = 5, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetTopPriceTrackingsAsync(top, ct));

    public async Task<ApiResult<PaginatedList<PriceTrackingSummaryDto>>> SearchPriceTrackingsAsync(SearchPriceTrackingRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.SearchPriceTrackingsAsync(request.SearchTerm,
                                                                                    request.MinPrice,
                                                                                    request.MaxPrice,
                                                                                    request.SortBy,
                                                                                    request.Ascending,
                                                                                    request.PageNumber,
                                                                                    request.PageSize,
                                                                                    ct));

    public async Task<ApiResult> UpdatePriceTrackingAsync(string id, UpdatePriceTrackingRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.UpdatePriceTrackingAsync(id, request, ct));
}