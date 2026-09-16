namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetSaleByIdQuery(string Id) : IRequest<Result<SaleDto?>>;

public class GetSaleByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSaleByIdQuery, Result<SaleDto?>>
{
    public async Task<Result<SaleDto?>> Handle(GetSaleByIdQuery request, CancellationToken ct)
    {
        var result = await context.Sales
            .Where(x => x.Id == request.Id)
            .ToSaleDto()
            .SingleOrNotFoundAsync(nameof(Sale), request.Id, ct);
        return result;
    }
}