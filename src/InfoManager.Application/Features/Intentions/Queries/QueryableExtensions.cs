using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Application.Features.Intentions.Queries;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the IQueryable<Intention> based on the specified sortBy field and order.
    /// </summary>
    /// <param name="query">The queryable collection of Intention entities to sort.</param>
    /// <param name="sortBy">The field (content, priority, isCompleted) to sort by. If null or empty, defaults to sorting by PlannDate in descending order.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of Intention entities.</returns>
    public static IQueryable<Intention> ApplySorting(this IQueryable<Intention> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(i => i.PlannDate); // No sorting applied
        }
        return sortBy.ToLower() switch
        {
            "content" => ascending ? query.OrderBy(i => i.Content) : query.OrderByDescending(i => i.Content),
            "priority" => ascending ? query.OrderBy(i => i.Priority) : query.OrderByDescending(i => i.Priority),
            "isCompleted" => ascending ? query.OrderBy(i => i.IsCompleted) : query.OrderByDescending(i => i.IsCompleted),
            _ => query // No sorting applied for unrecognized sortBy values
        };
    }

    public static IQueryable<IntentionDto> ToIntentionDto(this IQueryable<Intention> query)
    {
        return query.Select(i => new IntentionDto(
            i.Id,
            i.Content,
            i.Description,
            i.PlannDate.ToLocalDateTime(),
            i.IsCompleted,
            i.Priority.ToDisplayName(),
            i.Category != null ? i.Category.Name : null,
            i.CategoryId,
            i.Priority
        ));
    }

    public static IQueryable<IntentionSummaryDto> ToIntentionSummaryDto(this IQueryable<Intention> query)
    {
        return query.Select(i => new IntentionSummaryDto(
            i.Id,
            i.Content,
            i.IsCompleted,
            i.Priority.ToDisplayName()
        ));
    }
}