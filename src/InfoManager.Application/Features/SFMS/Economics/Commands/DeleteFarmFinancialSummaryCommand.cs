namespace InfoManager.Application.Features.SFMS.Economics.Commands;

public record DeleteFarmFinancialSummaryCommand(string Id) : IRequest<Result>;
public class DeleteFarmFinancialSummaryCommandHandler : BaseDeleteCommandHandler<DeleteFarmFinancialSummaryCommand, FarmFinancialSummary>
{
    public DeleteFarmFinancialSummaryCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFarmFinancialSummaryCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<FarmFinancialSummary?> GetEntityAsync(DeleteFarmFinancialSummaryCommand request, CancellationToken cancellationToken)
        => await Context.FarmFinancialSummaries.FindAsync([request.Id], cancellationToken);
}