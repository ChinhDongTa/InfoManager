namespace InfoManager.ApiClient.Services;

public class CropHealthService(ICropHealthApi api) : ICropHealthService
{
    public async Task<ApiResult<string>> CreateCropHealthAsync(CreateCropHealthRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropHealthAsync(request, ct));

    public async Task<ApiResult> DeleteCropHealthAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteCropHealthAsync(id, ct));

    public async Task<ApiResult<CropHealthDto?>> GetCropHealthByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropHealthByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CropHealthSummaryDto>>> GetCropHealthsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropHealthsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CropHealthSummaryDto>>> SearchCropHealthsAsync(SearchCropHealthsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchCropHealthsAsync(request.Term,
                                                                             request.CropPlantingId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateCropHealthAsync(string id, UpdateCropHealthRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateCropHealthAsync(id, request, ct));
}
