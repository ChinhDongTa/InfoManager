namespace InfoManager.ApiClient.Services;

internal class PesticideApplicationService(IPesticideApplicationApi api) : IPesticideApplicationService
{
    public async Task<ApiResult<string>> CreatePesticideApplicationAsync(CreatePesticideApplicationRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePesticideApplicationAsync(request, ct));

    public async Task<ApiResult> DeletePesticideApplicationAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePesticideApplicationAsync(id, ct));

    public async Task<ApiResult<PesticideApplicationDto?>> GetPesticideApplicationByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticideApplicationByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PesticideApplicationSummaryDto>>> GetPesticideApplicationsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticideApplicationsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PesticideApplicationSummaryDto>>> SearchPesticideApplicationsAsync(SearchPesticideApplicationsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPesticideApplicationsAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.PesticideId,
                                                                             request.CropPlantingId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePesticideApplicationAsync(string id, UpdatePesticideApplicationRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePesticideApplicationAsync(id, request, ct));
}
