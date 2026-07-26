using InfoManager.Application.Features.FamilyEvents.Commands;
using InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing family events.
/// </summary>
public class FamilyEvents : EndpointGroupBase
{
    public override string GroupName => "FamilyEvents";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        api.MapGet(GetFamilyEventsAsync);
        api.MapGet(GetFamilyEventByIdAsync, "{id}");
        api.MapGet(GetSelectListFamilyEventAsync, "{familyMemberId}/select-list");
        api.MapPost(CreateFamilyEventAsync);
        api.MapPut(UpdateFamilyEventAsync, "{id}");
        api.MapDelete(DeleteFamilyEventAsync, "{id}");
    }

    /// <summary>
    /// Get a list of family events with optional filtering by event type and pagination.
    /// </summary>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <param name="request">The search request</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the requested experience.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the experience is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyEventsAsync(
        [FromServices] ISender sender,
        [FromServices] IUser user,
        CancellationToken cancellationToken,
        [AsParameters] SearchFamilyEventRequest request)
    {
        var query = new GetFamilyEventsQuery(request.EventType, request.PageNumber, request.PageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a family event by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the family event</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the requested family event.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyEventByIdAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetFamilyEventByIdQuery(id);
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
    public async Task<IResult> GetSelectListFamilyEventAsync(string familyMemberId, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(familyMemberId))
        {
            return Results.BadRequest(ErrorHelpers.GetErrorNotEmpty(nameof(familyMemberId)));
        }
        var query = new GetSelectListFamilyEventQuery(familyMemberId);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new family event.
    /// </summary>
    /// <param name="command">The command containing the details of the family event to create</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the created family event.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateFamilyEventAsync([FromBody] CreateFamilyEventCommand command, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult(GroupName);
    }

    /// <summary>
    /// Updates an existing family event.
    /// </summary>
    /// <param name="id">The unique identifier of the family event to update</param>
    /// <param name="command">The command containing the updated details of the family event</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">Returns the updated family event.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateFamilyEventAsync(
        string id,
        [FromBody] UpdateFamilyEventCommand command,
        [FromServices] ISender sender,
        [FromServices] IUser user,
        CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("ID in the URL does not match ID in the request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a family event by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the family event to delete</param>
    /// <param name="sender">The mediator instance</param>
    /// <param name="user">The user instance</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">If the family event was successfully deleted.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the family event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteFamilyEventAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var command = new DeleteFamilyEventCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}
