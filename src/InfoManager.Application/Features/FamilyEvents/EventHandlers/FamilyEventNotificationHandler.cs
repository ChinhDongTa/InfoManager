using InfoManager.Domain.Events;

namespace InfoManager.Application.Features.FamilyEvents.EventHandlers;

public class FamilyEventNotificationHandler(ILogger<FamilyEventNotificationHandler> logger) : INotificationHandler<FamilyEventNotification>
{
    public Task Handle(FamilyEventNotification notification, CancellationToken ct)
    {
        logger.LogInformation("Handling FamilyEventNotification for event: {EventName}, NumDays: {NumDays}", notification.FamilyEvent.Title, notification.NumDays);

        //Send email notification or perform other actions based on the FamilyEventNotification

        return Task.CompletedTask;
    }
}