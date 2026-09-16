using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Application.Features.FamilyEvents;

public static class QueryableExtensions

{
    public static IQueryable<FamilyEventDto> ToQueryDto(this IQueryable<FamilyEvent> query)
    {
        // For example, filter by user ID or roles
        return query.Select(fe => new FamilyEventDto
             (
                 Id: fe.Id,
                 FamilyMemberFullName: fe.FamilyMember != null ? fe.FamilyMember.FullName : string.Empty,
                 EventDate: fe.EventDate,
                 Title: fe.Title,
                 EventName: fe.EventType.ToDisplayName(),
                 Location: fe.Location,
                 FamilyMemberId: fe.FamilyMemberId,
                 EventType: fe.EventType,
                 IsActive: fe.IsActive
             ));
    }

    public static IQueryable<FamilyEventSummaryDto> ToQuerySummaryDto(this IQueryable<FamilyEvent> query)
    {
        // For example, filter by user ID or roles
        return query.Select(fe => new FamilyEventSummaryDto
             (
                 Id: fe.Id,
                 FamilyMemberFullName: fe.FamilyMember != null ? fe.FamilyMember.FullName : string.Empty,
                 EventDate: fe.EventDate,
                 EventName: fe.EventType.ToDisplayName(),
                 IsActive: fe.IsActive
             ));
    }

    /// <summary>
    /// Applies sorting to the FamilyEvent query based on the provided sortBy parameter.
    /// </summary>
    /// <param name="query">The queryable collection of FamilyEvent entities to sort.</param>
    /// <param name="sortBy">The field (title, date) to sort by. If null or empty, defaults to sorting by EventDate.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of FamilyEvent entities.</returns>
    public static IQueryable<FamilyEvent> ApplySorting(this IQueryable<FamilyEvent> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(fe => fe.EventDate);
        }

        return sortBy.ToLower() switch
        {
            "title" => ascending ? query.OrderBy(fe => fe.Title) : query.OrderByDescending(fe => fe.Title),
            "date" => ascending ? query.OrderBy(fe => fe.EventDate) : query.OrderByDescending(fe => fe.EventDate),
            _ => query
        };
    }
}