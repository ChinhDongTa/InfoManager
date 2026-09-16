namespace InfoManager.Api.Endpoints.SFMS.Issues;

public class Diseases : EndpointGroupBase
{
    public override string GroupName => "Diseases";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetDiseaseByIdAsync, "{id}");
        api.MapGet(GetDiseasesAsync);
        api.MapGet(SearchDiseasesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateDiseaseAsync);
        api.MapPut(UpdateDiseaseAsync, "{id}");
        api.MapDelete(DeleteDiseaseAsync, "{id}");
    }

    public async Task<IResult> GetDiseaseByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetDiseaseByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetDiseasesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchDiseasesAsync([AsParameters] SearchDiseasesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateDiseaseAsync(CreateDiseaseRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateDiseaseAsync(string id, UpdateDiseaseRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(IssuesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteDiseaseAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteDiseaseCommand(id), ct);
        return result.ToHttpResult();
    }
}