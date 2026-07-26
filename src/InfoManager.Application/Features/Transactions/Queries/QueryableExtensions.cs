using InfoManager.Shared.Dtos.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoManager.Application.Features.Transactions.Queries;

public static class QueryableExtensions
{
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
                                                    TransactionType:t.TransactionType));
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
