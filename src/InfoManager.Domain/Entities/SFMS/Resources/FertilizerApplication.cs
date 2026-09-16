namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Lần bón phân thực tế
/// </summary>
public class FertilizerApplication : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// ID thửa ruộng
    /// </summary>
    public string? FieldId { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID lịch bón (nếu thực hiện từ kế hoạch)
    /// </summary>
    public string? FertilizationPlanId { get; set; }

    /// <summary>
    /// ID phân bón
    /// </summary>
    public string FertilizerId { get; set; }

    /// <summary>
    /// Ngày bón thực tế
    /// </summary>
    public DateTimeOffset AppliedDate { get; set; }

    /// <summary>
    /// Số lượng đã bón
    /// </summary>
    public decimal AppliedQuantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [MaxLength(20)]
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Cách bón
    /// </summary>
    [MaxLength(100)]
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Người thực hiện
    /// </summary>
    [MaxLength(200)]
    public string? AppliedBy { get; set; }

    /// <summary>
    /// Chi phí (nếu có)
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual Field? Field { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual FertilizationPlan? FertilizationPlan { get; set; }
    public virtual Fertilizer? Fertilizer { get; set; }
}