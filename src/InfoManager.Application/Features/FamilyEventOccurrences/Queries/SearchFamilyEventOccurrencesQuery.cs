using InfoManager.Shared.Dtos.FamilyEventOccurrences;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.FamilyEventOccurrences.Queries;

public record SearchFamilyEventOccurrencesQuery(string? Keyword, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>;
public class SearchFamilyEventOccurrencesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFamilyEventOccurrencesQuery, Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>> Handle(SearchFamilyEventOccurrencesQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyEventOccurrences.AsQueryable();
        if (!string.IsNullOrEmpty(request.Keyword))
        {
            string keyword = $"%{request.Keyword}%";
            query = query.Where(e => (e.Location != null && EF.Functions.ILike(e.Location, keyword)) || (e.Notes != null && EF.Functions.ILike(e.Notes, keyword)));
        }
        var paginated = await query
            .ApplySorting()
            .ToFamilyEventOccurrenceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>.Success(paginated);
    }
}