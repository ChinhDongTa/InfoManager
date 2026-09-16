namespace InfoManager.Shared.Dtos.Auths;

/// <summary>
/// Request DTO for logout endpoint
/// </summary>
public record LogoutRequest
{
    /// <summary>
    /// Refresh token to blacklist (optional - can be sent in request body or stored in cookie)
    /// </summary>
    public string? RefreshToken { get; init; }
}