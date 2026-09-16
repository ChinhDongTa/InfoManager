using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

public record GetFamilyEventByMemberIdQuery(string FamilyMemberId, int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FamilyEventSummaryDto>>>;

public class GetFamilyEventByMemberIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventByMemberIdQuery, Result<PaginatedList<FamilyEventSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventSummaryDto>>> Handle(GetFamilyEventByMemberIdQuery request, CancellationToken ct)
    {
        var paginated = await context.FamilyEvents
            .Where(e => e.FamilyMemberId == request.FamilyMemberId)
            .ApplySorting()
            .ToQuerySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilyEventSummaryDto>>.Success(paginated);
    }
}