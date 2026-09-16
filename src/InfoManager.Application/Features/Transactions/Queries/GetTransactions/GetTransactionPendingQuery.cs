using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record GetTransactionPendingQuery : IRequest<Result<List<TransactionSummaryDto>>>;

public class GetTransactionPendingQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTransactionPendingQuery, Result<List<TransactionSummaryDto>>>
{
    public async Task<Result<List<TransactionSummaryDto>>> Handle(GetTransactionPendingQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Transactions
            .Where(t => t.TransactionDate == null)
            .ApplySorting()
            .ToTransactionSummaryDto()
            .ToListResultAsync(cancellationToken);
        return result;
    }
}