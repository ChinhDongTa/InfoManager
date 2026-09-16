using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Domain.Events;

/// <summary>
/// Thông báo tới các thành viên gia đình sự kiện nào đó
/// </summary>
public class FamilyEventNotification(FamilyEvent familyEvent, int numDays = 5) : BaseEvent
{
    public FamilyEvent FamilyEvent { get; } = familyEvent;
    public int NumDays { get; } = numDays;
}