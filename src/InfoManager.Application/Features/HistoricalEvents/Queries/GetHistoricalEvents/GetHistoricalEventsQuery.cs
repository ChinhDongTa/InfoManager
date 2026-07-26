using InfoManager.Shared.Dtos.HistoricalEvents;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record GetHistoricalEventsQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<HistoricalEventSummaryDto>>>;
public class GetHistoricalEventsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHistoricalEventsQuery, Result<PaginatedList<HistoricalEventSummaryDto>>>
{
    public async Task<Result<PaginatedList<HistoricalEventSummaryDto>>> Handle(GetHistoricalEventsQuery request, CancellationToken cancellationToken)
    {
        var paginated = await context.HistoricalEvents
            .ApplySorting()
            .ToHistoricalEventSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<HistoricalEventSummaryDto>>.Success(paginated);
    }
}
