namespace InfoManager.ApiClient.Services;

internal class FertilizationPlanService(IFertilizationPlanApi api) : IFertilizationPlanService
{
    public async Task<ApiResult<string>> CreateFertilizationPlanAsync(CreateFertilizationPlanRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFertilizationPlanAsync(request, ct));

    public async Task<ApiResult> DeleteFertilizationPlanAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFertilizationPlanAsync(id, ct));

    public async Task<ApiResult<FertilizationPlanDto?>> GetFertilizationPlanByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizationPlanByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FertilizationPlanSummaryDto>>> GetFertilizationPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizationPlansAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FertilizationPlanSummaryDto>>> SearchFertilizationPlansAsync(SearchFertilizationPlansRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFertilizationPlansAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.FertilizerId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFertilizationPlanAsync(string id, UpdateFertilizationPlanRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFertilizationPlanAsync(id, request, ct));
}
