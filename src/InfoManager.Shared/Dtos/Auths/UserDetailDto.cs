namespace InfoManager.Shared.Dtos.Auths;

public record UserDetailDto
{
    public string Id { get; init; } = string.Empty;

    public string? UserNameOrEmail { get; init; }

    public string? PhoneNumber { get; init; }

    public List<string> Roles { get; init; } = [];
}
