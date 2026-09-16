namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteFarmerCommand(string Id) : IRequest<Result>;

public class DeleteFarmerCommandHandler : BaseDeleteCommandHandler<DeleteFarmerCommand, Farmer>
{
    public DeleteFarmerCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFarmerCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Farmer?> GetEntityAsync(DeleteFarmerCommand request, CancellationToken ct)
        => await Context.Farmers.FindAsync([request.Id], ct);
}