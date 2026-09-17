namespace InfoManager.ApiClient.Interfaces;

public interface IPlantingPlanService
{
    Task<ApiResult<PlantingPlanDto?>> GetPlantingPlanByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePlantingPlanAsync(string id, UpdatePlantingPlanRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePlantingPlanAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PlantingPlanSummaryDto>>> GetPlantingPlansAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePlantingPlanAsync(CreatePlantingPlanRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PlantingPlanSummaryDto>>> SearchPlantingPlansAsync(SearchPlantingPlansRequest request, CancellationToken ct = default);
}
