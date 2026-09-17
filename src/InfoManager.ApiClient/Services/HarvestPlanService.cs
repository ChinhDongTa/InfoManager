namespace InfoManager.ApiClient.Services;

internal class HarvestPlanService(IHarvestPlanApi api) : IHarvestPlanService
{
    public async Task<ApiResult<string>> CreateHarvestPlanAsync(CreateHarvestPlanRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateHarvestPlanAsync(request, ct));

    public async Task<ApiResult> DeleteHarvestPlanAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteHarvestPlanAsync(id, ct));

    public async Task<ApiResult<HarvestPlanDto?>> GetHarvestPlanByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHarvestPlanByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<HarvestPlanSummaryDto>>> GetHarvestPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHarvestPlansAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<HarvestPlanSummaryDto>>> SearchHarvestPlansAsync(SearchHarvestPlansRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchHarvestPlansAsync(request.Term,
                                                                             request.ExpectedDate,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateHarvestPlanAsync(string id, UpdateHarvestPlanRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateHarvestPlanAsync(id, request, ct));
}
