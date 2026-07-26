namespace InfoManager.Shared.Dtos.TokenBlacklists;

public record TokenBlacklistDto
{
    public string Id { get; init; } = string.Empty;
    /// <summary>
    /// JWT ID (claim jti)
    /// </summary>
    public string? Jti { get; init; }

    /// <summary>
    /// UserId được embed trong token
    /// </summary>
    public string? UserIdOfToken { get; init; }

    /// <summary>
    /// Lý do thu hồi (enum)
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// Khóa vĩnh viễn hay không
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// Thời điểm hết hạn token (access/refresh)
    /// </summary>
    public DateTimeOffset? ExpiresAt { get; init; }

    /// <summary>
    /// Loại Token
    /// </summary>
    public string? TokenType { get; init; }

    public string? Note { get; init; }
}
