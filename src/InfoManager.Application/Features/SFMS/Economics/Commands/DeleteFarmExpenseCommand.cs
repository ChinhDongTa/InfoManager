namespace InfoManager.Application.Features.SFMS.Economics.Commands;

public record DeleteFarmExpenseCommand(string Id) : IRequest<Result>;

public class DeleteFarmExpenseCommandHandler : BaseDeleteCommandHandler<DeleteFarmExpenseCommand, FarmExpense>
{
    public DeleteFarmExpenseCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFarmExpenseCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<FarmExpense?> GetEntityAsync(DeleteFarmExpenseCommand request, CancellationToken ct)
        => await Context.FarmExpenses.FindAsync([request.Id], ct);
}