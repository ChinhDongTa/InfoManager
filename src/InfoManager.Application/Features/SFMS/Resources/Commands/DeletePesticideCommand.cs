namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeletePesticideCommand(string Id) : IRequest<Result>;

public class DeletePesticideCommandHandler : BaseDeleteCommandHandler<DeletePesticideCommand, Pesticide>
{
    public DeletePesticideCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePesticideCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Pesticide?> GetEntityAsync(DeletePesticideCommand request, CancellationToken ct)
  => await Context.Pesticides.FindAsync(request, ct);
}