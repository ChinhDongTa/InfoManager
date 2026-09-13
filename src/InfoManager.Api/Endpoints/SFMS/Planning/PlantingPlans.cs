namespace InfoManager.Api.Endpoints.SFMS.Planning;

public class PlantingPlans : EndpointGroupBase
{
    public override string GroupName => "PlantingPlans";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPlantingPlanByIdAsync, "{id}");
        api.MapGet(GetPlantingPlansAsync);
        api.MapGet(SearchPlantingPlansAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePlantingPlanAsync);
        api.MapPut(UpdatePlantingPlanAsync, "{id}");
        api.MapDelete(DeletePlantingPlanAsync, "{id}");
    }
    public async Task<IResult> GetPlantingPlanByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetPlantingPlanByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPlantingPlansAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPlantingPlansAsync([AsParameters] SearchPlantingPlansRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(PlantingPlanMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePlantingPlanAsync(CreatePlantingPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(PlantingPlanMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdatePlantingPlanAsync(string id, UpdatePlantingPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(PlantingPlanMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeletePlantingPlanAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeletePlantingPlanCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}