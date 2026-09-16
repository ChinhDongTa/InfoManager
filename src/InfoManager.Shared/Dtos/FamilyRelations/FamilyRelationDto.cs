namespace InfoManager.Shared.Dtos.FamilyRelations;

public record FamilyRelationDto(string Id, string Name, string? Description);
public record CreateFamilyRelationRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
public record UpdateFamilyRelationRequest
{
    public required string Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }
}