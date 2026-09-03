namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteGrowthStageAlertCommand(string Id) : IRequest<Result>;
public class DeleteGrowthStageAlertCommandHandler : BaseDeleteCommandHandler<DeleteGrowthStageAlertCommand, GrowthStageAlert>
{
    public DeleteGrowthStageAlertCommandHandler(IApplicationDbContext context,  ILogger<DeleteGrowthStageAlertCommandHandler> logger) : base(context,  logger)
    {
    }
    protected override async Task<GrowthStageAlert?> GetEntityAsync(DeleteGrowthStageAlertCommand request, CancellationToken cancellationToken)
    {
        return await Context.GrowthStageAlerts.FindAsync([request.Id], cancellationToken);
    }
}