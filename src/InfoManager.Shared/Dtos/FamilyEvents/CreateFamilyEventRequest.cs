namespace InfoManager.Shared.Dtos.FamilyEvents;

public record CreateFamilyEventRequest
{
    public required string FamilyMemberId { get; init; }
    public DateOnly EventDate { get; init; }
    public bool IsActive { get; init; } = true;
    public string Title { get; init; } = string.Empty;
    public FamilyEventType EventType { get; init; }
    public string? Location { get; init; }
}