using InfoManager.Shared.Dtos.PriceTrackings;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.PriceTrackings.Queries.GetPriceTrackings;
public record SearchPriceTrackingQuery : IRequest<Result<PaginatedList<PriceTrackingSummaryDto>>>
{
    public string? SearchTerm { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public string? SortBy { get; init; } = null;
    public bool Ascending { get; init; } = true;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}
public class SearchPriceTrackingQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchPriceTrackingQuery, Result<PaginatedList<PriceTrackingSummaryDto>>>
{
    public async Task<Result<PaginatedList<PriceTrackingSummaryDto>>> Handle(SearchPriceTrackingQuery request, CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(request);
        var result = await query
            .ApplySorting(request.SortBy, request.Ascending)
            .ToPriceTrackingSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<PriceTrackingSummaryDto>>.Success(result);
    }
    private IQueryable<PriceTracking> BuildSearchQuery(SearchPriceTrackingQuery request)
    {
        var query = context.PriceTrackings.AsQueryable();
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var key = $"%{request.SearchTerm.Trim()}%";
            query = query.Where(t => EF.Functions.Like(t.ProductName, key)
                                            ||(t.StoreName!=null && EF.Functions.Like(t.StoreName, key))
                                            || (t.Description != null && EF.Functions.Like(t.Description, key)
                                            ));
        }
        if (request.MinPrice.HasValue)
            query = query.Where(t => t.CurrentPrice >= request.MinPrice.Value);
        if (request.MaxPrice.HasValue)
            query = query.Where(t => t.CurrentPrice <= request.MaxPrice.Value);
        return query;
    }
}