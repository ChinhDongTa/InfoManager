namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record DeletePestCommand(string Id) : IRequest<Result>;

public class DeletePestCommandHandler : BaseDeleteCommandHandler<DeletePestCommand, Pest>
{
    public DeletePestCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePestCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Pest?> GetEntityAsync(DeletePestCommand request, CancellationToken ct)
  => await Context.Pests.FindAsync(request, ct);
}