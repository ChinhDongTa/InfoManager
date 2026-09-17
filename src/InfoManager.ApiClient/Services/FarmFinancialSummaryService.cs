namespace InfoManager.ApiClient.Services;

internal class FarmFinancialSummaryService(IFarmFinancialSummaryApi api) : IFarmFinancialSummaryService
{
    public async Task<ApiResult<string>> CreateFarmFinancialSummaryAsync(CreateFarmFinancialSummaryRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFarmFinancialSummaryAsync(request, ct));

    public async Task<ApiResult> DeleteFarmFinancialSummaryAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFarmFinancialSummaryAsync(id, ct));

    public async Task<ApiResult<FarmFinancialSummaryDto?>> GetFarmFinancialSummaryByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmFinancialSummaryByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FarmFinancialSummarySummaryDto>>> GetFarmFinancialSummariesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmFinancialSummariesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FarmFinancialSummarySummaryDto>>> SearchFarmFinancialSummariesAsync(SearchFarmFinancialSummariesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFarmFinancialSummariesAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.Year,
                                                                             request.Month,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFarmFinancialSummaryAsync(string id, UpdateFarmFinancialSummaryRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFarmFinancialSummaryAsync(id, request, ct));
}
