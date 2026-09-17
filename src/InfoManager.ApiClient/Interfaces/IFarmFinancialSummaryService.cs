namespace InfoManager.ApiClient.Interfaces;

public interface IFarmFinancialSummaryService
{
    Task<ApiResult<FarmFinancialSummaryDto?>> GetFarmFinancialSummaryByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFarmFinancialSummaryAsync(string id, UpdateFarmFinancialSummaryRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFarmFinancialSummaryAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmFinancialSummarySummaryDto>>> GetFarmFinancialSummariesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFarmFinancialSummaryAsync(CreateFarmFinancialSummaryRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmFinancialSummarySummaryDto>>> SearchFarmFinancialSummariesAsync(SearchFarmFinancialSummariesRequest request, CancellationToken ct = default);
}
