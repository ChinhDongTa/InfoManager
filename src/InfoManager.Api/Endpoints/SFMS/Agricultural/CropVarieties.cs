using InfoManager.Application.Common.Mappings;

namespace InfoManager.Api.Endpoints.SFMS.Agricultural;

public class CropVarieties : EndpointGroupBase
{
    override public string GroupName => "CropVarieties";
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

    public async Task<IResult> GetCropVarietiesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetCropVarietiesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCropVarietyByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetCropVarietyByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> SearchCropVarietiesAsync([AsParameters] SearchCropVarietyRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        
        var result = await sender.Send(CropVarietyMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> CreateCropVarietyAsync([FromBody]CreateCropVarietyRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        
        var result = await sender.Send(CropVarietyMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateCropVarietyAsync(string id, [FromBody] UpdateCropVarietyRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if(id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        
        var result = await sender.Send(CropVarietyMappings.ToUpdateCommand(id, request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteCropVarietyAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCropVarietyCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}