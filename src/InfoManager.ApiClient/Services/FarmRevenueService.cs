namespace InfoManager.ApiClient.Services;

internal class FarmRevenueService(IFarmRevenueApi api) : IFarmRevenueService
{
    public async Task<ApiResult<string>> CreateFarmRevenueAsync(CreateFarmRevenueRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFarmRevenueAsync(request, ct));

    public async Task<ApiResult> DeleteFarmRevenueAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFarmRevenueAsync(id, ct));

    public async Task<ApiResult<FarmRevenueDto?>> GetFarmRevenueByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmRevenueByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FarmRevenueSummaryDto>>> GetFarmRevenuesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmRevenuesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FarmRevenueSummaryDto>>> SearchFarmRevenuesAsync(SearchFarmRevenuesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFarmRevenuesAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.CropPlantingId,
                                                                             request.HarvestId,
                                                                             request.SaleId,
                                                                             request.PaymentStatus,
                                                                             request.StartRevenueDate,
                                                                             request.EndRevenueDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFarmRevenueAsync(string id, UpdateFarmRevenueRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFarmRevenueAsync(id, request, ct));
}
