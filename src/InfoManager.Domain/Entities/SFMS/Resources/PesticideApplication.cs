namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Lần phun thuốc thực tế
/// </summary>
public class PesticideApplication : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// ID thửa ruộng
    /// </summary>
    public string? FieldId { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID lịch phun
    /// </summary>
    public string? PesticidePlanId { get; set; }

    /// <summary>
    /// ID thuốc
    /// </summary>
    public required string PesticideId { get; set; }

    /// <summary>
    /// Ngày phun thực tế
    /// </summary>
    public DateTimeOffset AppliedDate { get; set; }

    /// <summary>
    /// Số lượng đã dùng
    /// </summary>
    public decimal AppliedQuantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [MaxLength(20)]
    public string Unit { get; set; } = "lít";

    /// <summary>
    /// Cách phun
    /// </summary>
    [MaxLength(100)]
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Người thực hiện
    /// </summary>
    [MaxLength(200)]
    public string? AppliedBy { get; set; }

    /// <summary>
    /// Chi phí
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Ngày hết thời gian cách ly
    /// </summary>
    public DateOnly? SafeHarvestDate { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual Field? Field { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual PesticidePlan? PesticidePlan { get; set; }
    public virtual Pesticide? Pesticide { get; set; }
}