using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class WorkShifts : EndpointGroupBase
{
    public override string GroupName => "WorkShifts";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetWorkShiftByIdAsync, "{id}");
        api.MapGet(GetWorkShiftsAsync);
        api.MapGet(SearchWorkShiftsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateWorkShiftAsync);
        api.MapPut(UpdateWorkShiftAsync, "{id}");
        api.MapDelete(DeleteWorkShiftAsync, "{id}");
    }
    public async Task<IResult> GetWorkShiftByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetWorkShiftByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetWorkShiftsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetWorkShiftsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchWorkShiftsAsync([AsParameters] SearchWorkShiftsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateWorkShiftAsync(CreateWorkShiftRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateWorkShiftAsync(string id, UpdateWorkShiftRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteWorkShiftAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteWorkShiftCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}