using InfoManager.Shared.Dtos.FamilyEventOccurrences;
using InfoManager.Shared.Models;


namespace InfoManager.Application.Features.FamilyEventOccurrences.Queries;
public record GetFamilyEventOccurrencesByMemberIdQuery(string MemberId, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>;
public class GetFamilyEventOccurrencesByMemberIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventOccurrencesByMemberIdQuery, Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>> Handle(GetFamilyEventOccurrencesByMemberIdQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyEventOccurrences
            .Where(e => e.FamilyEvent != null && e.FamilyEvent.FamilyMemberId == request.MemberId)
            .AsQueryable();
        var paginated = await query
            .ApplySorting()
            .ToFamilyEventOccurrenceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyEventOccurrenceSummaryDto>>.Success(paginated);
    }
}