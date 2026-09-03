namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteGrowthStageCommand(string Id) : IRequest<Result>;
public class DeleteGrowthStageCommandHandler : BaseDeleteCommandHandler<DeleteGrowthStageCommand, GrowthStage>
{
    public DeleteGrowthStageCommandHandler(IApplicationDbContext context, ILogger<DeleteGrowthStageCommandHandler> logger) : base(context, logger)
    {
    }
    protected override async Task<GrowthStage?> GetEntityAsync(DeleteGrowthStageCommand request, CancellationToken cancellationToken)
    {
        return await Context.GrowthStages.FindAsync([request.Id], cancellationToken);
    }
}