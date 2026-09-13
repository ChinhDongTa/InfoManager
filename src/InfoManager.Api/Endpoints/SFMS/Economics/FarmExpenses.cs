namespace InfoManager.Api.Endpoints.SFMS.Economics;

public class FarmExpenses : EndpointGroupBase
{
    public override string GroupName => "FarmExpenses";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFarmExpenseByIdAsync, "{id}");
        api.MapGet(GetFarmExpensesAsync);
        api.MapGet(SearchFarmExpensesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFarmExpenseAsync);
        api.MapPut(UpdateFarmExpenseAsync, "{id}");
        api.MapDelete(DeleteFarmExpenseAsync, "{id}");
    }
    public async Task<IResult> GetFarmExpenseByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFarmExpenseByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFarmExpensesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCostAnalysesQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFarmExpensesAsync([AsParameters] SearchFarmExpensesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmExpenseMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFarmExpenseAsync(CreateFarmExpenseRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FarmExpenseMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateFarmExpenseAsync(string id, UpdateFarmExpenseRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FarmExpenseMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFarmExpenseAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFarmExpenseCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}