using InfoManager.Application.Features.Intentions.Commands;
using InfoManager.Application.Features.Intentions.Queries.GetIntentions;
using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Api.Endpoints.Personal;
/// <summary>
/// Represents the API endpoints for managing intentions.
/// </summary>
public class Intentions : EndpointGroupBase
{
    public override string GroupName => "Intentions";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        api.MapGet(GetIntentionsAsync);
        api.MapGet(GetTopIntentionsAsync,"top/{top}");
        api.MapGet(SearchIntentionsAsync, "search");
        api.MapGet(GetIntentionByIdAsync, "{id}");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateIntentionAsync);
        api.MapPut(UpdateIntentionAsync, "{id}");
        api.MapDelete(DeleteIntentionAsync, "{id}");
    }

    /// <summary>
    /// Get a paginated list of intentions.
    /// </summary>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <returns>A paginated list of intentions.</returns>
    /// <response code="200">Returns a paginated list of intentions.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response> 
    public async Task<IResult> GetIntentionsAsync([FromServices] ISender sender,
                                                  [FromServices] IUser user,
                                                  CancellationToken cancellationToken,
                                                  int pageNumber,
                                                  int pageSize)
    {
        var query = new GetIntentionsQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get the top N intentions.
    /// </summary>
    /// <param name="top">The number of top intentions to retrieve.</param>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of the top N intentions.</returns>
    /// <response code="200">Returns a list of the top N intentions.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response> 
    public async Task<IResult> GetTopIntentionsAsync(int top,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken cancellationToken)
    {
        var query = new GetTopIntentionsQuery(top);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Search intentions based on the provided search criteria.
    /// </summary>
    /// <param name="request">The search criteria for intentions.</param>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A paginated list of intentions matching the search criteria.</returns>
    /// <response code="200">Returns a paginated list of intentions matching the search criteria.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> SearchIntentionsAsync([AsParameters] SearchIntentionRequest request,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken cancellationToken)
    {
        var searchQuery = new SearchIntentionsQuery
        {
            SearchTerm = request.SearchTerm,
            CategoryId = request.CategoryId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
        var result = await sender.Send(searchQuery, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get an intention by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the intention.</param>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The intention matching the specified identifier.</returns>
    /// <response code="200">Returns the intention matching the specified identifier.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the intention is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetIntentionByIdAsync(string id,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken cancellationToken)
    {
        var query = new GetIntentionByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new intention based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the details of the intention to be created.</param>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the create intention operation.</returns>
    /// <response code="200">If the intention is created successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response> 
    public async Task<IResult> CreateIntentionAsync([FromBody] CreateIntentionRequest request,
                                                    [FromServices] ISender sender,
                                                    [FromServices] IUser user,
                                                    CancellationToken cancellationToken)
    {
        var command = new CreateIntentionCommand
        {
            // Map properties from the request to the command
            Description = request.Description,
            CategoryId = request.CategoryId,
            Content = request.Content,
            IsCompleted = request.IsCompleted,
            PlannDate = request.PlannDate,
            Priority = request.Priority
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }

    /// <summary>
    /// Updates an existing intention based on the provided command and identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the intention to be updated.</param>
    /// <param name="command">The command containing the updated details of the intention.</param>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the update intention operation.</returns>
    /// <response code="200">If the intention is updated successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the intention is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateIntentionAsync(string id,
                                                    [FromBody] UpdateIntentionRequest request,
                                                    [FromServices] ISender sender,
                                                    [FromServices] IUser user,
                                                    CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("Id in URL does not match Id in request body.");
        }
        var command = new UpdateIntentionCommand
        {
            Id = request.Id,
            Description = request.Description,
            CategoryId = request.CategoryId,
            Content = request.Content,
            IsCompleted = request.IsCompleted,
            PlannDate = request.PlannDate,
            Priority = request.Priority
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes an existing intention based on the provided identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the intention to be deleted.</param>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the delete intention operation.</returns>
    /// <response code="200">If the intention is deleted successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the intention is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteIntentionAsync(string id,
                                                    [FromServices] ISender sender,
                                                    [FromServices] IUser user,
                                                    CancellationToken cancellationToken)
    {
        var command = new DeleteIntentionCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    } 
}