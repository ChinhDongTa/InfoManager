namespace InfoManager.Shared.Dtos.Categories;

public record CategoryDto(string Id, string Name, string? Group, string? KeyName);
public record CreateCategoryRequest
{
    public required string Name { get; init; }
    public string? Group { get; init; }
    public string? KeyName { get; init; }
}

public record UpdateCategoryRequest
{
    public string Id { get; init; }= string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? KeyName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }
}