using InfoManager.Application.Features.FamilyEventOccurrences.Commands;
using InfoManager.Application.Features.FamilyEventOccurrences.Queries;
using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.Api.Endpoints;

public class FamilyEventOccurrences : EndpointGroupBase
{
    public override string GroupName => "FamilyEventOccurrences";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        group.MapGet(GetFamilyEventOccurrenceByIdAsync, "{id}");
        group.MapGet(GetFamilyEventOccurrenceByMemberIdAsync, "{id}/member");
        group.MapGet(GetFamilyEventOccurrencesAsync);
        group.MapGet(SearchFamilyEventOccurrencesAsync, "search");

        //=============Data Manipulation Endpoints================
        group.MapPost(CreateFamilyEventOccurrenceAsync);
        group.MapPut(UpdateFamilyEventOccurrenceAsync, "{id}");
        group.MapDelete(DeleteFamilyEventOccurrenceAsync, "{id}");
    }

    public async Task<IResult> GetFamilyEventOccurrenceByIdAsync(string id,
                                                                 [FromServices] ISender sender,
                                                                 [FromServices] IUser user,
                                                                 CancellationToken ct)
    {
        var query = new GetFamilyEventOccurrenceByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFamilyEventOccurrenceByMemberIdAsync(string id,
                                                                        [FromServices] ISender sender,
                                                                        [FromServices] IUser user,
                                                                        CancellationToken ct)
    {
        var query = new GetFamilyEventOccurrencesByMemberIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFamilyEventOccurrencesAsync([FromServices] ISender sender,
                                                              [FromServices] IUser user,
                                                              CancellationToken ct,
                                                              int pageNumber,
                                                              int pageSize)
    {
        var query = new GetFamilyEventOccurrencesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFamilyEventOccurrencesAsync([FromServices] ISender sender,
                                                                  [FromServices] IUser user,
                                                                  CancellationToken ct,
                                                                  string searchTerm,
                                                                  int pageNumber,
                                                                  int pageSize)
    {
        var query = new SearchFamilyEventOccurrencesQuery(searchTerm, pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFamilyEventOccurrenceAsync([FromServices] ISender sender,
                                                                [FromServices] IUser user,
                                                                CancellationToken ct,
                                                                [FromBody] CreateFamilyEventOccurrenceRequest request)
    {
        var command = new CreateFamilyEventOccurrenceCommand()
        {
            Cost = request.Cost,
            FamilyEventId = request.FamilyEventId,
            OccurrenceDate = request.OccurrenceDate,
            Location = request.Location,
            Notes = request.Notes
        };
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFamilyEventOccurrenceAsync(string id,
                                                                [FromServices] ISender sender,
                                                                [FromServices] IUser user,
                                                                CancellationToken ct,
                                                                [FromBody] UpdateFamilyEventOccurrenceRequest request)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("ID in the URL does not match ID in the request body.");
        }
        var command = new UpdateFamilyEventOccurrenceCommand()
        {
            Cost = request.Cost,
            Id = id,
            OccurrenceDate = request.OccurrenceDate,
            Location = request.Location,
            Notes = request.Notes
        };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFamilyEventOccurrenceAsync(string id,
                                                                [FromServices] ISender sender,
                                                                [FromServices] IUser user,
                                                                CancellationToken ct)
    {
        var command = new DeleteFamilyEventOccurrenceCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }
}