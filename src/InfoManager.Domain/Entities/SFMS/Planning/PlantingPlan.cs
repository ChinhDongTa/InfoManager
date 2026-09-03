namespace InfoManager.Domain.Entities.SFMS.Planning;

/// <summary>
/// Kế hoạch trồng chi tiết
/// </summary>
public class PlantingPlan : BaseAuditableEntity
{
    /// <summary>
    /// ID chu kỳ trồng
    /// </summary>
    public required string CropCycleId { get; set; }

    /// <summary>
    /// Tên kế hoạch
    /// </summary>
    [MaxLength(200)]
    public required string PlanName { get; set; }

    /// <summary>
    /// Phân bổ thửa ruộng (JSON hoặc mô tả)
    /// </summary>
    [MaxLength(1000)]
    public string? FieldAllocation { get; set; }

    /// <summary>
    /// Phương pháp trồng (Gieo thẳng, Cấy...)
    /// </summary>
    [MaxLength(100)]
    public string? PlantingMethod { get; set; }

    /// <summary>
    /// Lượng hạt / cây giống cần (kg hoặc cây)
    /// </summary>
    public decimal? SeedQuantityRequired { get; set; }

    /// <summary>
    /// Nguồn / nhà cung cấp giống
    /// </summary>
    [MaxLength(200)]
    public string? SeedSource { get; set; }

    /// <summary>
    /// Chuẩn bị luống / đất gieo
    /// </summary>
    [MaxLength(500)]
    public string? SeedbedPreparation { get; set; }

    /// <summary>
    /// Tỷ lệ nảy mầm kỳ vọng (%)
    /// </summary>
    public decimal? ExpectedGerminationRate { get; set; }

    /// <summary>
    /// Kế hoạch tưới khi trồng
    /// </summary>
    [MaxLength(500)]
    public string? IrrigationPlan { get; set; }

    /// <summary>
    /// Kế hoạch bón phân khi trồng
    /// </summary>
    [MaxLength(500)]
    public string? FertilizationPlan { get; set; }

    /// <summary>
    /// Nhu cầu nhân công (ngày công)
    /// </summary>
    public decimal? LaborRequirement { get; set; }

    /// <summary>
    /// Thiết bị cần dùng (cách nhau bởi dấu phẩy)
    /// </summary>
    [MaxLength(500)]
    public string? EquipmentRequired { get; set; }

    /// <summary>
    /// Trạng thái kế hoạch
    /// </summary>
    public PlanStatus Status { get; set; } = PlanStatus.Draft;

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public virtual CropCycle? CropCycle { get; set; }
}