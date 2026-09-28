namespace InfoManager.ApiClient.Services;

public class PestService(IPestApi api) : IPestService
{
    public async Task<ApiResult<string>> CreatePestAsync(CreatePestRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePestAsync(request, ct));

    public async Task<ApiResult> DeletePestAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePestAsync(id, ct));

    public async Task<ApiResult<PestDto?>> GetPestByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPestByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PestSummaryDto>>> GetPestsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPestsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PestSummaryDto>>> SearchPestsAsync(SearchPestsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPestsAsync(request.Term,
                                                                             request.PestType,
                                                                             request.SeverityLevel,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePestAsync(string id, UpdatePestRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePestAsync(id, request, ct));
}
