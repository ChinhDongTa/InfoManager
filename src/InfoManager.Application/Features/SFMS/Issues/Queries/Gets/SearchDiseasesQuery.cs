namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record SearchDiseasesQuery(string? Term, string? DiseaseType, SeverityLevel? SeverityLevel, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<DiseaseSummaryDto>>>;

public class SearchDiseasesQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchDiseasesQuery, Result<PaginatedList<DiseaseSummaryDto>>>
{
    public async Task<Result<PaginatedList<DiseaseSummaryDto>>> Handle(
        SearchDiseasesQuery request, CancellationToken ct)
    {
        var query = Context.Diseases.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToDiseaseSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DiseaseSummaryDto>>.Success(paged);
    }
}