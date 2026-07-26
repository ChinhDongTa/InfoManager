using InfoManager.Application.Features.Transactions.Commands;
using InfoManager.Application.Features.Transactions.Queries.GetTransactions;
using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Api.Endpoints;
/// <summary>
/// Represents the API endpoints for managing transactions.
/// </summary>
public class Transactions : EndpointGroupBase
{
    public override string GroupName => "Transactions";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetTransactionsPendingAsync,"pending");
        api.MapGet(GetTransactionsAsync);
        api.MapGet(GetTopTransactionsAsync, "top/{top}");
        api.MapGet(GetTransactionByIdAsync, "{id}");
        api.MapGet(SearchTransactionsAsync, "search");
        
        //=============Data Manipulation Endpoints================
        api.MapPost(CreateTransactionAsync);
        api.MapPut(UpdateTransactionAsync, "{id}");
        api.MapDelete(DeleteTransactionAsync, "{id}");
    }

    /// <summary>
    /// Get all pending transactions
    /// </summary>
    /// <param name="sender">The mediator instance to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the query.</returns>
    /// <response code="200">Returns the list of pending transactions.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authorized.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetTransactionsPendingAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var query = new GetTransactionPendingQuery();
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a paginated list of transactions based on the specified page number and page size.
    /// </summary>
    /// <param name="sender">The mediator instance to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>The result of the query.</returns>
    public async Task<IResult> GetTransactionsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20)
    {
        var query = new GetTransactionsQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get the top transactions based on the specified number.
    /// </summary>
    /// <param name="sender">The mediator instance to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="top">The number of top transactions to retrieve.</param>
    /// <returns>The result of the query.</returns>
    public async Task<IResult> GetTopTransactionsAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, int top = 5)
    {
        var query = new GetTopTransactionsQuery(top);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }


    /// <summary>
    /// Get a transaction by its unique identifier
    /// </summary>
    /// <param name="sender">The mediator instance to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the transaction.</param>
    /// <returns>The result of the query.</returns>
    public async Task<IResult> GetTransactionByIdAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id)
    {
        var query = new GetTransactionByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Search for transactions based on various criteria
    /// </summary>
    /// <param name="sender">The mediator instance to send the query.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="request">The search criteria for transactions.</param>
    /// <returns>The result of the query.</returns>
    public async Task<IResult> SearchTransactionsAsync(
        [FromServices] ISender sender,
        [FromServices] IUser user,
        CancellationToken cancellationToken,
        [AsParameters] SearchTransactionRequest request)
    {
        var query = new SearchTransactionQuery
        {
            MinAmount = request.MinAmount,
            MaxAmount = request.MaxAmount,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CategoryId = request.CategoryId,
            PaymentMethod = request.PaymentMethod,
            TransactionType = request.TransactionType,
            SortBy = request.SortBy,
            Ascending = request.Ascending,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new transaction based on the provided command.
    /// </summary>
    /// <param name="sender">The mediator instance to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="command">The command containing the transaction details.</param>
    /// <returns>The result of the command.</returns>
    public async Task<IResult> CreateTransactionAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, [FromBody] CreateTransactionCommand command)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Updates an existing transaction based on the provided command and transaction ID.
    /// </summary>
    /// <param name="sender">The mediator instance to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the transaction.</param>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<IResult> UpdateTransactionAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id, [FromBody] UpdateTransactionCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest("Id in the URL does not match Id in the request body.");
        }
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes a transaction based on the provided transaction ID.
    /// </summary>
    /// <param name="sender">The mediator instance to send the command.</param>
    /// <param name="user">The current user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="id">The unique identifier of the transaction.</param>
    /// <returns>The result of the command.</returns>
    public async Task<IResult> DeleteTransactionAsync([FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken, string id)
    {
        var command = new DeleteTransactionCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}