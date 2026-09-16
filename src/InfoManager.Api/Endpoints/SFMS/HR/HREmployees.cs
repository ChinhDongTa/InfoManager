using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class HREmployees : EndpointGroupBase
{
    public override string GroupName => "HREmployees";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetHREmployeeByIdAsync, "{id}");
        api.MapGet(GetHREmployeesAsync);
        api.MapGet(SearchHREmployeesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateHREmployeeAsync);
        api.MapPut(UpdateHREmployeeAsync, "{id}");
        api.MapDelete(DeleteHREmployeeAsync, "{id}");
    }

    public async Task<IResult> GetHREmployeeByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetHREmployeeByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetHREmployeesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetHREmployeesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchHREmployeesAsync([AsParameters] SearchHREmployeesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateHREmployeeAsync(CreateHREmployeeRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateHREmployeeAsync(string id, UpdateHREmployeeRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteHREmployeeAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteHREmployeeCommand(id), ct);
        return result.ToHttpResult();
    }
}