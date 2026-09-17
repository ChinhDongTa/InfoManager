namespace InfoManager.Api.Endpoints.SFMS.Resources;

public class PesticideApplications : EndpointGroupBase
{
    public override string GroupName => "PesticideApplications";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPesticideApplicationByIdAsync, "{id}");
        api.MapGet(GetPesticideApplicationsAsync);
        api.MapGet(SearchPesticideApplicationsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePesticideApplicationAsync);
        api.MapPut(UpdatePesticideApplicationAsync, "{id}");
        api.MapDelete(DeletePesticideApplicationAsync, "{id}");
    }

    public async Task<IResult> GetPesticideApplicationByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPesticideApplicationByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPesticideApplicationsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPesticideApplicationsAsync([AsParameters] SearchPesticideApplicationsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePesticideApplicationAsync(CreatePesticideApplicationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(ResourcesMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePesticideApplicationAsync(string id, UpdatePesticideApplicationRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(ResourcesMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePesticideApplicationAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePesticideApplicationCommand(id), ct);
        return result.ToHttpResult();
    }
}