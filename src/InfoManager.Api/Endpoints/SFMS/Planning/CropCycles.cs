namespace InfoManager.Api.Endpoints.SFMS.Planning;

public class CropCycles : EndpointGroupBase
{
    public override string GroupName => "CropCycles";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCropCycleByIdAsync, "{id}");
        api.MapGet(GetCropCyclesAsync);
        api.MapGet(SearchCropCyclesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCropCycleAsync);
        api.MapPut(UpdateCropCycleAsync, "{id}");
        api.MapDelete(DeleteCropCycleAsync, "{id}");
    }
    public async Task<IResult> GetCropCycleByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCropCycleByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCropCyclesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCropCyclesAsync([AsParameters] SearchCropCyclesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CropCycleMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCropCycleAsync(CreateCropCycleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CropCycleMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateCropCycleAsync(string id, UpdateCropCycleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CropCycleMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteCropCycleAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCropCycleCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}