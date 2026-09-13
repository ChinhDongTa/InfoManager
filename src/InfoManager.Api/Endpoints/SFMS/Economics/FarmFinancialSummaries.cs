namespace InfoManager.Api.Endpoints.SFMS.Economics;

public class FarmFinancialSummaries : EndpointGroupBase
{
    public override string GroupName => "FarmFinancialSummaries";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFarmFinancialSummaryByIdAsync, "{id}");
        api.MapGet(GetFarmFinancialSummarysAsync);
        api.MapGet(SearchFarmFinancialSummarysAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFarmFinancialSummaryAsync);
        api.MapPut(UpdateFarmFinancialSummaryAsync, "{id}");
        api.MapDelete(DeleteFarmFinancialSummaryAsync, "{id}");
    }
    public async Task<IResult> GetFarmFinancialSummaryByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmFinancialSummaryByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmFinancialSummarysAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmFinancialSummarysAsync([AsParameters] SearchFarmFinancialSummariesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmFinancialSummaryMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmFinancialSummaryAsync(CreateFarmFinancialSummaryRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmFinancialSummaryMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateFarmFinancialSummaryAsync(string id, UpdateFarmFinancialSummaryRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmFinancialSummaryMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFarmFinancialSummaryAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFarmFinancialSummaryCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}