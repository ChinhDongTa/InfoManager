namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteFarmCommand(string Id) : IRequest<Result>;
public class DeleteFarmCommandHandler : BaseDeleteCommandHandler<DeleteFarmCommand, Farm>
{
    public DeleteFarmCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFarmCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Farm?> GetEntityAsync(DeleteFarmCommand request, CancellationToken cancellationToken)
        => await Context.Farms.FindAsync([request.Id], cancellationToken);
}