using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ApiClient.Interfaces;

public interface ISoilAnalysisService
{
    Task<ApiResult<SoilAnalysisDto?>> GetSoilAnalysisByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateSoilAnalysisAsync(string id, UpdateSoilAnalysisRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteSoilAnalysisAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SoilAnalysisSummaryDto>>> GetSoilAnalysesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateSoilAnalysisAsync(CreateSoilAnalysisRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SoilAnalysisSummaryDto>>> SearchSoilAnalysesAsync(SearchSoilAnalysesRequest request, CancellationToken ct = default);
}
