using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.Transactions;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record SearchTransactionQuery : IRequest<Result<PaginatedList<TransactionSummaryDto>>>
{
    public decimal? MinAmount { get; init; }
    public decimal? MaxAmount { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? CategoryId { get; init; }
    public PaymentMethod? PaymentMethod { get; init; }
    public TransactionType? TransactionType { get; init; }
    public string? SortBy { get; init; }
    public bool Ascending { get; init; } = true;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}
public class SearchTransactionQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchTransactionQuery, Result<PaginatedList<TransactionSummaryDto>>>
{
    public async Task<Result<PaginatedList<TransactionSummaryDto>>> Handle(SearchTransactionQuery request, CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(request);
        var result = await query
            .ApplySorting(request.SortBy, request.Ascending)
            .ToTransactionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<TransactionSummaryDto>>.Success(result);
    }

    private IQueryable<Transaction> BuildSearchQuery(SearchTransactionQuery request)
    {
        var query = context.Transactions.AsQueryable();
        if (request.MinAmount.HasValue)
            query = query.Where(t => t.Amount >= request.MinAmount.Value);
        if (request.MaxAmount.HasValue)
            query = query.Where(t => t.Amount <= request.MaxAmount.Value);
        if (request.StartDate.HasValue)
            query = query.Where(t => t.TransactionDate >= request.StartDate.Value);
        if (request.EndDate.HasValue)
            query = query.Where(t => t.TransactionDate <= request.EndDate.Value);
        if (!string.IsNullOrEmpty(request.CategoryId))
            query = query.Where(t => t.CategoryId == request.CategoryId);
        if (request.PaymentMethod.HasValue)
            query = query.Where(t => t.PaymentMethod == request.PaymentMethod.Value);
        if (request.TransactionType.HasValue)
            query = query.Where(t => t.TransactionType == request.TransactionType.Value);
        return query;
    }
}