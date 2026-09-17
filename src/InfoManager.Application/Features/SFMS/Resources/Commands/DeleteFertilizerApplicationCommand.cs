namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeleteFertilizerApplicationCommand(string Id) : IRequest<Result>;

public class DeleteFertilizerApplicationCommandHandler : BaseDeleteCommandHandler<DeleteFertilizerApplicationCommand, FertilizerApplication>
{
    public DeleteFertilizerApplicationCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFertilizerApplicationCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<FertilizerApplication?> GetEntityAsync(DeleteFertilizerApplicationCommand request, CancellationToken ct)
  => await Context.FertilizerApplications.FindAsync(request, ct);
}