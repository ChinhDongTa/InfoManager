using InfoManager.Application.Features.HistoricalEvents.Commands;
using InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;
using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing historical events.
/// </summary>
public class HistoricalEvents : EndpointGroupBase
{
    public override string GroupName => "HistoricalEvents";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        api.MapGet(GetHistoricalEventsAsync);
        api.MapGet(GetHistoricalEventByIdAsync, "{id}");
        api.MapGet(GetNextMonthHistoricalEventsAsync, "next/{numMonths}");
        api.MapGet(SearchHistoricalEventsAsync, "search");
        api.MapPost(CreateHistoricalEventAsync);
        api.MapPut(UpdateHistoricalEventAsync, "{id}");
        api.MapDelete(DeleteHistoricalEventAsync, "{id}");
    }

    /// <summary>
    /// Get a paginated list of historical events.
    /// </summary>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <returns>A paginated list of historical events.</returns>
    /// <response code="200">Returns a paginated list of historical events.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetHistoricalEventsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20)
    {
        var query = new GetHistoricalEventsQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a historical event by its ID.
    /// </summary>
    /// <param name="id">The ID of the historical event.</param>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The historical event with the specified ID.</returns>
    /// <response code="200">Returns the historical event.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the historical event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetHistoricalEventByIdAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetHistoricalEventByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get the next month's historical events.
    /// </summary>
    /// <param name="top">The number of historical events to retrieve.</param>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of the next month's historical events.</returns>
    /// <response code="200">Returns a list of the next month's historical events.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetNextMonthHistoricalEventsAsync(int numMonths,
                                                                  [FromServices] ISender sender,
                                                                  [FromServices] IUser user,
                                                                  CancellationToken cancellationToken)
    {
        var query = new GetNextMonthHistoricalEventsQuery(numMonths);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Search historical events based on search term and date range.
    /// </summary>
    /// <param name="sender">The mediator instance used to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="request">The search request containing search term, date range, and pagination information.</param>
    /// <returns>A list of historical events matching the search criteria.</returns>
    /// <response code="200">Returns a list of historical events matching the search criteria.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> SearchHistoricalEventsAsync([FromServices] ISender sender,
                                                            [FromServices] IUser user,
                                                            CancellationToken cancellationToken,
                                                            [AsParameters] SearchHistoricalEventRequest request)
    {
        var query = new SearchHistoricalEventsQuery(request.SearchTerm, request.StartDate, request.EndDate, request.PageNumber, request.PageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new historical event.
    /// </summary>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="command">The command containing the details of the historical event to create.</param>
    /// <returns>The result of the create operation.</returns>
    /// <response code="201">If the historical event is created successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateHistoricalEventAsync([FromServices] ISender sender,
                                                          [FromServices] IUser user,
                                                          CancellationToken cancellationToken,
                                                          [FromBody] CreateHistoricalEventCommand command)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Updates an existing historical event.
    /// </summary>
    /// <param name="id">The ID of the historical event to update.</param>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="command">The command containing the updated details of the historical event.</param>
    /// <returns>The result of the update operation.</returns>
    /// <response code="200">If the historical event is updated successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateHistoricalEventAsync(string id,
                                                          [FromServices] ISender sender,
                                                          [FromServices] IUser user,
                                                          CancellationToken cancellationToken,
                                                          [FromBody] UpdateHistoricalEventCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("ID in the URL does not match ID in the request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a historical event by its ID.
    /// </summary>
    /// <param name="id">The ID of the historical event to delete.</param>
    /// <param name="sender">The mediator instance used to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the delete operation.</returns>
    /// <response code="204">If the historical event is deleted successfully.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the historical event is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteHistoricalEventAsync(string id,
                                                          [FromServices] ISender sender,
                                                          [FromServices] IUser user,
                                                          CancellationToken cancellationToken)
    {
        var command = new DeleteHistoricalEventCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}