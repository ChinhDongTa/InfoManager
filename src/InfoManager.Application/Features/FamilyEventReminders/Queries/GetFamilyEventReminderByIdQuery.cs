using InfoManager.Shared.Dtos.FamilyEventReminders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoManager.Application.Features.FamilyEventReminders.Queries;

public record GetFamilyEventReminderByIdQuery(string Id) : IRequest<Result<FamilyEventReminderDto?>>;
public class GetFamilyEventReminderByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventReminderByIdQuery, Result<FamilyEventReminderDto?>>
{
    public async Task<Result<FamilyEventReminderDto?>> Handle(GetFamilyEventReminderByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.FamilyEventReminders
            .Where(e => e.Id == request.Id)
            .ToFamilyEventReminderDto()
            .SingleOrNotFoundAsync(nameof(FamilyEventReminder), request.Id, cancellationToken);
        return result;
    }
}
