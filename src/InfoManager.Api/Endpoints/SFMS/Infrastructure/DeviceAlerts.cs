using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class DeviceAlerts : EndpointGroupBase
{
    override public string GroupName => "DeviceAlerts";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetDeviceAlertByIdAsync, "{id}");
        api.MapGet(GetDeviceAlertsAsync);
        api.MapGet(SearchDeviceAlertsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateDeviceAlertAsync);
        api.MapPut(UpdateDeviceAlertAsync, "{id}");
        api.MapDelete(DeleteDeviceAlertAsync, "{id}");
    }
    public async Task<IResult> GetDeviceAlertByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetDeviceAlertByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetDeviceAlertsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetDeviceAlertsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchDeviceAlertsAsync([AsParameters] SearchDeviceAlertsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(DeviceAlertMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateDeviceAlertAsync(CreateDeviceAlertRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(DeviceAlertMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateDeviceAlertAsync(string id, UpdateDeviceAlertRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(DeviceAlertMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteDeviceAlertAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteDeviceAlertCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}
