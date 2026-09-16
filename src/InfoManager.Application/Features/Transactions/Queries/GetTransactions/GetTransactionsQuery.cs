using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record GetTransactionsQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<TransactionSummaryDto>>>;

public class GetTransactionsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTransactionsQuery, Result<PaginatedList<TransactionSummaryDto>>>
{
    public async Task<Result<PaginatedList<TransactionSummaryDto>>> Handle(GetTransactionsQuery request, CancellationToken ct)
    {
        var paginated = await context.Transactions
            .ApplySorting()
            .ToTransactionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);

        return Result<PaginatedList<TransactionSummaryDto>>.Success(paginated);
    }
}