namespace InfoManager.Shared.Dtos.Auths;

/// <summary>public record RefreshRequest(string RefreshToken);public record RegisterRequest(string Email, string Password);
/// Response DTO for token refresh endpoint
/// </summary>
public record TokenResponse
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public int ExpiresIn { get; init; }
}