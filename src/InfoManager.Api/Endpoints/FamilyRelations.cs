using InfoManager.Application.Features.FamilyRelations.Commands;
using InfoManager.Application.Features.FamilyRelations.Queries.GetFamilyRelations;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing family relations.
/// </summary>
public class FamilyRelations : EndpointGroupBase
{
    public override string GroupName => "FamilyRelations";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        api.MapGet(GetFamilyRelationsAsync);
        api.MapGet(GetFamilyRelationByIdAsync, "{id}");
        api.MapGet(GetSelectListFamilyRelationsAsync, "select-list");
        api.MapPost(CreateFamilyRelationAsync);
        api.MapPut(UpdateFamilyRelationAsync, "{id}");
        api.MapDelete(DeleteFamilyRelationAsync, "{id}");
    }

    /// <summary>
    /// Get all family relations, optionally filtered by name.
    /// </summary>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <param name="name">Optional name filter for family relations.</param>
    /// <returns>Http 200 OK if the family relations are found.</returns>
    /// <response code="200">Returns the list of family relations.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyRelationsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken,string? name)
    {
        var query = new GetFamilyRelationsQuery(name);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a family relation by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the family relation.</param>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Http 200 OK if the family relation is found.</returns>
    /// <response code="200">Returns the family relation.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the family relation is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetFamilyRelationByIdAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetFamilyRelationByIdQuery(id);
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
    public async Task<IResult> GetSelectListFamilyRelationsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetSelectListFamilyRelationsQuery();
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new family relation.
    /// </summary>
    /// <param name="command">The command containing the details of the family relation to create.</param>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Http 201 Created if the family relation is created successfully.</returns>
    /// <response code="201">If the family relation is created successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateFamilyRelationAsync([FromBody] CreateFamilyRelationCommand command,
                                                         [FromServices] ISender sender,
                                                         CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult(GroupName);
    }

    /// <summary>
    /// Updates an existing family relation.
    /// </summary>
    /// <param name="id">The unique identifier of the family relation to update.</param>
    /// <param name="command">The command containing the updated details of the family relation.</param>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Http 204 No Content if the update is successful.</returns>
    /// <response code="204">If the family relation is updated successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the family relation is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateFamilyRelationAsync(string id,
                                                         [FromBody] UpdateFamilyRelationCommand command,
                                                         [FromServices] ISender sender,
                                                         [FromServices] IUser user,
                                                         CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("Id in URL does not match Id in request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a family relation by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the family relation to delete.</param>
    /// <param name="sender">The mediator instance used to send queries and commands.</param>
    /// <param name="user">The current user context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Http 204 No Content if the deletion is successful.</returns>
    /// <response code="204">If the family relation is deleted successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the family relation is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteFamilyRelationAsync(string id,
                                                         [FromServices] ISender sender,
                                                         [FromServices] IUser user,
                                                         CancellationToken cancellationToken)
    {
        var command = new DeleteFamilyRelationCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}
