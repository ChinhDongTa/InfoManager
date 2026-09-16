namespace InfoManager.Api.Endpoints.SFMS.Production;

public class Sales : EndpointGroupBase
{
    public override string GroupName => "Sales";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetSaleByIdAsync, "{id}");
        api.MapGet(GetSalesAsync);
        api.MapGet(SearchSalesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateSaleAsync);
        api.MapPut(UpdateSaleAsync, "{id}");
        api.MapDelete(DeleteSaleAsync, "{id}");
    }

    public async Task<IResult> GetSaleByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetSaleByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetSalesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchSalesAsync([AsParameters] SearchSalesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateSaleAsync(CreateSaleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateSaleAsync(string id, UpdateSaleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ProductionMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteSaleAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteSaleCommand(id), ct);
        return result.ToHttpResult();
    }
}