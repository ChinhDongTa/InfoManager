namespace InfoManager.ApiClient.Interfaces;

public interface IHarvestPlanService
{
    Task<ApiResult<HarvestPlanDto?>> GetHarvestPlanByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateHarvestPlanAsync(string id, UpdateHarvestPlanRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteHarvestPlanAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HarvestPlanSummaryDto>>> GetHarvestPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateHarvestPlanAsync(CreateHarvestPlanRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HarvestPlanSummaryDto>>> SearchHarvestPlansAsync(SearchHarvestPlansRequest request, CancellationToken ct = default);
}
