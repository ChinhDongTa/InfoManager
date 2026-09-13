namespace InfoManager.Api.Endpoints.SFMS.Economics;

public class FarmRevenues : EndpointGroupBase
{
    public override string GroupName => "FarmRevenues";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFarmRevenueByIdAsync, "{id}");
        api.MapGet(GetFarmRevenuesAsync);
        api.MapGet(SearchFarmRevenuesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFarmRevenueAsync);
        api.MapPut(UpdateFarmRevenueAsync, "{id}");
        api.MapDelete(DeleteFarmRevenueAsync, "{id}");
    }
    public async Task<IResult> GetFarmRevenueByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmRevenueByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmRevenuesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmRevenuesAsync([AsParameters] SearchFarmRevenuesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmRevenueMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmRevenueAsync(CreateFarmRevenueRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmRevenueMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateFarmRevenueAsync(string id, UpdateFarmRevenueRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmRevenueMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFarmRevenueAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFarmRevenueCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}