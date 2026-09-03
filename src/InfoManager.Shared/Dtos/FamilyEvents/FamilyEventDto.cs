namespace InfoManager.Shared.Dtos.FamilyEvents;

public record FamilyEventDto(string Id, string FamilyMemberFullName, DateOnly EventDate, string Title, string? EventName, string? Location, string? FamilyMemberId, FamilyEventType EventType, bool IsActive);
public record FamilyEventSummaryDto(string Id, string FamilyMemberFullName, DateOnly EventDate, string? EventName, bool IsActive);
public record SearchFamilyEventRequest(FamilyEventType? EventType = null, int PageNumber = 1, int PageSize = 20);