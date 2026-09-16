namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class CropSchedules : EndpointGroupBase
{
    public override string GroupName => "CropSchedules";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCropSchedulesAsync);
        api.MapGet(GetCropScheduleByIdAsync, "{id}");
        api.MapGet(SearchCropSchedulesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCropScheduleAsync);
        api.MapPut(UpdateCropScheduleAsync, "{id}");
        api.MapDelete(DeleteCropScheduleAsync, "{id}");
    }

    public async Task<IResult> GetCropSchedulesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var query = new GetCropSchedulesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCropScheduleByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var query = new GetCropScheduleByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCropSchedulesAsync([AsParameters] SearchCropSchedulesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(CropScheduleMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCropScheduleAsync([FromBody] CreateCropScheduleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(CropScheduleMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateCropScheduleAsync(string id, [FromBody] UpdateCropScheduleRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }

        var result = await sender.Send(CropScheduleMappings.ToUpdateCommand(id, request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteCropScheduleAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteCropScheduleCommand(id), ct);
        return result.ToHttpResult();
    }
}