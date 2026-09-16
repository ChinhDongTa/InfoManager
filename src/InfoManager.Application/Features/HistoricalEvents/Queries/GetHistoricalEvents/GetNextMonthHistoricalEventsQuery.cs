using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record GetNextMonthHistoricalEventsQuery(int NumMonths) : IRequest<Result<List<HistoricalEventSummaryDto>>>;

public class GetNextMonthHistoricalEventsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetNextMonthHistoricalEventsQuery, Result<List<HistoricalEventSummaryDto>>>
{
    public async Task<Result<List<HistoricalEventSummaryDto>>> Handle(GetNextMonthHistoricalEventsQuery request, CancellationToken ct)
    {
        var targetYear = DateTime.Now.Year;
        var months = NumberExtension.GetMonthsRange(DateTime.UtcNow.Month, request.NumMonths);
        var result = await context.HistoricalEvents
            .Where(e => e.EventDate.HasValue && months.Contains(e.EventDate.Value.Month))
            .ApplySorting()
            .ToHistoricalEventSummaryDto()
            .ToListResultAsync(ct);
        return result;
    }
}