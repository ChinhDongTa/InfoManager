using InfoManager.Application.Features.FamilyMembers.Commands;
using InfoManager.Application.Features.FamilyMembers.Queries.GetFamilyMembers;
using InfoManager.Shared.Dtos.FamilyMembers;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing family members.
/// </summary>
public class FamilyMembers : EndpointGroupBase
{
    public override string GroupName => "FamilyMembers";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        api.MapGet(GetFamilyMembersAsync);
        api.MapGet(GetFamilyMemberByIdAsync, "{id}");
        api.MapPost(CreateFamilyMemberAsync);
        api.MapPut(UpdateFamilyMemberAsync, "{id}");
        api.MapDelete(DeleteFamilyMemberAsync, "{id}");

    }

    /// <summary>
    /// Get a list of family members based on the provided search criteria.
    /// </summary>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <param name="request">The search criteria for family members</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the list of family members.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If no family members are found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyMembersAsync(
        [FromServices] ISender sender,
        [FromServices] IUser user,
        CancellationToken cancellationToken,
        [AsParameters] SearchFamilyMemberRequest request)
    {
        var query = new GetFamilyMembersQuery(request.FullName, request.EventType, request.PageNumber, request.PageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a family member by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the family member</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the family member.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family member is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyMemberByIdAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetFamilyMemberByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new family member based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the details of the family member to create</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the created family member.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family member is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateFamilyMemberAsync([FromBody] CreateFamilyMemberCommand command, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult(GroupName);
    }

    /// <summary>
    /// Updates an existing family member based on the provided command and ID.
    /// </summary>
    /// <param name="id">The unique identifier of the family member to update</param>
    /// <param name="command">The command containing the updated details of the family member</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">Returns the updated family member.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family member is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateFamilyMemberAsync(string id, [FromBody] UpdateFamilyMemberCommand command, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("ID in the URL does not match ID in the request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a family member based on the provided ID.
    /// </summary>
    /// <param name="id">The unique identifier of the family member to delete</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">If the family member was successfully deleted.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family member is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteFamilyMemberAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var command = new DeleteFamilyMemberCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}
