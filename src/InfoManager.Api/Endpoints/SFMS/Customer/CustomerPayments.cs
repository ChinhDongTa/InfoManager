namespace InfoManager.Api.Endpoints.SFMS.Customer;

public class CustomerPayments : EndpointGroupBase
{
    public override string GroupName => "CustomerPayments";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCustomerPaymentByIdAsync, "{id}");
        api.MapGet(GetCustomerPaymentsAsync);
        api.MapGet(SearchCustomerPaymentsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCustomerPaymentAsync);
        api.MapPut(UpdateCustomerPaymentAsync, "{id}");
        api.MapDelete(DeleteCustomerPaymentAsync, "{id}");
    }

    public async Task<IResult> GetCustomerPaymentByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCustomerPaymentByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCustomerPaymentsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCustomerPaymentsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCustomerPaymentsAsync([AsParameters] SearchCustomerPaymentRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(CustomerPaymentMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCustomerPaymentAsync(CreateCustomerPaymentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(CustomerPaymentMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateCustomerPaymentAsync(string id, UpdateCustomerPaymentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CustomerPaymentMappings.ToUpdateCommand(id, request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteCustomerPaymentAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteCustomerPaymentCommand(id), ct);
        return result.ToHttpResult();
    }
}