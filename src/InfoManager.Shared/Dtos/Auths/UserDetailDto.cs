namespace InfoManager.Shared.Dtos.Auths;

public record UserDetailDto
{
    public string Id { get; init; } = string.Empty;

    public string? UserNameOrEmail { get; init; }

    public string? PhoneNumber { get; init; }

    public string? FullName { get; init; }
    public long? TelegramId { get; init; }

    public IEnumerable<string>? Roles { get; init; }
}
