namespace InfoManager.Shared.Dtos.FamilyMembers;

public record FamilyMemberDto(
    string Id,
    string FullName,
    string? Relationship,
    DateOnly BirthDate,
    DateOnly? DeathDate,
    string GenderString,
    string? Email,
    string? PhoneNumber,
    string? Note,
    string? FamilyRelationId,
    Gender Gender,
    string? FamilyId
);
public record FamilyMemberSummaryDto(
    string Id,
    string FullName,
    string? Relationship,
    DateOnly BirthDate
);

public record SearchFamilyMemberRequest(string? FullName = null, FamilyEventType? EventType = null, int PageNumber=1, int PageSize=20);

public record CreateFamilyMemberRequest
{
    public required string FullName { get; init; }
    public string? FamilyRelationId { get; init; }
    public DateOnly BirthDate { get; init; }
    public DateOnly? DeathDate { get; init; }
    public Gender Gender { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Note { get; init; }
}

public record UpdateFamilyMemberRequest
{
    public string Id { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FullName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FamilyRelationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateOnly? BirthDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateOnly? DeathDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Gender? Gender { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Email { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PhoneNumber { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Note { get; init; }
}