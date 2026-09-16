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

    public async Task<IResult> GetFarmFinancialSummaryByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetFarmFinancialSummaryByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmFinancialSummarysAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmFinancialSummarysAsync([AsParameters] SearchFarmFinancialSummariesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(FarmFinancialSummaryMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmFinancialSummaryAsync(CreateFarmFinancialSummaryRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(FarmFinancialSummaryMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFarmFinancialSummaryAsync(string id, UpdateFarmFinancialSummaryRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmFinancialSummaryMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFarmFinancialSummaryAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteFarmFinancialSummaryCommand(id), ct);
        return result.ToHttpResult();
    }
}