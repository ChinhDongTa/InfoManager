
namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Lịch / kế hoạch bón phân
/// </summary>
public class FertilizationPlan : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// ID lần trồng (tùy chọn)
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID giai đoạn sinh trưởng (tùy chọn)
    /// </summary>
    public string? GrowthStageId { get; set; }

    /// <summary>
    /// ID phân bón
    /// </summary>
    public required string FertilizerId { get; set; }

    /// <summary>
    /// Tên lịch bón
    /// </summary>
    [MaxLength(200)]
    public required string PlanName { get; set; }

    /// <summary>
    /// Ngày bón dự kiến
    /// </summary>
    public DateTimeOffset PlannedDate { get; set; }

    /// <summary>
    /// Số ngày sau khi trồng
    /// </summary>
    public int? DaysAfterPlanting { get; set; }

    /// <summary>
    /// Liều lượng kế hoạch
    /// </summary>
    public decimal PlannedQuantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [MaxLength(20)]
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Cách bón (Rải gốc, Phun lá, Tưới...)
    /// </summary>
    [MaxLength(100)]
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Trạng thái kế hoạch
    /// </summary>
    public FertilizationPlanStatus Status { get; set; } = FertilizationPlanStatus.Planned;

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual GrowthStage? GrowthStage { get; set; }
    public virtual Fertilizer? Fertilizer { get; set; }
}
