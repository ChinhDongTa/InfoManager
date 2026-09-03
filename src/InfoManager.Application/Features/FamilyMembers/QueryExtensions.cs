using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.FamilyMembers;

namespace InfoManager.Application.Features.FamilyMembers;

public static class QueryExtensions
{
    public static IQueryable<FamilyMemberDto> ToFamilyMemberDto(this IQueryable<FamilyMember> query)
    {
        return query.Select(fm => new FamilyMemberDto(
            fm.Id.ToString(),
            fm.FullName,
            fm.FamilyRelation != null ? fm.FamilyRelation.Name : null,
            fm.BirthDate,
            fm.DeathDate,
            fm.Gender.ToDisplayName(),
            fm.Email,
            fm.PhoneNumber,
            fm.Note,
            fm.FamilyRelationId,
            fm.Gender,
            fm.FamilyId
        ));
    }
    public static IQueryable<FamilyMemberSummaryDto> ToFamilyMemberSummaryDto(this IQueryable<FamilyMember> query)
    {
        return query.Select(fm => new FamilyMemberSummaryDto(
            fm.Id.ToString(),
            fm.FullName,
            fm.FamilyRelation != null ? fm.FamilyRelation.Name : null,
            fm.BirthDate
        ));
    }
    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by BirthDate and then by FullName.
    /// </summary>
    /// <param name="query">The queryable collection of FamilyMember entities to sort.</param>
    /// <param name="sortBy">The field (fullname, birthdate) to sort by. If null or empty, defaults to sorting by BirthDate and then by FullName.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of FamilyMember entities.</returns>
    public static IQueryable<FamilyMember> ApplySorting(this IQueryable<FamilyMember> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderBy(fm => fm.BirthDate).ThenBy(fm => fm.FullName);
        }

        return sortBy.ToLower() switch
        {
            "fullname" => ascending ? query.OrderBy(fm => fm.FullName) : query.OrderByDescending(fm => fm.FullName),
            "birthdate" => ascending ? query.OrderBy(fm => fm.BirthDate) : query.OrderByDescending(fm => fm.BirthDate),
            _ => query
        };
    }
}