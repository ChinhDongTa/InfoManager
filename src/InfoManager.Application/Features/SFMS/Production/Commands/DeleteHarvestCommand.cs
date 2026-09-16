namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record DeleteHarvestCommand(string Id) : IRequest<Result>;

public class DeleteHarvestCommandHandler : BaseDeleteCommandHandler<DeleteHarvestCommand, Harvest>
{
    public DeleteHarvestCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteHarvestCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Harvest?> GetEntityAsync(DeleteHarvestCommand request, CancellationToken cancellationToken)
  => await Context.Harvests.FindAsync(request, cancellationToken);
}