using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.Application.Features.Experiences;

public static class QueryableExtensions
{
    public static IQueryable<ExperienceDto> ToQueryDto(this IQueryable<Experience> query)
    {
        return query.Select(e => new ExperienceDto(
                e.Id,
                e.Content,
                e.Description,
                e.ExperienceDate,
                e.Category != null ? e.Category.Name : null,
                e.CategoryId));
    }

    public static IQueryable<ExperienceSummaryDto> ToSummaryDto(this IQueryable<Experience> query)
    {
        return query.Select(e => new ExperienceSummaryDto(
                e.Id,
                e.Content,
                e.ExperienceDate));
    }

    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter.
    /// </summary>
    /// <param name="query">The queryable collection of Experience entities to sort.</param>
    /// <param name="sortBy">The field (content, date) to sort by. If null or empty, defaults to sorting by ExperienceDate.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of Experience entities.</returns>
    public static IQueryable<Experience> ApplySorting(this IQueryable<Experience> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(e => e.ExperienceDate);
        }

        return sortBy.ToLower() switch
        {
            "content" => ascending ? query.OrderBy(e => e.Content) : query.OrderByDescending(e => e.Content),
            "date" => ascending ? query.OrderBy(e => e.ExperienceDate) : query.OrderByDescending(e => e.ExperienceDate),
            _ => query
        };
    }
}