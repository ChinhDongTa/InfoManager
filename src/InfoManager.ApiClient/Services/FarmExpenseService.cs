namespace InfoManager.ApiClient.Services;

internal class FarmExpenseService(IFarmExpenseApi api) : IFarmExpenseService
{
    public async Task<ApiResult<string>> CreateFarmExpenseAsync(CreateFarmExpenseRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateFarmExpenseAsync(request, ct));

    public async Task<ApiResult> DeleteFarmExpenseAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteFarmExpenseAsync(id, ct));

    public async Task<ApiResult<FarmExpenseDto?>> GetFarmExpenseByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmExpenseByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FarmExpenseSummaryDto>>> GetFarmExpensesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetFarmExpensesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FarmExpenseSummaryDto>>> SearchFarmExpensesAsync(SearchFarmExpensesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchFarmExpensesAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.CropPlantingId,
                                                                             request.ExpenseType,
                                                                             request.PaymentStatus,
                                                                             request.ApprovalStatus,
                                                                             request.StartExpenseDate,
                                                                             request.EndExpenseDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateFarmExpenseAsync(string id, UpdateFarmExpenseRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateFarmExpenseAsync(id, request, ct));
}
