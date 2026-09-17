namespace InfoManager.ApiClient.Services;

internal class FertilizerApplicationService(IFertilizerApplicationApi api) : IFertilizerApplicationService
{
    public async Task<ApiResult<string>> CreateFertilizerApplicationAsync(CreateFertilizerApplicationRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFertilizerApplicationAsync(request, ct));

    public async Task<ApiResult> DeleteFertilizerApplicationAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFertilizerApplicationAsync(id, ct));

    public async Task<ApiResult<FertilizerApplicationDto?>> GetFertilizerApplicationByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizerApplicationByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FertilizerApplicationSummaryDto>>> GetFertilizerApplicationsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFertilizerApplicationsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FertilizerApplicationSummaryDto>>> SearchFertilizerApplicationsAsync(SearchFertilizerApplicationsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFertilizerApplicationsAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.FertilizerId,
                                                                             request.CropPlantingId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFertilizerApplicationAsync(string id, UpdateFertilizerApplicationRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFertilizerApplicationAsync(id, request, ct));
}
