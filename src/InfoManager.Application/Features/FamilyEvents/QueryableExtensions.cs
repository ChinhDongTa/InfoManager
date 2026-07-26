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
                 EventType: fe.EventType
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
                 EventName: fe.EventType.ToDisplayName()
             ));
    }
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