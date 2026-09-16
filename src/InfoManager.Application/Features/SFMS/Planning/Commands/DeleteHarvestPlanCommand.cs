namespace InfoManager.Application.Features.SFMS.Planning.Commands;

public record DeleteHarvestPlanCommand(string Id) : IRequest<Result>;

public class DeleteHarvestPlanCommandHandler : BaseDeleteCommandHandler<DeleteHarvestPlanCommand, HarvestPlan>
{
    public DeleteHarvestPlanCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteHarvestPlanCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<HarvestPlan?> GetEntityAsync(DeleteHarvestPlanCommand request, CancellationToken ct)
  => await Context.HarvestPlans.FindAsync(request, ct);
}