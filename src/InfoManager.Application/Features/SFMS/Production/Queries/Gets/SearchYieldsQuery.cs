namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record SearchYieldsQuery(string? Term, string? CropPlantingId, string? YieldId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<YieldSummaryDto>>>;

public class SearchYieldsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchYieldsQuery, Result<PaginatedList<YieldSummaryDto>>>
{
    public async Task<Result<PaginatedList<YieldSummaryDto>>> Handle(
        SearchYieldsQuery request, CancellationToken ct)
    {
        var query = Context.Yields.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToYieldSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<YieldSummaryDto>>.Success(paged);
    }
}