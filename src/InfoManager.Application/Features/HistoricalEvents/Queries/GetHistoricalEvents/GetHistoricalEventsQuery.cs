using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record GetHistoricalEventsQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<HistoricalEventSummaryDto>>>;

public class GetHistoricalEventsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHistoricalEventsQuery, Result<PaginatedList<HistoricalEventSummaryDto>>>
{
    public async Task<Result<PaginatedList<HistoricalEventSummaryDto>>> Handle(GetHistoricalEventsQuery request, CancellationToken ct)
    {
        var paginated = await context.HistoricalEvents
            .ApplySorting()
            .ToHistoricalEventSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<HistoricalEventSummaryDto>>.Success(paginated);
    }
}