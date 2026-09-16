namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetProductsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<ProductSummaryDto>>>;

public class GetProductsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProductsQuery, Result<PaginatedList<ProductSummaryDto>>>
{
    public async Task<Result<PaginatedList<ProductSummaryDto>>> Handle(GetProductsQuery request, CancellationToken ct)
    {
        var result = await context.Products
            .ApplySorting()
            .ToProductSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<ProductSummaryDto>>.Success(result);
    }
}