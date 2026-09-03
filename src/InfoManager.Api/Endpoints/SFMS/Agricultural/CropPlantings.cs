using InfoManager.Application.Common.Mappings;

namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class CropPlantings : EndpointGroupBase
{
    override public string GroupName => "CropPlantings";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCropPlantingsAsync);
        api.MapGet(GetCropPlantingByIdAsync, "{id}");
        api.MapGet(SearchCropPlantingsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCropPlantingAsync);
        api.MapPut(UpdateCropPlantingAsync, "{id}");
        api.MapDelete(DeleteCropPlantingAsync, "{id}");
    }

    public async Task<IResult> GetCropPlantingsAsync(int pageIndex, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetCropPlantingsQuery(pageIndex, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> GetCropPlantingByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetCropPlantingByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> SearchCropPlantingsAsync([AsParameters] SearchCropPlantingRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
       
        var result = await sender.Send(CropPlantingMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCropPlantingAsync([FromBody] CreateCropPlantingRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CropPlantingMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateCropPlantingAsync(string id, [FromBody] UpdateCropPlantingRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CropPlantingMappings.ToUpdateCommand(id, request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteCropPlantingAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCropPlantingCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}