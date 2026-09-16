namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record DeleteProductCommand(string Id) : IRequest<Result>;

public class DeleteProductCommandHandler : BaseDeleteCommandHandler<DeleteProductCommand, Product>
{
    public DeleteProductCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteProductCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Product?> GetEntityAsync(DeleteProductCommand request, CancellationToken cancellationToken)
  => await Context.Products.FindAsync(request, cancellationToken);
}