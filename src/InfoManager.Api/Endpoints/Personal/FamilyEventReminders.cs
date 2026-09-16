using InfoManager.Application.Features.FamilyEventReminders.Commands;
using InfoManager.Application.Features.FamilyEventReminders.Queries;
using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.Api.Endpoints.Personal;

public class FamilyEventReminders : EndpointGroupBase
{
    public override string GroupName => "FamilyEventReminders";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        group.MapGet(GetFamilyEventRemindersAsync);
        group.MapGet(GetFamilyEventRemindersByMemberIdAsync, "{id}/member");
        group.MapGet(GetFamilyEventReminderByIdAsync, "{id}/event");
        group.MapGet(SearchFamilyEventRemindersAsync, "search");

        //=============Data Manipulation Endpoints================
        group.MapPost(CreateFamilyEventReminderAsync);
        group.MapPut(UpdateFamilyEventReminderAsync, "{id}");
        group.MapDelete(DeleteFamilyEventReminderAsync, "{id}");
    }

    public async Task<IResult> GetFamilyEventRemindersAsync([FromServices] ISender sender,
                                                            [FromServices] IUser user,
                                                            CancellationToken ct,
                                                            int pageNumber,
                                                            int pageSize)
    {
        var query = new GetFamilyEventRemindersQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFamilyEventRemindersByMemberIdAsync(string id,
                                                                      int pageNumber,
                                                                      int pageSize,
                                                                      [FromServices] ISender sender,
                                                                      [FromServices] IUser user,
                                                                      CancellationToken ct)
    {
        var query = new GetFamilyEventRemindersByMemberIdQuery(id, pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFamilyEventReminderByIdAsync(string id,
                                                               [FromServices] ISender sender,
                                                               [FromServices] IUser user,
                                                               CancellationToken ct)
    {
        var query = new GetFamilyEventReminderByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFamilyEventRemindersAsync([FromServices] ISender sender,
                                                               [FromServices] IUser user,
                                                               CancellationToken ct,
                                                               [AsParameters] SearchFamilyEventReminderRequest request)
    {
        var query = new SearchFamilyEventRemindersQuery
        {
            MinDaysBefore = request.MinDaysBefore,
            MaxDaysBefore = request.MaxDaysBefore,
            Channel = request.Channel,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFamilyEventReminderAsync([FromServices] ISender sender,
                                                              [FromServices] IUser user,
                                                              CancellationToken ct,
                                                              [FromBody] CreateFamilyEventReminderRequest request)
    {
        var command = new CreateFamilyEventReminderCommand
        {
            FamilyEventId = request.FamilyEventId,
            Channel = request.Channel,
            DaysBefore = request.DaysBefore,
            RemindTime = request.RemindTime,
            IsEnabled = request.IsEnabled,
            Note = request.Note
        };
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateFamilyEventReminderAsync(string id,
                                                              [FromServices] ISender sender,
                                                              [FromServices] IUser user,
                                                              CancellationToken ct,
                                                              [FromBody] UpdateFamilyEventReminderRequest request)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("ID in URL does not match ID in request body.");
        }
        var command = new UpdateFamilyEventReminderCommand
        {
            Id = request.Id,
            Channel = request.Channel,
            DaysBefore = request.DaysBefore,
            RemindTime = request.RemindTime,
            IsEnabled = request.IsEnabled,
            Note = request.Note
        };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteFamilyEventReminderAsync(string id,
                                                              [FromServices] ISender sender,
                                                              [FromServices] IUser user,
                                                              CancellationToken ct)
    {
        var command = new DeleteFamilyEventReminderCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }
}