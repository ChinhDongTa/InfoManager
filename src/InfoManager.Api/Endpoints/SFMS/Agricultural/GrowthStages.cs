namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class GrowthStages : EndpointGroupBase
{
    public override string GroupName => "GrowthStages";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetGrowthStageByIdQueryAsync, "{id}");
        api.MapGet(GetGrowthStagesQueryAsync);
        api.MapGet(SearchGrowthStagesQueryAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateGrowthStageAsync);
        api.MapPut(UpdateGrowthStageAsync, "{id}");
        api.MapDelete(DeleteGrowthStageAsync, "{id}");
    }

    public async Task<IResult> GetGrowthStageByIdQueryAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetGrowthStageByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetGrowthStagesQueryAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetGrowthStagesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchGrowthStagesQueryAsync([AsParameters] SearchGrowthStageRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var searchRequest = GrowthStageMappings.ToSearchQuery(request);
        var result = await sender.Send(searchRequest, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateGrowthStageAsync([FromBody] CreateGrowthStageRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var command = GrowthStageMappings.ToCreateCommand(request);
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateGrowthStageAsync(string id, [FromBody] UpdateGrowthStageRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var command = GrowthStageMappings.ToUpdateCommand(id, request);

        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteGrowthStageAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteGrowthStageCommand(id), ct);
        return result.ToHttpResult();
    }
}