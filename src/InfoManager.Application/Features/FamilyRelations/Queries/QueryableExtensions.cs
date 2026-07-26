using InfoManager.Shared.Dtos.FamilyRelations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoManager.Application.Features.FamilyRelations.Queries;

public static class QueryableExtensions
{
    public static IQueryable<FamilyRelationDto> ToFamilyRelationDto(this IQueryable<FamilyRelation> query)
    {
        return query.Select(fr => new FamilyRelationDto
        (
            Id : fr.Id,
            Name : fr.Name,
            Description : fr.Description
        ));
    }
    public static IQueryable<FamilyRelation> ApplySorting(this IQueryable<FamilyRelation> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderBy(fr => fr.Name);
        }

        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(fr => fr.Name) : query.OrderByDescending(fr => fr.Name),
            _ => query
        };
    }

}
