namespace InfoManager.ApiClient.Services;

public class PestDiseaseLinkService(IPestDiseaseLinkApi api) : IPestDiseaseLinkService
{
    public async Task<ApiResult<string>> CreatePestDiseaseLinkAsync(CreatePestDiseaseLinkRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePestDiseaseLinkAsync(request, ct));

    public async Task<ApiResult> DeletePestDiseaseLinkAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePestDiseaseLinkAsync(id, ct));

    public async Task<ApiResult<PestDiseaseLinkDto?>> GetPestDiseaseLinkByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPestDiseaseLinkByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PestDiseaseLinkSummaryDto>>> GetPestDiseaseLinksAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPestDiseaseLinksAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PestDiseaseLinkSummaryDto>>> SearchPestDiseaseLinksAsync(SearchPestDiseaseLinksRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPestDiseaseLinksAsync(request.Term,
                                                                             request.PestId,
                                                                             request.DiseaseId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePestDiseaseLinkAsync(string id, UpdatePestDiseaseLinkRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePestDiseaseLinkAsync(id, request, ct));
}
