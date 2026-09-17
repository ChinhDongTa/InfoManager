namespace InfoManager.ApiClient.Services;

internal class PesticidePlanService(IPesticidePlanApi api) : IPesticidePlanService
{
    public async Task<ApiResult<string>> CreatePesticidePlanAsync(CreatePesticidePlanRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePesticidePlanAsync(request, ct));

    public async Task<ApiResult> DeletePesticidePlanAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePesticidePlanAsync(id, ct));

    public async Task<ApiResult<PesticidePlanDto?>> GetPesticidePlanByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticidePlanByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PesticidePlanSummaryDto>>> GetPesticidePlansAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPesticidePlansAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PesticidePlanSummaryDto>>> SearchPesticidePlansAsync(SearchPesticidePlansRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPesticidePlansAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.PesticideId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePesticidePlanAsync(string id, UpdatePesticidePlanRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePesticidePlanAsync(id, request, ct));
}
