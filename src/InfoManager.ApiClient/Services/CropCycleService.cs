namespace InfoManager.ApiClient.Services;

internal class CropCycleService(ICropCycleApi api) : ICropCycleService
{
    public async Task<ApiResult<string>> CreateCropCycleAsync(CreateCropCycleRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropCycleAsync(request, ct));

    public async Task<ApiResult> DeleteCropCycleAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteCropCycleAsync(id, ct));

    public async Task<ApiResult<CropCycleDto?>> GetCropCycleByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropCycleByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CropCycleSummaryDto>>> GetCropCyclesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropCyclesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CropCycleSummaryDto>>> SearchCropCyclesAsync(SearchCropCyclesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchCropCyclesAsync(request.Term,
                                                                             request.StartYear,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateCropCycleAsync(string id, UpdateCropCycleRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateCropCycleAsync(id, request, ct));
}
