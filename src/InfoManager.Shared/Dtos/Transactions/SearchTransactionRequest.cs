namespace InfoManager.Shared.Dtos.Transactions;

public record SearchTransactionRequest(
    decimal? MinAmount = null,
    decimal? MaxAmount = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null,
    string? CategoryId = null,
    PaymentMethod? PaymentMethod = null,
    TransactionType? TransactionType = null,
    string? SortBy = null,
    bool Ascending = true,
    int PageNumber = 1,
    int PageSize = 20);