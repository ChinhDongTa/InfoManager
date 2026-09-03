using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.Families;

namespace InfoManager.Application.Features.Families.Queries;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by Created date in descending order.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">The field (name,representative) to sort by. If null or empty, defaults to sorting by Created date.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of Family entities.</returns>
    public static IQueryable<Family> ApplySorting(this IQueryable<Family> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(f => f.Created);
        }

        return sortBy.ToLower() switch
        {
            "name" => ascending? query.OrderBy(f => f.Name) : query.OrderByDescending(f => f.Name), 
            "representative" => ascending? query.OrderBy(f => f.Representative!.FullName) : query.OrderByDescending(f => f.Representative!.FullName),
            _ => query.OrderByDescending(f => f.Created)
        };
    }
    public static IQueryable<FamilySummaryDto> ToFamilySummaryDto(this IQueryable<Family> query)
    {
        return query.Select(f => new FamilySummaryDto(
            Id: f.Id,
            Name: f.Name,
            Email: f.Email));
    }
    public static IQueryable<FamilyDto> ToFamilyDto(this IQueryable<Family> query)
    {
        return query.Select(f => new FamilyDto(
            Id: f.Id,
            Name: f.Name,
            RepresentativeName: f.Representative!= null ? f.Representative.FullName : null,
            Address: f.Address,
            Email: f.Email));
    }
}
