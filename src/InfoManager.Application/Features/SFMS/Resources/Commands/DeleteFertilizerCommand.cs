namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeleteFertilizerCommand(string Id) : IRequest<Result>;

public class DeleteFertilizerCommandHandler : BaseDeleteCommandHandler<DeleteFertilizerCommand, Fertilizer>
{
    public DeleteFertilizerCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFertilizerCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Fertilizer?> GetEntityAsync(DeleteFertilizerCommand request, CancellationToken ct)
  => await Context.Fertilizers.FindAsync(request, ct);
}