namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetProductByIdQuery(string Id) : IRequest<Result<ProductDto?>>;

public class GetProductByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProductByIdQuery, Result<ProductDto?>>
{
    public async Task<Result<ProductDto?>> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var result = await context.Products
            .Where(x => x.Id == request.Id)
            .ToProductDto()
            .SingleOrNotFoundAsync(nameof(Product), request.Id, ct);
        return result;
    }
}