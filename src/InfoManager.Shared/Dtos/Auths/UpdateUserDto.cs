namespace InfoManager.Shared.Dtos.Auths;

public record UpdateUserDto
{
    public required string UserId { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FullName { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? TelegramId { get; init; }
}
