namespace InfoManager.Api.Endpoints.SFMS.Issues;

public class Infestations : EndpointGroupBase
{
    public override string GroupName => "Infestations";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetInfestationByIdAsync, "{id}");
        api.MapGet(GetInfestationsAsync);
        api.MapGet(SearchInfestationsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateInfestationAsync);
        api.MapPut(UpdateInfestationAsync, "{id}");
        api.MapDelete(DeleteInfestationAsync, "{id}");
    }

    public async Task<IResult> GetInfestationByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetInfestationByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetInfestationsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchInfestationsAsync([AsParameters] SearchInfestationsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateInfestationAsync(CreateInfestationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(IssuesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateInfestationAsync(string id, UpdateInfestationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(IssuesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteInfestationAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteInfestationCommand(id), ct);
        return result.ToHttpResult();
    }
}