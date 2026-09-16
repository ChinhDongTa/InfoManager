namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record SearchProductsQuery(string? Term, string? ProductId, ProductStatus? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<ProductSummaryDto>>>;

public class SearchProductsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchProductsQuery, Result<PaginatedList<ProductSummaryDto>>>
{
    public async Task<Result<PaginatedList<ProductSummaryDto>>> Handle(
        SearchProductsQuery request, CancellationToken ct)
    {
        var query = Context.Products.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToProductSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<ProductSummaryDto>>.Success(paged);
    }
}