namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record DeleteSaleCommand(string Id) : IRequest<Result>;

public class DeleteSaleCommandHandler : BaseDeleteCommandHandler<DeleteSaleCommand, Sale>
{
    public DeleteSaleCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteSaleCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Sale?> GetEntityAsync(DeleteSaleCommand request, CancellationToken ct)
  => await Context.Sales.FindAsync(request, ct);
}