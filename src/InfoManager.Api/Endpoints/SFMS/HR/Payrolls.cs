using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class Payrolls : EndpointGroupBase
{
    public override string GroupName => "Payrolls";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetPayrollByIdAsync, "{id}");
        api.MapGet(GetPayrollsAsync);
        api.MapGet(SearchPayrollsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreatePayrollAsync);
        api.MapPut(UpdatePayrollAsync, "{id}");
        api.MapDelete(DeletePayrollAsync, "{id}");
    }

    public async Task<IResult> GetPayrollByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPayrollByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetPayrollsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetPayrollsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchPayrollsAsync([AsParameters] SearchPayrollsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreatePayrollAsync(CreatePayrollRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdatePayrollAsync(string id, UpdatePayrollRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeletePayrollAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeletePayrollCommand(id), ct);
        return result.ToHttpResult();
    }
}