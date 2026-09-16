namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record SearchPestDiseaseLinksQuery(string? Term, string? PestId, string? DiseaseId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PestDiseaseLinkSummaryDto>>>;

public class SearchPestDiseaseLinksQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPestDiseaseLinksQuery, Result<PaginatedList<PestDiseaseLinkSummaryDto>>>
{
    public async Task<Result<PaginatedList<PestDiseaseLinkSummaryDto>>> Handle(
        SearchPestDiseaseLinksQuery request, CancellationToken ct)
    {
        var query = Context.PestDiseaseLinks.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPestDiseaseLinkSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PestDiseaseLinkSummaryDto>>.Success(paged);
    }
}