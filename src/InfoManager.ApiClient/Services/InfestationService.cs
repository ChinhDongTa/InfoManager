namespace InfoManager.ApiClient.Services;

public class InfestationService(IInfestationApi api) : IInfestationService
{
    public async Task<ApiResult<string>> CreateInfestationAsync(CreateInfestationRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateInfestationAsync(request, ct));

    public async Task<ApiResult> DeleteInfestationAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteInfestationAsync(id, ct));

    public async Task<ApiResult<InfestationDto?>> GetInfestationByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetInfestationByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<InfestationSummaryDto>>> GetInfestationsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetInfestationsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<InfestationSummaryDto>>> SearchInfestationsAsync(SearchInfestationsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchInfestationsAsync(request.Term,
                                                                             request.CropPlantingId,
                                                                             request.InfestationType,
                                                                             request.Status,
                                                                             request.SeverityLevel,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateInfestationAsync(string id, UpdateInfestationRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateInfestationAsync(id, request, ct));
}
