namespace InfoManager.ApiClient.Services;

public class DiseaseService(IDiseaseApi api) : IDiseaseService
{
    public async Task<ApiResult<string>> CreateDiseaseAsync(CreateDiseaseRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateDiseaseAsync(request, ct));

    public async Task<ApiResult> DeleteDiseaseAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteDiseaseAsync(id, ct));

    public async Task<ApiResult<DiseaseDto?>> GetDiseaseByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDiseaseByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<DiseaseSummaryDto>>> GetDiseasesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDiseasesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<DiseaseSummaryDto>>> SearchDiseasesAsync(SearchDiseasesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchDiseasesAsync(request.Term,
                                                                             request.DiseaseType,
                                                                             request.SeverityLevel,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateDiseaseAsync(string id, UpdateDiseaseRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateDiseaseAsync(id, request, ct));
}
