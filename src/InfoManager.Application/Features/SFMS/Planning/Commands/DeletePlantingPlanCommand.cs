namespace InfoManager.Application.Features.SFMS.Planning.Commands;

public record DeletePlantingPlanCommand(string Id) : IRequest<Result>;
public class DeletePlantingPlanCommandHandler : BaseDeleteCommandHandler<DeletePlantingPlanCommand, PlantingPlan>
{
    public DeletePlantingPlanCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePlantingPlanCommandHandler> logger) : base(context, logger)
    {
    }
    protected override async Task<PlantingPlan?> GetEntityAsync(DeletePlantingPlanCommand request, CancellationToken cancellationToken)
  => await Context.PlantingPlans.FindAsync(request, cancellationToken);
}
