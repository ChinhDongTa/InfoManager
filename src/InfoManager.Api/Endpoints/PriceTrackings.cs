using InfoManager.Application.Features.PriceTrackings.Commands;
using InfoManager.Application.Features.PriceTrackings.Queries.GetPriceTrackings;
using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing price trackings.
/// </summary>
public class PriceTrackings : EndpointGroupBase
{
    public override string GroupName => "PriceTrackings";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        api.MapGet(GetPriceTrackingsAsync);
        api.MapGet(GetTopPriceTrackingsAsync,"top/{top}");
        api.MapGet(SearchPriceTrackingsAsync,"search");
        api.MapGet(GetPriceTrackingByIdAsync, "{id}");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePriceTrackingAsync);
        api.MapPut(UpdatePriceTrackingAsync, "{id}");
        api.MapDelete(DeletePriceTrackingAsync, "{id}");

    }

    /// <summary>
    /// Get a paginated list of price trackings.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <returns>A paginated list of price trackings.</returns>
    /// <response code="200">Returns a paginated list of price trackings.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetPriceTrackingsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20)
    {
        var query = new GetPriceTrackingsQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get the top N price trackings.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="top">The number of top price trackings to retrieve.</param>
    /// <returns>A list of the top N price trackings.</returns>
    /// <response code="200">Returns a list of the top N price trackings.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetTopPriceTrackingsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, int top = 5)
    {
        var query = new GetTopPriceTrackingsQuery(top);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Search price trackings based on the provided search criteria.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="request">The search request.</param>
    /// <returns>A paginated list of price trackings matching the search criteria.</returns>
    /// <response code="200">Returns a paginated list of price trackings matching the search criteria.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> SearchPriceTrackingsAsync(
        [FromServices] ISender sender,
        [FromServices] IUser user,
        CancellationToken cancellationToken,
        [AsParameters] SearchPriceTrackingRequest request)
    {
        var query = new SearchPriceTrackingQuery
        {
            SearchTerm = request.SearchTerm,
            MinPrice = request.MinPrice,
            MaxPrice = request.MaxPrice,
            SortBy = request.SortBy,
            Ascending = request.Ascending,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a price tracking by its unique identifier.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the price tracking.</param>
    /// <returns>The price tracking with the specified identifier.</returns>
    /// <response code="200">Returns the price tracking with the specified identifier.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the price tracking is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetPriceTrackingByIdAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id)
    {
        var query = new GetPriceTrackingByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new price tracking entry.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="command">The command containing the details of the price tracking to create.</param>
    /// <returns>The result of the create operation.</returns>
    /// <response code="201">If the price tracking was created successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreatePriceTrackingAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, [FromBody] CreatePriceTrackingCommand command)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Updates an existing price tracking entry.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the price tracking to update.</param>
    /// <param name="command">The command containing the updated details of the price tracking.</param>
    /// <returns>The result of the update operation.</returns>
    /// <response code="204">If the price tracking was updated successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the price tracking is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdatePriceTrackingAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id, [FromBody] UpdatePriceTrackingCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("Id in the URL does not match Id in the request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a price tracking entry by its unique identifier.
    /// </summary>
    /// <param name="sender">The mediator sender.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the price tracking to delete.</param>
    /// <returns>The result of the delete operation.</returns>
    /// <response code="204">If the price tracking was deleted successfully.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="404">If the price tracking is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeletePriceTrackingAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id)
    {
        var command = new DeletePriceTrackingCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}
