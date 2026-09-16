namespace InfoManager.Api.Endpoints.SFMS.Issues;

public class PestDiseaseLinks : EndpointGroupBase
{
    public override string GroupName => "PestDiseaseLinks";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPestDiseaseLinkByIdAsync, "{id}");
        api.MapGet(GetPestDiseaseLinksAsync);
        api.MapGet(SearchPestDiseaseLinksAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePestDiseaseLinkAsync);
        api.MapPut(UpdatePestDiseaseLinkAsync, "{id}");
        api.MapDelete(DeletePestDiseaseLinkAsync, "{id}");
    }

    public async Task<IResult> GetPestDiseaseLinkByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPestDiseaseLinkByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPestDiseaseLinksAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPestDiseaseLinksAsync([AsParameters] SearchPestDiseaseLinksRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePestDiseaseLinkAsync(CreatePestDiseaseLinkRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePestDiseaseLinkAsync(string id, UpdatePestDiseaseLinkRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(IssuesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePestDiseaseLinkAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePestDiseaseLinkCommand(id), ct);
        return result.ToHttpResult();
    }
}