using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Application.Features.HistoricalEvents.Queries;

public static class QueryableExtensions
{
    public static IQueryable<HistoricalEventDto> ToHistoricalEventDto(this IQueryable<HistoricalEvent> query)
    {
        return query.Select(e => new HistoricalEventDto(
            Id: e.Id,
            EventDate: e.EventDate,
            Title: e.Title,
            EventName: e.EventType.ToDisplayName(),
            Location: e.Location,
            Summary: e.Summary,
            ReferenceSource: e.ReferenceSource,
            EventType: e.EventType
        ));
    }
    public static IQueryable<HistoricalEventSummaryDto> ToHistoricalEventSummaryDto(this IQueryable<HistoricalEvent> query)
    {
        return query.Select(e => new HistoricalEventSummaryDto(
            Id: e.Id,
            EventDate: e.EventDate,
            Title: e.Title,
            EventType: e.EventType.ToDisplayName()
        ));
    }
    /// <summary>
    /// Applies sorting to the HistoricalEvent query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by EventDate in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of HistoricalEvent entities to sort.</param>
    /// <param name="sortBy">The field (eventdate, title, eventtype) to sort by. If null or empty, defaults to sorting by EventDate in descending order.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of HistoricalEvent entities.</returns>
    public static IQueryable<HistoricalEvent> ApplySorting(this IQueryable<HistoricalEvent> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(e => e.EventDate);
        }
        return sortBy.ToLower() switch
        {
            "eventdate" => ascending ? query.OrderBy(e => e.EventDate) : query.OrderByDescending(e => e.EventDate),
            "title" => ascending ? query.OrderBy(e => e.Title) : query.OrderByDescending(e => e.Title),
            "eventtype" => ascending ? query.OrderBy(e => e.EventType) : query.OrderByDescending(e => e.EventType),
            _ => query.OrderByDescending(e => e.EventDate),
        };
    }
}
