namespace InfoManager.Application.Features.HistoricalEvents.Commands;
public record DeleteHistoricalEventCommand(string Id) : IRequest<Result>;
public class DeleteHistoricalEventCommandHandler : BaseDeleteCommandHandler<DeleteHistoricalEventCommand, HistoricalEvent>
{
    public DeleteHistoricalEventCommandHandler(IApplicationDbContext context,
                                             ILogger<DeleteHistoricalEventCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(HistoricalEvent entity, CancellationToken cancellationToken)
    {
        Context.HistoricalEvents.Remove(entity);
    }
    protected override async Task<HistoricalEvent?> GetEntityAsync(DeleteHistoricalEventCommand request, CancellationToken cancellationToken)
    {
        return await Context.HistoricalEvents.FindAsync([request.Id], cancellationToken);
    }
}