namespace InfoManager.Api.Endpoints.SFMS.Customer;

public class CustomerCares : EndpointGroupBase
{
    public override string? GroupName => "CustomerCares";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCustomerCareByIdAsync, "{id}");
        api.MapGet(GetCustomerCaresAsync);
        api.MapGet(SearchCustomerCaresAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCustomerCareAsync);
        api.MapPut(UpdateCustomerCareAsync, "{id}");
        api.MapDelete(DeleteCustomerCareAsync, "{id}");
    }

    public async Task<IResult> GetCustomerCareByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCustomerCareByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCustomerCaresAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCustomerCaresQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCustomerCaresAsync([AsParameters] SearchCustomerCareRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CustomerCareMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCustomerCareAsync(CreateCustomerCareRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CustomerCareMappings.ToCreateCommand(request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> UpdateCustomerCareAsync(string id, UpdateCustomerCareRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CustomerCareMappings.ToUpdateCommand(id, request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteCustomerCareAsync(string id, [FromServices] ISender sender, [FromServices]IUser user , CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCustomerCareCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}