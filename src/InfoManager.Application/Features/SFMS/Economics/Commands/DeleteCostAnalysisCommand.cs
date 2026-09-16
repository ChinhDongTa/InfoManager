namespace InfoManager.Application.Features.SFMS.Economics.Commands;

public record DeleteCostAnalysisCommand(string Id) : IRequest<Result>;

public class DeleteCostAnalysisCommandHandler : BaseDeleteCommandHandler<DeleteCostAnalysisCommand, CostAnalysis>
{
    public DeleteCostAnalysisCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCostAnalysisCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<CostAnalysis?> GetEntityAsync(DeleteCostAnalysisCommand request, CancellationToken ct)
        => await Context.CostAnalyses.FindAsync([request.Id], ct);
}