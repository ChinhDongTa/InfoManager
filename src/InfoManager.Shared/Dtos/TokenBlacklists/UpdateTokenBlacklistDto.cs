namespace InfoManager.Shared.Dtos.TokenBlacklists;

public record UpdateTokenBlacklistDto
{
    public int Id { get; init; }
    /// <summary>
    /// JWT ID (claim jti)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Jti { get; init; }

    /// <summary>
    /// UserId được embed trong token
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserIdOfToken { get; init; }

    /// <summary>
    /// Lý do thu hồi (enum)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReasonRevoke? Reason { get; init; }

    /// <summary>
    /// Khóa vĩnh viễn hay không
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsPermanent { get; init; } = false;

    /// <summary>
    /// Thời điểm hết hạn token (access/refresh)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? ExpiresAt { get; init; }

    /// <summary>
    /// Loại Token
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TokenType? TokenType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Note { get; init; }
}