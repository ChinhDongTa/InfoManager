namespace InfoManager.ApiClient.Services;

internal class PesticideService(IPesticideApi api) : IPesticideService
{
    public async Task<ApiResult<string>> CreatePesticideAsync(CreatePesticideRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePesticideAsync(request, ct));

    public async Task<ApiResult> DeletePesticideAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePesticideAsync(id, ct));

    public async Task<ApiResult<PesticideDto?>> GetPesticideByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticideByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PesticideSummaryDto>>> GetPesticidesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticidesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PesticideSummaryDto>>> SearchPesticidesAsync(SearchPesticidesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPesticidesAsync(request.Term,
                                                                             request.PesticideType,
                                                                             request.IsActive,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePesticideAsync(string id, UpdatePesticideRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePesticideAsync(id, request, ct));
}
