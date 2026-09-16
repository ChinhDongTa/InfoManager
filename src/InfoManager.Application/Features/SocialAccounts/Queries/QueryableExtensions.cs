using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.Application.Features.SocialAccounts.Queries;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the query based on the provided sortBy parameter. If sortBy is null or empty, it defaults to sorting by Created date in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of SocialAccount entities to sort.</param>
    /// <param name="sortBy">The field (provider, displayName, isPrimary) to sort by. If null or empty, defaults to sorting by Created date in descending order.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of SocialAccount entities.</returns>
    public static IQueryable<SocialAccount> ApplySorting(this IQueryable<SocialAccount> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(s => s.Created);
        }

        return sortBy.ToLower() switch
        {
            "provider" => ascending ? query.OrderBy(s => s.Provider) : query.OrderByDescending(s => s.Provider),
            "displayname" => ascending ? query.OrderBy(s => s.DisplayName) : query.OrderByDescending(s => s.DisplayName),
            "isprimary" => ascending ? query.OrderBy(s => s.IsPrimary) : query.OrderByDescending(s => s.IsPrimary),
            _ => query.OrderByDescending(s => s.Created),
        };
    }

    public static IQueryable<SocialAccountDto> ToSocialAccountDto(this IQueryable<SocialAccount> query)
    {
        return query.Select(s => new SocialAccountDto(
            Id: s.Id,
            UserId: s.UserId,
            Provider: s.Provider,
            ProviderAccountId: s.ProviderAccountId,
            DisplayName: s.DisplayName,
            IsPrimary: s.IsPrimary,
            HomepageUrl: s.HomepageUrl
        ));
    }

    public static IQueryable<SocialAccountSummaryDto> ToSocialAccountSummaryDto(this IQueryable<SocialAccount> query)
    {
        return query.Select(s => new SocialAccountSummaryDto(
            Id: s.Id,
            UserName: s.UserId,
            Provider: s.Provider,
            DisplayName: s.DisplayName,
            IsPrimary: s.IsPrimary
        ));
    }
}