using InfoManager.Shared.Dtos.FamilyEventOccurrences;
using InfoManager.Shared.Models;


namespace InfoManager.Application.Features.FamilyEventOccurrences.Queries;

public record GetFamilyEventOccurrencesQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>;
public class GetFamilyEventOccurrencesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventOccurrencesQuery, Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>> Handle(GetFamilyEventOccurrencesQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyEventOccurrences.AsQueryable();
        var paginated = await query
            .ApplySorting()
            .ToFamilyEventOccurrenceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>.Success(paginated);
    }
}