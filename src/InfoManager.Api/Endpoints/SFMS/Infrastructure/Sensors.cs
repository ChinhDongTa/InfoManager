using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Sensors : EndpointGroupBase
{
    public override string GroupName => "Sensors";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetSensorByIdAsync, "{id}");
        api.MapGet(GetSensorsAsync);
        api.MapGet(SearchSensorsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateSensorAsync);
        api.MapPut(UpdateSensorAsync, "{id}");
        api.MapDelete(DeleteSensorAsync, "{id}");
    }

    public async Task<IResult> GetSensorByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetSensorByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetSensorsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetSensorsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchSensorsAsync([AsParameters] SearchSensorsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(SensorMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateSensorAsync(CreateSensorRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(SensorMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateSensorAsync(string id, UpdateSensorRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(SensorMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteSensorAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteSensorCommand(id), ct);
        return result.ToHttpResult();
    }
}