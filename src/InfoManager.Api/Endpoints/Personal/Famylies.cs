using InfoManager.Application.Features.Families.Commands;
using InfoManager.Application.Features.Families.Queries.GetFamilies;
using InfoManager.Shared.Dtos.Families;

namespace InfoManager.Api.Endpoints.Personal;

public class Famylies : EndpointGroupBase
{
    public override string GroupName => "famylies";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        api.MapGet(GetFamilyByIdAsync, "{id}");
        api.MapGet(GetFamiliesAsync);
        api.MapGet(SearchFamiliesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFamilyAsync);
        api.MapPut(UpdateFamilyAsync, "{id}");
        api.MapDelete(DeleteFamilyAsync, "{id}");
    }

    public async Task<IResult> GetFamilyByIdAsync(string id,
                                                  [FromServices] ISender sender,
                                                  [FromServices] IUser user,
                                                  CancellationToken ct)
    {
        var query = new GetFamilyByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFamiliesAsync([FromServices] ISender sender,
                                                [FromServices] IUser user,
                                                CancellationToken ct,
                                                int pageNumber = 1,
                                                int pageSize = 20)
    {
        var query = new GetFamiliesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFamiliesAsync([FromServices] ISender sender,
                                                   [FromServices] IUser user,
                                                   CancellationToken ct,
                                                   string? searchTerm = null,
                                                   int pageNumber = 1,
                                                   int pageSize = 20)
    {
        var query = new SearchFamiliesQuery
        {
            SearchTerm = searchTerm,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFamilyAsync([FromServices] ISender sender,
                                                 [FromServices] IUser user,
                                                 CancellationToken ct,
                                                 [FromBody] CreateFamilyRequest request)
    {
        var command = new CreateFamilyCommand
        {
            // Map properties from request to command
            Name = request.Name,
            Email = request.Email,
            Address = request.Address,
            RepresentativeId = request.RepresentativeId
        };
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFamilyAsync(string id,
                                                 [FromServices] ISender sender,
                                                 [FromServices] IUser user,
                                                 CancellationToken ct,
                                                 [FromBody] UpdateFamilyRequest request)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var command = new UpdateFamilyCommand
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
            Address = request.Address,
            RepresentativeId = request.RepresentativeId
        };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFamilyAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var command = new DeleteFamilyCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }
}