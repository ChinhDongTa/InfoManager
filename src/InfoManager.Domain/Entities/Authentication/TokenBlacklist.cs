namespace InfoManager.Domain.Entities.Authentication;

/// <summary>
///  Quản lý các token khi logout, bị nghi ngờ mất kiểm soát,...
///  Khi Logout bắc buộc phải đưa vào TokenBlacklist và sẽ được xóa khi thời hạn của chúng đã hết.
///  Sơ đồ quy trình:
///  Login
///    ↓ (tạo Access + Refresh Token)
///    → Không thêm vào Blacklist
///
///  Sử dụng bình thường
///    ↓
///  Access Token hết hạn 
///    → Dùng Refresh Token xin Access Token mới
///
///  Logout
///    ↓
///  Tạo record trong TokenBlacklist (Status = Blacklisted)
///    → Token sau này bị chặn khi kiểm tra
/// </summary>
public class TokenBlacklist : BaseAuditableEntity
{
    /// <summary>
    /// JWT ID (claim jti)
    /// </summary>
    [MaxLength(100)]
    public required string Jti { get; set; }

    /// <summary>
    /// UserId được embed trong token
    /// </summary>
    [MaxLength(100)]
    public required string UserIdOfToken { get; set; }

    /// <summary>
    /// Lý do thu hồi (enum)
    /// </summary>
    public required ReasonRevoke Reason { get; set; }

    /// <summary>
    /// Khóa vĩnh viễn hay không
    /// </summary>
    public TokenStatus Status { get; set; } = TokenStatus.Blacklisted;

    /// <summary>
    /// Thời điểm hết hạn token (access/refresh)
    /// </summary>
    public required DateTimeOffset ExpiresAt { get; set; }

    /// <summary>
    /// Loại Token
    /// </summary>
    public required TokenType TokenType { get; set; } = TokenType.Access;

    public string? Note { get; set; }
}