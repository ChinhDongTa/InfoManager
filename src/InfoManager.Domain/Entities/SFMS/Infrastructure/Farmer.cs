using InfoManager.Domain.Entities.Authentication;
using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Hồ sơ nghiệp vụ chủ hộ / chủ trang trại.
/// Khác với ApplicationUser (tài khoản đăng nhập)
/// và khác với HREmployee (nhân sự làm việc tại nông trại).
/// </summary>
public class Farmer : BaseAuditableEntity
{
    /// <summary>
    /// Tài khoản đăng nhập của chủ hộ.
    /// 1 User chỉ có tối đa 1 hồ sơ Farmer.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Liên kết thành viên gia đình nếu có.
    /// </summary>
    public string? FamilyMemberId { get; set; }

    /// <summary>
    /// Mã chủ hộ / mã nông dân
    /// </summary>
    [MaxLength(50)]
    public string? FarmerCode { get; set; }

    /// <summary>
    /// Họ tên chủ hộ
    /// </summary>
    [MaxLength(200)]
    public string FullName { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>
    /// Email liên hệ nghiệp vụ
    /// </summary>
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// CCCD / CMND
    /// </summary>
    [MaxLength(50)]
    public string? IdentityNumber { get; set; }

    /// <summary>
    /// Địa chỉ thường trú / liên hệ
    /// </summary>
    [MaxLength(500)]
    public string? Address { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual ApplicationUser? User { get; set; }
    public virtual FamilyMember? FamilyMember { get; set; }
    public virtual ICollection<Farm> Farms { get; set; } = [];
}