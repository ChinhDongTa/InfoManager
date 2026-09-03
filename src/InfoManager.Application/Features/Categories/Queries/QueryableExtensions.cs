using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.Application.Features.Categories.Queries;

public static class QueryableExtensions
{
    public static IQueryable<CategoryDto> ToCategoryDto(this IQueryable<Category> query)
    {
        return query.Select(c => new CategoryDto(c.Id, c.Name, c.Group, c.KeyName));
    }
    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by Name in ascending order. 
    /// If sortBy is "name" or "group", it sorts accordingly in either ascending or descending order based on the ascending parameter.
    /// </summary>
    /// <param name="query">The queryable collection of Category entities to sort.</param>
    /// <param name="sortBy">The field (name, group) to sort by. If null or empty, defaults to sorting by Name.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of Category entities.</returns>
    public static IQueryable<Category> ApplySorting(this IQueryable<Category> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderBy(c => c.Name);
        }

        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
            "group" => ascending ? query.OrderBy(c => c.Group) : query.OrderByDescending(c => c.Group),
            _ => query
        };
    }
}