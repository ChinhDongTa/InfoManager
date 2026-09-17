namespace InfoManager.ApiClient.Services;

internal class FertilizerService(IFertilizerApi api) : IFertilizerService
{
    public async Task<ApiResult<string>> CreateFertilizerAsync(CreateFertilizerRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFertilizerAsync(request, ct));

    public async Task<ApiResult> DeleteFertilizerAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFertilizerAsync(id, ct));

    public async Task<ApiResult<FertilizerDto?>> GetFertilizerByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizerByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FertilizerSummaryDto>>> GetFertilizersAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizersAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FertilizerSummaryDto>>> SearchFertilizersAsync(SearchFertilizersRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFertilizersAsync(request.Term,
                                                                             request.FertilizerType,
                                                                             request.IsActive,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFertilizerAsync(string id, UpdateFertilizerRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFertilizerAsync(id, request, ct));
}
