namespace InfoManager.Api.Endpoints.SFMS.Production;

public class Harvests : EndpointGroupBase
{
    public override string GroupName => "Harvests";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetHarvestByIdAsync, "{id}");
        api.MapGet(GetHarvestsAsync);
        api.MapGet(SearchHarvestsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateHarvestAsync);
        api.MapPut(UpdateHarvestAsync, "{id}");
        api.MapDelete(DeleteHarvestAsync, "{id}");
    }

    public async Task<IResult> GetHarvestByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetHarvestByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetHarvestsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchHarvestsAsync([AsParameters] SearchHarvestsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateHarvestAsync(CreateHarvestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateHarvestAsync(string id, UpdateHarvestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ProductionMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteHarvestAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteHarvestCommand(id), ct);
        return result.ToHttpResult();
    }
}