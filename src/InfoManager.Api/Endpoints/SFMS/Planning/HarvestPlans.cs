namespace InfoManager.Api.Endpoints.SFMS.Planning;

public class HarvestPlans : EndpointGroupBase
{
    public override string GroupName => "HarvestPlans";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetHarvestPlanByIdAsync, "{id}");
        api.MapGet(GetHarvestPlansAsync);
        api.MapGet(SearchHarvestPlansAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateHarvestPlanAsync);
        api.MapPut(UpdateHarvestPlanAsync, "{id}");
        api.MapDelete(DeleteHarvestPlanAsync, "{id}");
    }
    public async Task<IResult> GetHarvestPlanByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetHarvestPlanByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetHarvestPlansAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchHarvestPlansAsync([AsParameters] SearchHarvestPlansRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HarvestPlanMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateHarvestPlanAsync(CreateHarvestPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HarvestPlanMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateHarvestPlanAsync(string id, UpdateHarvestPlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HarvestPlanMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteHarvestPlanAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteHarvestPlanCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}