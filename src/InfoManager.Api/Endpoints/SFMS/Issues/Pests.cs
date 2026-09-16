namespace InfoManager.Api.Endpoints.SFMS.Issues;

public class Pests : EndpointGroupBase
{
    public override string GroupName => "Pests";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPestByIdAsync, "{id}");
        api.MapGet(GetPestsAsync);
        api.MapGet(SearchPestsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePestAsync);
        api.MapPut(UpdatePestAsync, "{id}");
        api.MapDelete(DeletePestAsync, "{id}");
    }

    public async Task<IResult> GetPestByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPestByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPestsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPestsAsync([AsParameters] SearchPestsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePestAsync(CreatePestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePestAsync(string id, UpdatePestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(IssuesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePestAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePestCommand(id), ct);
        return result.ToHttpResult();
    }
}