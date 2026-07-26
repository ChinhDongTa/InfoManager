namespace InfoManager.Application.Features.PriceTrackings.Commands;
public record DeletePriceTrackingCommand(string Id) : IRequest<Result>;
public class DeletePriceTrackingCommandHandler : BaseDeleteCommandHandler<DeletePriceTrackingCommand, PriceTracking>
{
    public DeletePriceTrackingCommandHandler(IApplicationDbContext context,
                                             ILogger<DeletePriceTrackingCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(PriceTracking entity, CancellationToken cancellationToken)
    {
        Context.PriceTrackings.Remove(entity);
    }
    protected override async Task<PriceTracking?> GetEntityAsync(DeletePriceTrackingCommand request, CancellationToken cancellationToken)
    {
        return await Context.PriceTrackings.FindAsync([request.Id], cancellationToken);
    }
}
