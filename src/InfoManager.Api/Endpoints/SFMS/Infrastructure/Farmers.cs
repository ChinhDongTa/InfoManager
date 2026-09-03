using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;
using InfoManager.Shared.Dtos.Common;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Farmers : EndpointGroupBase
{
    override public string GroupName => "Farmers";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFarmerByIdAsync, "{id}");
        api.MapGet(GetFarmersAsync);
        api.MapGet(SearchFarmersAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFarmerAsync);
        api.MapPut(UpdateFarmerAsync, "{id}");
        api.MapDelete(DeleteFarmerAsync, "{id}");
    }
    public async Task<IResult> GetFarmerByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmerByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmersAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmersQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmersAsync([AsParameters] SearchTermRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new SearchFarmersQuery(request.Term, request.PageNumber, request.PageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmerAsync(CreateFarmerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmerMappings.ToCreateCommand(request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> UpdateFarmerAsync(string id, UpdateFarmerRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmerMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFarmerAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFarmerCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}