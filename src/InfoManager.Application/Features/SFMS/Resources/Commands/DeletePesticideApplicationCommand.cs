namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeletePesticideApplicationCommand(string Id) : IRequest<Result>;

public class DeletePesticideApplicationCommandHandler : BaseDeleteCommandHandler<DeletePesticideApplicationCommand, PesticideApplication>
{
    public DeletePesticideApplicationCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePesticideApplicationCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<PesticideApplication?> GetEntityAsync(DeletePesticideApplicationCommand request, CancellationToken ct)
  => await Context.PesticideApplications.FindAsync(request, ct);
}