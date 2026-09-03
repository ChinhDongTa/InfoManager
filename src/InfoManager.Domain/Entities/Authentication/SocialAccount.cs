using InfoManager.Domain.Entities.Authentication;

namespace InfoManager.Domain.Entities;

/// <summary>
/// Tài khoản mạng xã hội của người dùng (Telegram, Zalo, Facebook, Google...)
/// Chủ yếu phục vụ bot / client bên thứ 3 truy cập thông tin gia đình.
/// </summary>
public class SocialAccount : BaseAuditableEntity
{
    public required string UserId { get; set; }                 // FK → ApplicationUser (1 - n)
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Mã nhà cung cấp: telegram, zalo, facebook, google, viber...
    /// </summary>
    [MaxLength(50)]
    public required string Provider { get; set; }

    /// <summary>
    /// ID tài khoản trên nhà cung cấp (TelegramId, ZaloId...)
    /// </summary>
    [MaxLength(100)]
    public required string ProviderAccountId { get; set; }      // Nên required

    [MaxLength(200)]
    public string? DisplayName { get; set; }

    public bool IsPrimary { get; set; } = false;

    [MaxLength(300)]
    public string? HomepageUrl { get; set; }
}
