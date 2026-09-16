using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class JobPositions : EndpointGroupBase
{
    public override string GroupName => "JobPositions";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetJobPositionByIdAsync, "{id}");
        api.MapGet(GetJobPositionsAsync);
        api.MapGet(SearchJobPositionsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateJobPositionAsync);
        api.MapPut(UpdateJobPositionAsync, "{id}");
        api.MapDelete(DeleteJobPositionAsync, "{id}");
    }

    public async Task<IResult> GetJobPositionByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetJobPositionByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetJobPositionsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetJobPositionsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchJobPositionsAsync([AsParameters] SearchJobPositionsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateJobPositionAsync(CreateJobPositionRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateJobPositionAsync(string id, UpdateJobPositionRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteJobPositionAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteJobPositionCommand(id), ct);
        return result.ToHttpResult();
    }
}