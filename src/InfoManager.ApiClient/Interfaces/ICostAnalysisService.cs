namespace InfoManager.ApiClient.Interfaces;

public interface ICostAnalysisService
{
    Task<ApiResult<CostAnalysisDto?>> GetCostAnalysisByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateCostAnalysisAsync(string id, UpdateCostAnalysisRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteCostAnalysisAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CostAnalysisSummaryDto>>> GetCostAnalysesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateCostAnalysisAsync(CreateCostAnalysisRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<CostAnalysisSummaryDto>>> SearchCostAnalysesAsync(SearchCostAnalysesRequest request, CancellationToken ct = default);
}
