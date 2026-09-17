namespace InfoManager.ApiClient.Services;

internal class CostAnalysisService(ICostAnalysisApi api) : ICostAnalysisService
{
    public async Task<ApiResult<string>> CreateCostAnalysisAsync(CreateCostAnalysisRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCostAnalysisAsync(request, ct));

    public async Task<ApiResult> DeleteCostAnalysisAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteCostAnalysisAsync(id, ct));

    public async Task<ApiResult<CostAnalysisDto?>> GetCostAnalysisByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCostAnalysisByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CostAnalysisSummaryDto>>> GetCostAnalysesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCostAnalysesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CostAnalysisSummaryDto>>> SearchCostAnalysesAsync(SearchCostAnalysesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchCostAnalysesAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.CropPlantingId,
                                                                             request.StartAnalysisDate,
                                                                             request.EndAnalysisDate,
                                                                             request.StartFromDate,
                                                                             request.EndToDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateCostAnalysisAsync(string id, UpdateCostAnalysisRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateCostAnalysisAsync(id, request, ct));
}
