

namespace InfoManager.Shared.Dtos.TokenBlacklists;

public record CreateTokenBlacklistDto
{
    /// <summary>
    /// JWT ID (claim jti)
    /// </summary>
    public required string Jti { get; init; }

    /// <summary>
    /// UserId được embed trong token
    /// </summary>
    public required string UserIdOfToken { get; init; }

    /// <summary>
    /// Lý do thu hồi (enum)
    /// </summary>
    public required ReasonRevoke Reason { get; init; }

    /// <summary>
    /// Khóa vĩnh viễn hay không
    /// </summary>
    public required TokenStatus Status { get; init; } = TokenStatus.Blacklisted;

    /// <summary>
    /// Thời điểm hết hạn token (access/refresh)
    /// </summary>
    public required DateTimeOffset ExpiresAt { get; init; }

    /// <summary>
    /// Loại Token
    /// </summary>
    public required TokenType TokenType { get; init; } = TokenType.Access;
    public string? Note { get; init; }
}
