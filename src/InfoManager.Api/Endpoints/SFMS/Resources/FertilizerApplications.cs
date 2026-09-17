namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class FertilizerApplications : EndpointGroupBase
{
    public override string GroupName => "FertilizerApplications";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFertilizerApplicationByIdAsync, "{id}");
        api.MapGet(GetFertilizerApplicationsAsync);
        api.MapGet(SearchFertilizerApplicationsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFertilizerApplicationAsync);
        api.MapPut(UpdateFertilizerApplicationAsync, "{id}");
        api.MapDelete(DeleteFertilizerApplicationAsync, "{id}");
    }

    public async Task<IResult> GetFertilizerApplicationByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetFertilizerApplicationByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFertilizerApplicationsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFertilizerApplicationsAsync([AsParameters] SearchFertilizerApplicationsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFertilizerApplicationAsync(CreateFertilizerApplicationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFertilizerApplicationAsync(string id, UpdateFertilizerApplicationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFertilizerApplicationAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteFertilizerApplicationCommand(id), ct);
        return result.ToHttpResult();
    }
}