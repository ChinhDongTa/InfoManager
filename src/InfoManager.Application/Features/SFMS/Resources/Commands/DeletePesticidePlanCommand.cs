namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record DeletePesticidePlanCommand(string Id) : IRequest<Result>;

public class DeletePesticidePlanCommandHandler : BaseDeleteCommandHandler<DeletePesticidePlanCommand, PesticidePlan>
{
    public DeletePesticidePlanCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePesticidePlanCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<PesticidePlan?> GetEntityAsync(DeletePesticidePlanCommand request, CancellationToken ct)
  => await Context.PesticidePlans.FindAsync(request, ct);
}