namespace InfoManager.ApiClient.Services;

internal class PayrollService(IPayrollApi api) : IPayrollService
{
    public async Task<ApiResult<string>> CreatePayrollAsync(CreatePayrollRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreatePayrollAsync(request, ct));

    public async Task<ApiResult> DeletePayrollAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeletePayrollAsync(id, ct));

    public async Task<ApiResult<PayrollDto?>> GetPayrollByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPayrollByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<PayrollSummaryDto>>> GetPayrollsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetPayrollsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<PayrollSummaryDto>>> SearchPayrollsAsync(SearchPayrollsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchPayrollsAsync(request.Term,
                                                                             request.HREmployeeId,
                                                                             request.PaymentStatus,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdatePayrollAsync(string id, UpdatePayrollRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdatePayrollAsync(id, request, ct));
}
