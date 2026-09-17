namespace InfoManager.ApiClient.Interfaces;

public interface IPayrollService
{
    Task<ApiResult<PayrollDto?>> GetPayrollByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePayrollAsync(string id, UpdatePayrollRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePayrollAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PayrollSummaryDto>>> GetPayrollsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePayrollAsync(CreatePayrollRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PayrollSummaryDto>>> SearchPayrollsAsync(SearchPayrollsRequest request, CancellationToken ct = default);
}
