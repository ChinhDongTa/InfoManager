namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeleteFertilizationPlanCommand(string Id) : IRequest<Result>;

public class DeleteFertilizationPlanCommandHandler : BaseDeleteCommandHandler<DeleteFertilizationPlanCommand, FertilizationPlan>
{
    public DeleteFertilizationPlanCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFertilizationPlanCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<FertilizationPlan?> GetEntityAsync(DeleteFertilizationPlanCommand request, CancellationToken ct)
  => await Context.FertilizationPlans.FindAsync(request, ct);
}