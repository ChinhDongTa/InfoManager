using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ApiClient.Services;

public class SoilAnalysisService(ISoilAnalysisApi api) : ISoilAnalysisService
{
    public async Task<ApiResult<string>> CreateSoilAnalysisAsync(CreateSoilAnalysisRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateSoilAnalysisAsync(request, ct));

    public async Task<ApiResult> DeleteSoilAnalysisAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteSoilAnalysisAsync(id, ct));

    public async Task<ApiResult<SoilAnalysisDto?>> GetSoilAnalysisByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetSoilAnalysisByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<SoilAnalysisSummaryDto>>> GetSoilAnalysesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetSoilAnalysesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<SoilAnalysisSummaryDto>>> SearchSoilAnalysesAsync(SearchSoilAnalysesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchSoilAnalysesAsync(request.Term,
                                                                             request.FieldId,
                                                                             request.StartDate,
                                                                             request.EndDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateSoilAnalysisAsync(string id, UpdateSoilAnalysisRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateSoilAnalysisAsync(id, request, ct));
}
