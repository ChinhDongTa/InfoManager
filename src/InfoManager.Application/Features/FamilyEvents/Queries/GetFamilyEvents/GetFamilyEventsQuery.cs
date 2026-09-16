using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

public record GetFamilyEventsQuery(FamilyEventType? EventType = null, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventSummaryDto>>>;

public class GetFamilyEventsQueryHandler(IApplicationDbContext Context) : IRequestHandler<GetFamilyEventsQuery, Result<PaginatedList<FamilyEventSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventSummaryDto>>> Handle(GetFamilyEventsQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var query = Context.FamilyEvents.AsQueryable();
        if (request.EventType.HasValue)
        {
            query = query.Where(e => e.EventType == request.EventType.Value);
        }
        var result = await query
            .ApplySorting()
            .ToQuerySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilyEventSummaryDto>>.Success(result);
    }
}