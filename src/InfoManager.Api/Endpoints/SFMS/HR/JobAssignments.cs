using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class JobAssignments : EndpointGroupBase
{
    public override string GroupName => "JobAssignments";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetJobAssignmentByIdAsync, "{id}");
        api.MapGet(GetJobAssignmentsAsync);
        api.MapGet(SearchJobAssignmentsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateJobAssignmentAsync);
        api.MapPut(UpdateJobAssignmentAsync, "{id}");
        api.MapDelete(DeleteJobAssignmentAsync, "{id}");
    }

    public async Task<IResult> GetJobAssignmentByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetJobAssignmentByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetJobAssignmentsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetJobAssignmentsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchJobAssignmentsAsync([AsParameters] SearchJobAssignmentsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateJobAssignmentAsync(CreateJobAssignmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateJobAssignmentAsync(string id, UpdateJobAssignmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteJobAssignmentAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteJobAssignmentCommand(id), ct);
        return result.ToHttpResult();
    }
}