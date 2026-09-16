using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.Application.Features.FamilyEventOccurrences.Queries;

public record GetFamilyEventOccurrencesQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>;

public class GetFamilyEventOccurrencesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventOccurrencesQuery, Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>> Handle(GetFamilyEventOccurrencesQuery request, CancellationToken ct)
    {
        var query = context.FamilyEventOccurrences.AsQueryable();
        var paginated = await query
            .ApplySorting()
            .ToFamilyEventOccurrenceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>.Success(paginated);
    }
}