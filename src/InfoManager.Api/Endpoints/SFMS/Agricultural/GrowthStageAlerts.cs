using InfoManager.Application.Common.Mappings;

namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class GrowthStageAlerts : EndpointGroupBase
{
    public override string GroupName => "GrowthStageAlerts";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetGrowthStageAlertByIdQueryAsync, "{id}");
        api.MapGet(GetGrowthStageAlertsQueryAsync);
        api.MapGet(SearchGrowthStageAlertsQueryAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateGrowthStageAlertAsync);
        api.MapPut(UpdateGrowthStageAlertAsync, "{id}");
        api.MapDelete(DeleteGrowthStageAlertAsync, "{id}");
    }

    public async Task<IResult> GetGrowthStageAlertByIdQueryAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetGrowthStageAlertByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> GetGrowthStageAlertsQueryAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetGrowthStageAlertsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> SearchGrowthStageAlertsQueryAsync([AsParameters] SearchGrowthStageAlertRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var searchRequest = GrowthStageAlertMappings.ToSearchQuery(request);
        var result = await sender.Send(searchRequest, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> CreateGrowthStageAlertAsync([FromBody] CreateGrowthStageAlertRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var command = GrowthStageAlertMappings.ToCreateCommand(request);
        var result = await sender.Send(command, cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateGrowthStageAlertAsync(string id, [FromBody] UpdateGrowthStageAlertRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var command = GrowthStageAlertMappings.ToUpdateCommand(id,request);

        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteGrowthStageAlertAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteGrowthStageAlertCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}
