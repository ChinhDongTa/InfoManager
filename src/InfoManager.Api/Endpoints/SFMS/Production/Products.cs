namespace InfoManager.Api.Endpoints.SFMS.Production;

public class Products : EndpointGroupBase
{
    public override string GroupName => "Products";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetProductByIdAsync, "{id}");
        api.MapGet(GetProductsAsync);
        api.MapGet(SearchProductsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateProductAsync);
        api.MapPut(UpdateProductAsync, "{id}");
        api.MapDelete(DeleteProductAsync, "{id}");
    }

    public async Task<IResult> GetProductByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetProductByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetProductsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchProductsAsync([AsParameters] SearchProductsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateProductAsync(CreateProductRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateProductAsync(string id, UpdateProductRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ProductionMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteProductAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteProductCommand(id), ct);
        return result.ToHttpResult();
    }
}