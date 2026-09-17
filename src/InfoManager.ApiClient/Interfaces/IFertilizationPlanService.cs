namespace InfoManager.ApiClient.Interfaces;

public interface IFertilizationPlanService
{
    Task<ApiResult<FertilizationPlanDto?>> GetFertilizationPlanByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFertilizationPlanAsync(string id, UpdateFertilizationPlanRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFertilizationPlanAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizationPlanSummaryDto>>> GetFertilizationPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFertilizationPlanAsync(CreateFertilizationPlanRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizationPlanSummaryDto>>> SearchFertilizationPlansAsync(SearchFertilizationPlansRequest request, CancellationToken ct = default);
}
