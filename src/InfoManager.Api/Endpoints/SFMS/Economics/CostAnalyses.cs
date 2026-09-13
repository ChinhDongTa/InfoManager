namespace InfoManager.Api.Endpoints.SFMS.Economics;

public class CostAnalyses : EndpointGroupBase
{
    public override string GroupName => "CostAnalysiss";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCostAnalysisByIdAsync, "{id}");
        api.MapGet(GetCostAnalysissAsync);
        api.MapGet(SearchCostAnalysissAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCostAnalysisAsync);
        api.MapPut(UpdateCostAnalysisAsync, "{id}");
        api.MapDelete(DeleteCostAnalysisAsync, "{id}");
    }
    public async Task<IResult> GetCostAnalysisByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysisByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetCostAnalysissAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchCostAnalysissAsync([AsParameters] SearchCostAnalysesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CostAnalysisMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateCostAnalysisAsync(CreateCostAnalysisRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(CostAnalysisMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateCostAnalysisAsync(string id, UpdateCostAnalysisRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(CostAnalysisMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteCostAnalysisAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCostAnalysisCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}