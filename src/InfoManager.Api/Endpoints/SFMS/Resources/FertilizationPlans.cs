namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class FertilizationPlans : EndpointGroupBase
{
    public override string GroupName => "FertilizationPlans";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFertilizationPlanByIdAsync, "{id}");
        api.MapGet(GetFertilizationPlansAsync);
        api.MapGet(SearchFertilizationPlansAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFertilizationPlanAsync);
        api.MapPut(UpdateFertilizationPlanAsync, "{id}");
        api.MapDelete(DeleteFertilizationPlanAsync, "{id}");
    }

    public async Task<IResult> GetFertilizationPlanByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetFertilizationPlanByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFertilizationPlansAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFertilizationPlansAsync([AsParameters] SearchFertilizationPlansRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFertilizationPlanAsync(CreateFertilizationPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFertilizationPlanAsync(string id, UpdateFertilizationPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFertilizationPlanAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteFertilizationPlanCommand(id), ct);
        return result.ToHttpResult();
    }
}