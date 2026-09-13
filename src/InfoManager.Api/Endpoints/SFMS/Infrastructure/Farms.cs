using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Farms : EndpointGroupBase
{
    override public string GroupName => "Farms";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFarmByIdAsync, "{id}");
        api.MapGet(GetFarmsAsync);
        api.MapGet(SearchFarmsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFarmAsync);
        api.MapPut(UpdateFarmAsync, "{id}");
        api.MapDelete(DeleteFarmAsync, "{id}");
    }
    public async Task<IResult> GetFarmByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmsAsync([AsParameters] SearchFarmsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmAsync(CreateFarmRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateFarmAsync(string id, UpdateFarmRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFarmAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFarmCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}
