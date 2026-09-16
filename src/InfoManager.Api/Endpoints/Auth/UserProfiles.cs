using InfoManager.Application.Features.UserProfiles.Commands;
using InfoManager.Application.Features.UserProfiles.Queries.GetUserProfiles;
using InfoManager.Shared.Dtos.UserProfiles;

namespace InfoManager.Api.Endpoints.Auth;

public class UserProfiles : EndpointGroupBase
{
    public override string GroupName => "UserProfiles";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetUserProfileByIdAsync, "{id}");
        api.MapGet(GetUserProfilesAsync);

        //============Data Manipulation Endpoints================
        api.MapPost(CreateUserProfileAsync);
        api.MapPut(UpdateUserProfileAsync, "{id}");
        api.MapDelete(DeleteUserProfileAsync, "{id}");
    }

    public async Task<IResult> GetUserProfileByIdAsync(string id,
                                                       [FromServices] ISender sender,
                                                       CancellationToken ct)
    {
        var query = new GetUserProfileByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetUserProfilesAsync(int pageNumber,
                                                    int pageSize,
                                                    [FromServices] ISender sender,
                                                    CancellationToken ct)
    {
        var query = new GetUserProfilesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateUserProfileAsync([FromBody] CreateUserProfileRequest request,
                                                      [FromServices] ISender sender,
                                                      [FromServices] IUser user,
                                                      CancellationToken ct)
    {
        var command = new CreateUserProfileCommand()
        {
            UserId = request.UserId,
            FamilyId = request.FamilyId,
            FamilyMemberId = request.FamilyMemberId,
            ImageUrl = request.ImageUrl,
            Notes = request.Notes
        };
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateUserProfileAsync(string id,
                                                      [FromBody] UpdateUserProfileRequest request,
                                                      [FromServices] ISender sender,
                                                      [FromServices] IUser user,
                                                      CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("Id in the URL does not match Id in the request body.");
        }
        var command = new UpdateUserProfileCommand() { Id = id, FamilyId = request.FamilyId, FamilyMemberId = request.FamilyMemberId, ImageUrl = request.ImageUrl, Notes = request.Notes };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteUserProfileAsync(string id,
                                                      [FromServices] ISender sender,
                                                      CancellationToken ct)
    {
        var command = new DeleteUserProfileCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }
}