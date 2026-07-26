namespace InfoManager.Shared.Dtos.Auths;

public record UserInfoDto
{
    public string Id { get; init; } = string.Empty;
    public List<string> Roles { get; init; } = [];
    public bool IsAuthenticated { get; init; }
}