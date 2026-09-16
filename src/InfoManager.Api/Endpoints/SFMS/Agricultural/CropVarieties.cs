namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class CropVarieties : EndpointGroupBase
{
    public override string GroupName => "CropVarieties";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCropVarietiesAsync);
        api.MapGet(GetCropVarietyByIdAsync, "{id}");
        api.MapGet(SearchCropVarietiesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCropVarietyAsync);
        api.MapPut(UpdateCropVarietyAsync, "{id}");
        api.MapDelete(DeleteCropVarietyAsync, "{id}");
    }

    public async Task<IResult> GetCropVarietiesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var query = new GetCropVarietiesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCropVarietyByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var query = new GetCropVarietyByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCropVarietiesAsync([AsParameters] SearchCropVarietyRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(CropVarietyMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCropVarietyAsync([FromBody] CreateCropVarietyRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(CropVarietyMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateCropVarietyAsync(string id, [FromBody] UpdateCropVarietyRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }

        var result = await sender.Send(CropVarietyMappings.ToUpdateCommand(id, request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteCropVarietyAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteCropVarietyCommand(id), ct);
        return result.ToHttpResult();
    }
}