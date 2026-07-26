namespace InfoManager.Shared.Dtos.Auths;

public record UserDto
{
    public string Id { get; init; } = string.Empty;

    public string UserNameOrEmail { get; init; } = string.Empty;

    public string? PhoneNumber { get; init; }

    public IEnumerable<string>? Roles { get; init; }
}
