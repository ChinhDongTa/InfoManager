namespace InfoManager.ApiClient.Interfaces;

public interface ICropHealthService
{
    Task<ApiResult<CropHealthDto?>> GetCropHealthByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateCropHealthAsync(string id, UpdateCropHealthRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteCropHealthAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CropHealthSummaryDto>>> GetCropHealthsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateCropHealthAsync(CreateCropHealthRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CropHealthSummaryDto>>> SearchCropHealthsAsync(SearchCropHealthsRequest request, CancellationToken ct = default);
}
