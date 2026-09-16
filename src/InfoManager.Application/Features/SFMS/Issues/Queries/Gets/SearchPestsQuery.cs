namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record SearchPestsQuery(string? Term, string? PestType, SeverityLevel? SeverityLevel, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PestSummaryDto>>>;

public class SearchPestsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPestsQuery, Result<PaginatedList<PestSummaryDto>>>
{
    public async Task<Result<PaginatedList<PestSummaryDto>>> Handle(
        SearchPestsQuery request, CancellationToken ct)
    {
        var query = Context.Pests.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PestSummaryDto>>.Success(paged);
    }
}