using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record GetTransactionByIdQuery(string Id) : IRequest<Result<TransactionDto?>>;
public class GetTransactionByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTransactionByIdQuery, Result<TransactionDto?>>
{
    public async Task<Result<TransactionDto?>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Transactions
            .Where(t => t.Id == request.Id)
            .ToTransactionDto()
            .SingleOrNotFoundAsync(nameof(Transaction), request.Id, cancellationToken);
        return result;
    }
}
