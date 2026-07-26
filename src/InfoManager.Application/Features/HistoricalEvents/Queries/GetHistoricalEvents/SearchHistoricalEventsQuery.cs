using InfoManager.Shared.Dtos.HistoricalEvents;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record SearchHistoricalEventsQuery(string? SearchTerm,
                                      DateOnly? StartDate,
                                      DateOnly? EndDate,
                                      int PageNumber = 1,
                                      int PageSize = 20) : IRequest<Result<PaginatedList<HistoricalEventSummaryDto>>>;
public class SearchHistoricalEventsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchHistoricalEventsQuery, Result<PaginatedList<HistoricalEventSummaryDto>>>
{
    public async Task<Result<PaginatedList<HistoricalEventSummaryDto>>> Handle(SearchHistoricalEventsQuery request, CancellationToken cancellationToken)
    {
        var query = context.HistoricalEvents.AsQueryable();
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(e => e.Title.Contains(request.SearchTerm) || e.Summary.Contains(request.SearchTerm));
        }
        if (request.StartDate.HasValue)
        {
            query = query.Where(e => e.EventDate >= request.StartDate.Value);
        }
        if (request.EndDate.HasValue)
        {
            query = query.Where(e => e.EventDate <= request.EndDate.Value);
        }
        var paginated = await query
            .ApplySorting()
            .ToHistoricalEventSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return  Result<PaginatedList<HistoricalEventSummaryDto>>.Success(paginated);
    }
}
