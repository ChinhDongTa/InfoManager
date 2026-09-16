namespace InfoManager.Api.Endpoints.SFMS.Production;

public class Yields : EndpointGroupBase
{
    public override string GroupName => "Yields";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetYieldByIdAsync, "{id}");
        api.MapGet(GetYieldsAsync);
        api.MapGet(SearchYieldsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateYieldAsync);
        api.MapPut(UpdateYieldAsync, "{id}");
        api.MapDelete(DeleteYieldAsync, "{id}");
    }

    public async Task<IResult> GetYieldByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetYieldByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetYieldsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchYieldsAsync([AsParameters] SearchYieldsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateYieldAsync(CreateYieldRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ProductionMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateYieldAsync(string id, UpdateYieldRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ProductionMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteYieldAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteYieldCommand(id), ct);
        return result.ToHttpResult();
    }
}