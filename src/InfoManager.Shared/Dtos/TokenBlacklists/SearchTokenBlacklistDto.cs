namespace InfoManager.Shared.Dtos.TokenBlacklists;

public record SearchTokenBlacklistDto
{
    public ReasonRevoke? ReasonRevoke { get; init; }
    public TokenStatus? Status { get; init; }
    public TokenType? TokenType { get; init; }
    public DateTimeOffset? FromExpiresAt { get; init; }
    public DateTimeOffset? ToExpiresAt { get; init; }
    //Phân trang
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}
