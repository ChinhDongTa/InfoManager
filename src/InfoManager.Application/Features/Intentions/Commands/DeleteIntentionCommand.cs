namespace InfoManager.Application.Features.Intentions.Commands;
public record DeleteIntentionCommand(string Id) : IRequest<Result>;
public class DeleteIntentionCommandHandler : BaseDeleteCommandHandler<DeleteIntentionCommand, Intention>
{
    public DeleteIntentionCommandHandler(IApplicationDbContext context,
                                         ILogger<DeleteIntentionCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(Intention entity, CancellationToken cancellationToken)
    {
        Context.Intentions.Remove(entity);
    }
    protected override async Task<Intention?> GetEntityAsync(DeleteIntentionCommand request, CancellationToken cancellationToken)
    {
        return await Context.Intentions.FindAsync([request.Id], cancellationToken);
    }
}