namespace InfoManager.Shared.Dtos.FamilyEvents;

public record FamilyEventDto(string Id, string FamilyMemberFullName, DateOnly EventDate, string Title, string? EventName, string? Location, string? FamilyMemberId, FamilyEventType EventType);
public record FamilyEventSummaryDto(string Id, string FamilyMemberFullName, DateOnly EventDate, string? EventName);
public record SearchFamilyEventRequest(FamilyEventType? EventType = null, int PageNumber = 1, int PageSize = 20);

public record CreateFamilyEventRequest
{
    public required string FamilyMemberId { get; init; }
    public DateOnly EventDate { get; init; }
    public string Title { get; init; } = string.Empty;
    public FamilyEventType EventType { get; init; }
    public string? Location { get; init; }
}
public record UpdateFamilyEventRequest
{
    public string Id { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FamilyMemberId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateOnly? EventDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FamilyEventType? EventType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Location { get; init; }
}