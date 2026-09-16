using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.ApiClient.Services;

public class TransactionService(ITransactionApi api) : ITransactionService
{
    public async Task<ApiResult<string>> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateTransactionAsync(request, ct));

    public async Task<ApiResult> DeleteTransactionAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteTransactionAsync(id, ct));

    public async Task<ApiResult<FinancialSummaryReportDto>> GetFinancialSummaryReportAsync(int month, int year, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFinancialSummaryReportAsync(month, year, ct));

    public async Task<ApiResult<List<TransactionSummaryDto>>> GetTopTransactionsAsync(int top = 5, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetTopTransactionsAsync(top, ct));

    public async Task<ApiResult<TransactionDto?>> GetTransactionByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetTransactionByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<TransactionSummaryDto>>> GetTransactionsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetTransactionsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<List<TransactionSummaryDto>>> GetTransactionsPendingAsync(CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetTransactionsPendingAsync(ct));

    public async Task<ApiResult<PaginatedList<TransactionSummaryDto>>> SearchTransactionsAsync(SearchTransactionRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.SearchTransactionsAsync(request.MinAmount,
                                                                                  request.MaxAmount,
                                                                                  request.StartDate,
                                                                                  request.EndDate,
                                                                                  request.CategoryId,
                                                                                  request.PaymentMethod,
                                                                                  request.TransactionType,
                                                                                  request.SortBy,
                                                                                  request.Ascending,
                                                                                  request.PageNumber,
                                                                                  request.PageSize,
                                                                                  ct));

    public async Task<ApiResult> UpdateTransactionAsync(string id, UpdateTransactionRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateTransactionAsync(id, request, ct));
}