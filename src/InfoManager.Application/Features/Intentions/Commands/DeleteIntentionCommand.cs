using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.Intentions.Commands;
public record DeleteIntentionCommand(string Id) : IRequest<Result>;
public class DeleteIntentionCommandHandler : BaseDeleteCommandHandler<DeleteIntentionCommand, Intention>
{
    public DeleteIntentionCommandHandler(IApplicationDbContext context,
                                         ILogger<DeleteIntentionCommandHandler> logger)
        : base(context, logger)
    {
    }
   
    protected override async Task<Intention?> GetEntityAsync(DeleteIntentionCommand request, CancellationToken cancellationToken)
    {
        return await Context.Intentions.FindAsync([request.Id], cancellationToken);
    }
}