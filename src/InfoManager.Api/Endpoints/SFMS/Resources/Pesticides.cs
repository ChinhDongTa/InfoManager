namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class Pesticides : EndpointGroupBase
{
    public override string GroupName => "Pesticides";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPesticideByIdAsync, "{id}");
        api.MapGet(GetPesticidesAsync);
        api.MapGet(SearchPesticidesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePesticideAsync);
        api.MapPut(UpdatePesticideAsync, "{id}");
        api.MapDelete(DeletePesticideAsync, "{id}");
    }

    public async Task<IResult> GetPesticideByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPesticideByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPesticidesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPesticidesAsync([AsParameters] SearchPesticidesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePesticideAsync(CreatePesticideRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePesticideAsync(string id, UpdatePesticideRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePesticideAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePesticideCommand(id), ct);
        return result.ToHttpResult();
    }
}