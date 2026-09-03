namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Lịch / kế hoạch phun thuốc
/// </summary>
public class PesticidePlan : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID giai đoạn sinh trưởng
    /// </summary>
    public string? GrowthStageId { get; set; }

    /// <summary>
    /// ID thuốc
    /// </summary>
    public required string PesticideId { get; set; }

    /// <summary>
    /// Tên lịch phun
    /// </summary>
    [MaxLength(200)]
    public required string PlanName { get; set; }

    /// <summary>
    /// Mục đích (Phòng trừ sâu, bệnh, cỏ...)
    /// </summary>
    [MaxLength(200)]
    public string? Target { get; set; }

    /// <summary>
    /// Ngày phun dự kiến
    /// </summary>
    public DateTimeOffset PlannedDate { get; set; }

    /// <summary>
    /// Liều lượng kế hoạch
    /// </summary>
    public decimal PlannedQuantity { get; set; }

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
    /// Trạng thái
    /// </summary>
    public PesticidePlanStatus Status { get; set; } = PesticidePlanStatus.Planned;

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual GrowthStage? GrowthStage { get; set; }
    public virtual Pesticide? Pesticide { get; set; }
}
