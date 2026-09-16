using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class LeaveRequests : EndpointGroupBase
{
    public override string GroupName => "LeaveRequests";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetLeaveRequestByIdAsync, "{id}");
        api.MapGet(GetLeaveRequestsAsync);
        api.MapGet(SearchLeaveRequestsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateLeaveRequestAsync);
        api.MapPut(UpdateLeaveRequestAsync, "{id}");
        api.MapDelete(DeleteLeaveRequestAsync, "{id}");
    }

    public async Task<IResult> GetLeaveRequestByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetLeaveRequestByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetLeaveRequestsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetLeaveRequestsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchLeaveRequestsAsync([AsParameters] SearchLeaveRequestsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateLeaveRequestAsync(CreateLeaveRequestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateLeaveRequestAsync(string id, UpdateLeaveRequestRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteLeaveRequestAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteLeaveRequestCommand(id), ct);
        return result.ToHttpResult();
    }
}