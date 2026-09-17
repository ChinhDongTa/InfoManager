namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class PesticidePlans : EndpointGroupBase
{
    public override string GroupName => "PesticidePlans";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPesticidePlanByIdAsync, "{id}");
        api.MapGet(GetPesticidePlansAsync);
        api.MapGet(SearchPesticidePlansAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePesticidePlanAsync);
        api.MapPut(UpdatePesticidePlanAsync, "{id}");
        api.MapDelete(DeletePesticidePlanAsync, "{id}");
    }

    public async Task<IResult> GetPesticidePlanByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPesticidePlanByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPesticidePlansAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPesticidePlansAsync([AsParameters] SearchPesticidePlansRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePesticidePlanAsync(CreatePesticidePlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePesticidePlanAsync(string id, UpdatePesticidePlanRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePesticidePlanAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePesticidePlanCommand(id), ct);
        return result.ToHttpResult();
    }
}