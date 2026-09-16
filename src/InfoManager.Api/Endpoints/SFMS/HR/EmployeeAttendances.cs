using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class EmployeeAttendances : EndpointGroupBase
{
    public override string? GroupName => "EmployeeAttendances";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetEmployeeAttendanceByIdAsync, "{id}");
        api.MapGet(GetEmployeeAttendancesAsync);
        api.MapGet(SearchEmployeeAttendancesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateEmployeeAttendanceAsync);
        api.MapPut(UpdateEmployeeAttendanceAsync, "{id}");
        api.MapDelete(DeleteEmployeeAttendanceAsync, "{id}");
    }

    public async Task<IResult> GetEmployeeAttendanceByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetEmployeeAttendanceByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetEmployeeAttendancesAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetEmployeeAttendancesQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchEmployeeAttendancesAsync([AsParameters] SearchEmployeeAttendancesRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateEmployeeAttendanceAsync(CreateEmployeeAttendanceRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> UpdateEmployeeAttendanceAsync(string id, UpdateEmployeeAttendanceRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteEmployeeAttendanceAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteEmployeeAttendanceCommand(id), ct);
        return result.ToHttpResult();
    }
}