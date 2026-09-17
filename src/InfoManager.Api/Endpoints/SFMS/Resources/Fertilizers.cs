namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class Fertilizers : EndpointGroupBase
{
    public override string GroupName => "Fertilizers";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFertilizerByIdAsync, "{id}");
        api.MapGet(GetFertilizersAsync);
        api.MapGet(SearchFertilizersAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFertilizerAsync);
        api.MapPut(UpdateFertilizerAsync, "{id}");
        api.MapDelete(DeleteFertilizerAsync, "{id}");
    }

    public async Task<IResult> GetFertilizerByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetFertilizerByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFertilizersAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFertilizersAsync([AsParameters] SearchFertilizersRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFertilizerAsync(CreateFertilizerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFertilizerAsync(string id, UpdateFertilizerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFertilizerAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteFertilizerCommand(id), ct);
        return result.ToHttpResult();
    }
}