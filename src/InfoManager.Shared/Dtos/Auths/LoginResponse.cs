namespace InfoManager.Shared.Dtos.Auths;

/// <summary>
/// Response DTO for login endpoint containing authentication tokens
/// </summary>
public record LoginResponse
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public int ExpiresIn { get; init; }
}