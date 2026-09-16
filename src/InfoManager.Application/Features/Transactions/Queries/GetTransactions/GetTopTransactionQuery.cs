using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record GetTopTransactionsQuery(int Top = 5) : IRequest<Result<List<TransactionSummaryDto>>>;

public class GetTopTransactionsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTopTransactionsQuery, Result<List<TransactionSummaryDto>>>
{
    public async Task<Result<List<TransactionSummaryDto>>> Handle(GetTopTransactionsQuery request, CancellationToken ct)
    {
        var result = await context.Transactions
            .OrderByDescending(t => t.TransactionDate)
            .Take(request.Top)
            .ToTransactionSummaryDto()
            .ToListResultAsync(ct);
        return result;
    }
}