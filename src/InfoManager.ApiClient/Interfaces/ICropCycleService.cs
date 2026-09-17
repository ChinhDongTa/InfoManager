namespace InfoManager.ApiClient.Interfaces;

public interface ICropCycleService
{
    Task<ApiResult<CropCycleDto?>> GetCropCycleByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateCropCycleAsync(string id, UpdateCropCycleRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteCropCycleAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CropCycleSummaryDto>>> GetCropCyclesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateCropCycleAsync(CreateCropCycleRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CropCycleSummaryDto>>> SearchCropCyclesAsync(SearchCropCyclesRequest request, CancellationToken ct = default);
}
