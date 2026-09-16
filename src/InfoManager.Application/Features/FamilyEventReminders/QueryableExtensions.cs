using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.Application.Features.FamilyEventReminders;

public static class QueryableExtensions
{
    public static IQueryable<FamilyEventReminderDto> ToFamilyEventReminderDto(this IQueryable<FamilyEventReminder> query)
    {
        return query.Select(e => new FamilyEventReminderDto(Id: e.Id,
                                                            FamilyEventId: e.FamilyEventId,
                                                            EventTitle: e.FamilyEvent!.Title,
                                                            MemberName: e.FamilyEvent.FamilyMember!.FullName,
                                                            DaysBefore: e.DaysBefore,
                                                            RemindTime: e.RemindTime,
                                                            Channel: e.Channel,
                                                            IsEnabled: e.IsEnabled,
                                                            Note: e.Note));
    }

    public static IQueryable<FamilyEventReminderSummaryDto> ToFamilyEventReminderSummaryDto(this IQueryable<FamilyEventReminder> query)
    {
        return query.Select(e => new FamilyEventReminderSummaryDto(Id: e.Id,
                                                                    EventTitle: e.FamilyEvent!.Title,
                                                                    MemberName: e.FamilyEvent.FamilyMember!.FullName,
                                                                    DaysBefore: e.DaysBefore,
                                                                    RemindTime: e.RemindTime));
    }

    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by EventDate in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of FamilyEventReminder entities to sort.</param>
    /// <param name="sortBy">The field (eventdate, eventtitle, membername, daysbefore) to sort by. If null or empty, defaults to sorting by EventDate.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of FamilyEventReminder entities.</returns>
    public static IQueryable<FamilyEventReminder> ApplySorting(this IQueryable<FamilyEventReminder> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(e => e.FamilyEvent!.EventDate);
        }
        return sortBy.ToLower() switch
        {
            "eventdate" => ascending ? query.OrderBy(e => e.FamilyEvent!.EventDate) : query.OrderByDescending(e => e.FamilyEvent!.EventDate),
            "eventtitle" => ascending ? query.OrderBy(e => e.FamilyEvent!.Title) : query.OrderByDescending(e => e.FamilyEvent!.Title),
            "membername" => ascending ? query.OrderBy(e => e.FamilyEvent!.FamilyMember!.FullName) : query.OrderByDescending(e => e.FamilyEvent!.FamilyMember!.FullName),
            "daysbefore" => ascending ? query.OrderBy(e => e.DaysBefore) : query.OrderByDescending(e => e.DaysBefore),
            _ => query.OrderByDescending(e => e.FamilyEvent!.EventDate),
        };
    }
}