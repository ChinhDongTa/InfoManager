using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record GetNextMonthHistoricalEventsQuery(int NumMonths) : IRequest<Result<List<HistoricalEventSummaryDto>>>;
public class GetNextMonthHistoricalEventsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetNextMonthHistoricalEventsQuery, Result<List<HistoricalEventSummaryDto>>>
{
    public async Task<Result<List<HistoricalEventSummaryDto>>> Handle(GetNextMonthHistoricalEventsQuery request, CancellationToken cancellationToken)
    {
        var targetYear = DateTime.Now.Year;
        var months = GetMonthsRange(DateTime.UtcNow.Month, request.NumMonths);
        var result = await context.HistoricalEvents
            .Where(e => months.Contains(e.EventDate.Month))
            .ApplySorting()
            .ToHistoricalEventSummaryDto()
            .ToListResultAsync(cancellationToken);
        return result;
    }
    private static int[] GetMonthsRange(int startMonth, int numMonths)
    {
        var months = new List<int>();
        for (int i = 0; i <= numMonths; i++)
        {
            int month = ((startMonth - 1 + i) % 12) + 1;
            months.Add(month);
        }
        return [.. months];
    }
}