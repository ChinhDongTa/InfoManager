using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.Application.Features.FamilyEventOccurrences;

public static class QueryableExtensions
{
    public static IQueryable<FamilyEventOccurrenceDto> ToFamilyEventOccurrenceDto(this IQueryable<FamilyEventOccurrence> query)
    {
        return query.Select(e => new FamilyEventOccurrenceDto(
            Id: e.Id,
            FamilyEventId: e.FamilyEventId,
            EventTitle: e.FamilyEvent != null ? e.FamilyEvent.Title : null,
            MemberName: e.FamilyEvent != null && e.FamilyEvent.FamilyMember != null ? e.FamilyEvent.FamilyMember.FullName : null,
            OccurrenceDate: e.OccurrenceDate,
            Location: e.Location,
            Notes: e.Notes,
            Cost: e.Cost
        ));
    }

    public static IQueryable<FamilyEventOccurrenceSummaryDto> ToFamilyEventOccurrenceSummaryDto(this IQueryable<FamilyEventOccurrence> query)
    {
        return query.Select(e => new FamilyEventOccurrenceSummaryDto(
            Id: e.Id,
            EventTitle: e.FamilyEvent != null ? e.FamilyEvent.Title : null,
            MemberName: e.FamilyEvent != null && e.FamilyEvent.FamilyMember != null ? e.FamilyEvent.FamilyMember.FullName : null,
            OccurrenceDate: e.OccurrenceDate,
            Location: e.Location,
            Cost: e.Cost
        ));
    }

    /// <summary>
    /// Applies sorting to the query based on the specified sortBy parameter. If sortBy is null or empty, it defaults to sorting by OccurrenceDate in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of FamilyEventOccurrence entities to sort.</param>
    /// <param name="sortBy">The field (occurrencedate, eventtitle, membername) to sort by. If null or empty, defaults to sorting by OccurrenceDate.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of FamilyEventOccurrence entities.</returns>
    public static IQueryable<FamilyEventOccurrence> ApplySorting(this IQueryable<FamilyEventOccurrence> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(e => e.OccurrenceDate);
        }
        return sortBy.ToLower() switch
        {
            "occurrencedate" => ascending ? query.OrderBy(e => e.OccurrenceDate) : query.OrderByDescending(e => e.OccurrenceDate),
            "eventtitle" => ascending ? query.OrderBy(e => e.FamilyEvent != null ? e.FamilyEvent.Title : null) : query.OrderByDescending(e => e.FamilyEvent != null ? e.FamilyEvent.Title : null),
            "membername" => ascending ? query.OrderBy(e => e.FamilyEvent != null && e.FamilyEvent.FamilyMember != null ? e.FamilyEvent.FamilyMember.FullName : null) : query.OrderByDescending(e => e.FamilyEvent != null && e.FamilyEvent.FamilyMember != null ? e.FamilyEvent.FamilyMember.FullName : null),
            _ => query.OrderByDescending(e => e.OccurrenceDate),
        };
    }
}