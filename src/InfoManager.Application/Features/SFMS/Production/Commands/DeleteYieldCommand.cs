namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record DeleteYieldCommand(string Id) : IRequest<Result>;

public class DeleteYieldCommandHandler : BaseDeleteCommandHandler<DeleteYieldCommand, Yield>
{
    public DeleteYieldCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteYieldCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Yield?> GetEntityAsync(DeleteYieldCommand request, CancellationToken ct)
  => await Context.Yields.FindAsync(request, ct);
}