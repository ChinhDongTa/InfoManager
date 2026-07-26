using InfoManager.Application.Features.Categories.Queries.GetCategories;
using InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;
using InfoManager.Application.Features.FamilyMembers.Queries.GetFamilyMembers;
using InfoManager.Application.Features.FamilyRelations.Queries.GetFamilyRelations;
using InfoManager.Enum;
using InfoManager.Shared.Dtos.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InfoManager.Api.Endpoints.Common;

public class SelectList: EndpointGroupBase
{
    public override string GroupName => "SelectList";
    public override void Map(RouteGroupBuilder group)
    {
        group.MapGet(GetSLEnums, "{enumName}");
        group.MapGet(GetSlCategoriesAsync, "category");
        group.MapGet(GetSlFamilyEventByMemberIdAsync, "FamilyEvent/{familyMemberId}");
        group.MapGet(GetSlFamilyRelationsAsync, "FamilyRelation");
        group.MapGet(GetSlFamilyMemberAsync, "FamilyMember");
    }

    /// <summary>
    /// Get a list of select list items for a given enum name.
    /// </summary>
    /// <param name="enumName">The name of the enum</param>
    /// <returns>A list of select list items</returns>
    public async Task<Results<Ok<IEnumerable<SelectListItemDto>>, NotFound>> GetSLEnums([FromRoute] string enumName)
    {
        // Dùng reflection để lấy enum theo tên
        var enumType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.IsEnum && t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));
        if (enumType == null)
            return TypedResults.NotFound();
        // Lấy tất cả giá trị của enum
        var values = System.Enum.GetValues(enumType);

        // Map: Id = giá trị int của enum (dạng string), Name = DisplayName (ưu tiên [Display] → [Description] → tên enum)
        var result = values.Cast<System.Enum>()
            .Select(v => new SelectListItemDto(
                v.ToInt().ToString(),      // Id = giá trị int
                v.ToDisplayName()          // Name = tên hiển thị đẹp
            ));

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Get a list of categories for a select list, optionally filtered by group and keyname.
    /// </summary>
    /// <param name="sender">The mediator instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <param name="group">The group to filter categories by</param>
    /// <param name="keyname">The keyname to filter categories by</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    public async Task<IResult> GetSlCategoriesAsync([FromServices] ISender sender, CancellationToken cancellationToken, string? group = null, string? keyname = null)
    {
        var query = new GetSelectListCategoriesQuery(group, keyname);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a select list of family events for a specific family member.
    /// </summary>
    /// <param name="familyMemberId">The unique identifier of the family member</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    public async Task<IResult> GetSlFamilyEventByMemberIdAsync(string familyMemberId, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(familyMemberId))
        {
            return Results.BadRequest(ErrorHelpers.GetErrorNotEmpty(nameof(familyMemberId)));
        }
        var query = new GetSelectListFamilyEventQuery(familyMemberId);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a list of family relations for selection purposes.
    /// </summary>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Http 200 OK if the family relations are found.</returns>
    /// <response code="200">Returns the list of family relations.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetSlFamilyRelationsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetSelectListFamilyRelationsQuery();
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }


    public async Task<IResult> GetSlFamilyMemberAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetSelectListFamilyMemberQuery();
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
}