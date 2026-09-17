namespace InfoManager.ApiClient.Interfaces;

public interface IFarmExpenseService
{
    Task<ApiResult<FarmExpenseDto?>> GetFarmExpenseByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFarmExpenseAsync(string id, UpdateFarmExpenseRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFarmExpenseAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmExpenseSummaryDto>>> GetFarmExpensesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFarmExpenseAsync(CreateFarmExpenseRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmExpenseSummaryDto>>> SearchFarmExpensesAsync(SearchFarmExpensesRequest request, CancellationToken ct = default);
}
