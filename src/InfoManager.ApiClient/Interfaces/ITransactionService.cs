using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.ApiClient.Interfaces;

public interface ITransactionService
{
    Task<ApiResult<PaginatedList<TransactionSummaryDto>>> GetTransactionsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default);
    Task<ApiResult<TransactionDto?>> GetTransactionByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<TransactionSummaryDto>>> GetTransactionsPendingAsync(CancellationToken ct = default);
    Task<ApiResult<List<TransactionSummaryDto>>> GetTopTransactionsAsync(int top = 5, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<TransactionSummaryDto>>> SearchTransactionsAsync(SearchTransactionRequest request, CancellationToken ct = default);

    Task<ApiResult<string>> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateTransactionAsync(string id, UpdateTransactionRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteTransactionAsync(string id, CancellationToken ct = default);
}