namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Danh mục thuốc bảo vệ thực vật
/// </summary>
public class Pesticide : BaseAuditableEntity
{
    /// <summary>
    /// Tên thuốc
    /// </summary>
    [MaxLength(200)]
    public string Name { get; set; }

    /// <summary>
    /// Hoạt chất
    /// </summary>
    [MaxLength(200)]
    public string? ActiveIngredient { get; set; }

    /// <summary>
    /// Loại thuốc (Trừ sâu, Trừ bệnh, Trừ cỏ...)
    /// </summary>
    public PesticideType PesticideType { get; set; } = PesticideType.Insecticide;

    /// <summary>
    /// Mức độc hại
    /// </summary>
    public ToxicityLevel ToxicityLevel { get; set; } = ToxicityLevel.Moderate;

    /// <summary>
    /// Thời gian cách ly (ngày)
    /// </summary>
    public int? PreHarvestIntervalDays { get; set; }

    /// <summary>
    /// Đơn vị (lít, kg, chai...)
    /// </summary>
    [MaxLength(20)]
    public string Unit { get; set; } = "lít";

    /// <summary>
    /// Nhà sản xuất
    /// </summary>
    [MaxLength(200)]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Số đăng ký
    /// </summary>
    [MaxLength(100)]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Còn sử dụng hay không
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú / hướng dẫn sử dụng
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public virtual ICollection<PesticidePlan> Plans { get; set; } = [];
    public virtual ICollection<PesticideApplication> Applications { get; set; } = [];
}