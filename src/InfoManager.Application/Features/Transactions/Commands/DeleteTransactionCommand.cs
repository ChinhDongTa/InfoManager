namespace InfoManager.Application.Features.Transactions.Commands;

public record DeleteTransactionCommand(string Id) : IRequest<Result>;
public class DeleteTransactionCommandHandler : BaseDeleteCommandHandler<DeleteTransactionCommand, Transaction>
{
    public DeleteTransactionCommandHandler(IApplicationDbContext context,
                                           ILogger<DeleteTransactionCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(Transaction entity, CancellationToken cancellationToken)
    {
        Context.Transactions.Remove(entity);
    }
    protected override async Task<Transaction?> GetEntityAsync(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        return await Context.Transactions.FindAsync([request.Id], cancellationToken);
    }
}