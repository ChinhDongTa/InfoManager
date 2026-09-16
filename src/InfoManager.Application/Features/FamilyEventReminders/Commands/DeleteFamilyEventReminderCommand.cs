namespace InfoManager.Application.Features.FamilyEventReminders.Commands;

public record DeleteFamilyEventReminderCommand(string Id) : IRequest<Result>;

public class DeleteFamilyEventReminderCommandHandler : BaseDeleteCommandHandler<DeleteFamilyEventReminderCommand, FamilyEventReminder>
{
    public DeleteFamilyEventReminderCommandHandler(IApplicationDbContext context,
                                                   ILogger<DeleteFamilyEventReminderCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<FamilyEventReminder?> GetEntityAsync(DeleteFamilyEventReminderCommand request, CancellationToken ct)
    {
        return await Context.FamilyEventReminders.FindAsync([request.Id], ct);
    }
}