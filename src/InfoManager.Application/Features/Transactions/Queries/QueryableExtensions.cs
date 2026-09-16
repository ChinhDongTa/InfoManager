using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by TransactionDate in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of Transaction entities to sort.</param>
    /// <param name="sortBy">The field (amount) to sort by. If null or empty, defaults to sorting by TransactionDate.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of Transaction entities.</returns>
    public static IQueryable<Transaction> ApplySorting(this IQueryable<Transaction> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(t => t.TransactionDate);
        }

        return sortBy.ToLower() switch
        {
            "amount" => ascending ? query.OrderBy(t => t.Amount) : query.OrderByDescending(t => t.Amount),
            _ => query
        };
    }

    public static IQueryable<TransactionDto> ToTransactionDto(this IQueryable<Transaction> query)
    {
        return query.Select(t => new TransactionDto(Id: t.Id,
                                                    Amount: t.Amount,
                                                    CategoryName: t.Category == null ? null : t.Category.Name,
                                                    Description: t.Description,
                                                    TransactionDate: t.TransactionDate.ToLocalDateTime(),
                                                    TransactionTypeName: t.TransactionType.ToDisplayName(),
                                                    CategoryId: t.CategoryId,
                                                    PaymentMethodName: t.PaymentMethod.ToDisplayName(),
                                                    PaymentMethod: t.PaymentMethod,
                                                    TransactionType: t.TransactionType));
    }

    public static IQueryable<TransactionSummaryDto> ToTransactionSummaryDto(this IQueryable<Transaction> query)
    {
        return query.Select(t => new TransactionSummaryDto(Id: t.Id,
                                                    Amount: t.Amount,
                                                    CategoryName: t.Category == null ? null : t.Category.Name,
                                                    TransactionDate: t.TransactionDate.ToLocalDateTime(),
                                                    Description: t.Description));
    }
}