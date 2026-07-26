using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.Application.Features.Categories.Queries;

public static class QueryableExtensions
{
    public static IQueryable<CategoryDto> ToCategoryDto(this IQueryable<Category> query)
    {
        return query.Select(c => new CategoryDto(c.Id, c.Name, c.Group, c.KeyName));
    }
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