namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record DeleteInfestationCommand(string Id) : IRequest<Result>;

public class DeleteInfestationCommandHandler : BaseDeleteCommandHandler<DeleteInfestationCommand, Infestation>
{
    public DeleteInfestationCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteInfestationCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Infestation?> GetEntityAsync(DeleteInfestationCommand request, CancellationToken ct)
  => await Context.Infestations.FindAsync(request, ct);
}