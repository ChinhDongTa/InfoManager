namespace InfoManager.Application.Features.SFMS.Economics.Commands;

public record DeleteFarmRevenueCommand(string Id) : IRequest<Result>;
public class DeleteFarmRevenueCommandHandler : BaseDeleteCommandHandler<DeleteFarmRevenueCommand, FarmRevenue>
{
    public DeleteFarmRevenueCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFarmRevenueCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<FarmRevenue?> GetEntityAsync(DeleteFarmRevenueCommand request, CancellationToken cancellationToken)
        => await Context.FarmRevenues.FindAsync([request.Id], cancellationToken);
}