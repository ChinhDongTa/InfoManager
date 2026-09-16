using InfoManager.Shared.Dtos.UserProfiles;

namespace InfoManager.Application.Features.UserProfiles;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the UserProfile queryable, ordering by the Created property in descending order.
    /// </summary>
    /// <param name="query">The queryable collection of UserProfile entities to sort.</param>
    /// <returns>The sorted queryable collection of UserProfile entities.</returns>
    public static IQueryable<UserProfile> ApplySorting(this IQueryable<UserProfile> query)
    {
        return query.OrderByDescending(u => u.Created);
    }

    public static IQueryable<UserProfileDto> ToUserProfileDto(this IQueryable<UserProfile> query)
    {
        return query.Select(u => new UserProfileDto(
            Id: u.Id,
            UserId: u.UserId,
            FamilyMemberName: u.FamilyMember == null ? null : u.FamilyMember.FullName,
            FamilyId: u.FamilyId,
            Notes: u.Notes,
            ImageUrl: u.ImageUrl));
    }
}