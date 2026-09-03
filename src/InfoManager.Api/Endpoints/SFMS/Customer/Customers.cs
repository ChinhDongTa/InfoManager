namespace InfoManager.Api.Endpoints.SFMS.Customer;

public class Customers : EndpointGroupBase
{
    public override string? GroupName => "Customers";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        api.MapGet(GetCustomerByIdAsync, "{id}");
        api.MapGet(GetCustomersAsync);
        api.MapGet(SearchCustomersAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCustomerAsync);
        api.MapPut(UpdateCustomerAsync, "{id}");
        api.MapDelete(DeleteCustomerAsync, "{id}");
    }

    public async Task<IResult> GetCustomerByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCustomerByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCustomersAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCustomersQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCustomersAsync([AsParameters] SearchCustomerRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CustomerMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCustomerAsync(CreateCustomerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CustomerMappings.ToCreateCommand(request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> UpdateCustomerAsync(string id, UpdateCustomerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CustomerMappings.ToUpdateCommand(id, request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteCustomerAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCustomerCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}