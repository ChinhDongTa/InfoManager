using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Devices : EndpointGroupBase
{
    public override string GroupName => "Devices";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetDeviceByIdAsync, "{id}");
        api.MapGet(GetDevicesAsync);
        api.MapGet(SearchDevicesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateDeviceAsync);
        api.MapPut(UpdateDeviceAsync, "{id}");
        api.MapDelete(DeleteDeviceAsync, "{id}");
    }

    public async Task<IResult> GetDeviceByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetDeviceByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetDevicesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetDevicesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchDevicesAsync([AsParameters] SearchDevicesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(DeviceMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateDeviceAsync(CreateDeviceRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(DeviceMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateDeviceAsync(string id, UpdateDeviceRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(DeviceMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteDeviceAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteDeviceCommand(id), ct);
        return result.ToHttpResult();
    }
}