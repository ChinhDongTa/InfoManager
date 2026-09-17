namespace InfoManager.ApiClient.Services;

internal class PlantingPlanService(IPlantingPlanApi api) : IPlantingPlanService
{
    public async Task<ApiResult<string>> CreatePlantingPlanAsync(CreatePlantingPlanRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePlantingPlanAsync(request, ct));

    public async Task<ApiResult> DeletePlantingPlanAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePlantingPlanAsync(id, ct));

    public async Task<ApiResult<PlantingPlanDto?>> GetPlantingPlanByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPlantingPlanByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PlantingPlanSummaryDto>>> GetPlantingPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPlantingPlansAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PlantingPlanSummaryDto>>> SearchPlantingPlansAsync(SearchPlantingPlansRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPlantingPlansAsync(request.Term,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePlantingPlanAsync(string id, UpdatePlantingPlanRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePlantingPlanAsync(id, request, ct));
}
