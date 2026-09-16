namespace InfoManager.Shared.Dtos.Auths;

public record UpdateRoleDto
{
    public string Id { get; init; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; init; }
}