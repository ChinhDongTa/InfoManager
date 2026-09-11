using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class CreatePlantingPlanModel
{
    /// <summary>
    /// ID chu kỳ trồng
    /// </summary>
    [Required]
    public string CropCycleId { get; set; } = string.Empty;

    /// <summary>
    /// Tên kế hoạch
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string PlanName { get; set; } = string.Empty;

    /// <summary>
    /// Phân bổ thửa ruộng
    /// </summary>
    [MaxLength(1000)]
    public string? FieldAllocation { get; set; }

    /// <summary>
    /// Phương pháp trồng
    /// </summary>
    [MaxLength(100)]
    public string? PlantingMethod { get; set; }

    /// <summary>
    /// Lượng giống cần
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? SeedQuantityRequired { get; set; }

    /// <summary>
    /// Nguồn giống
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
    [Range(0, 100)]
    public decimal? ExpectedGerminationRate { get; set; }

    /// <summary>
    /// Kế hoạch tưới
    /// </summary>
    [MaxLength(500)]
    public string? IrrigationPlan { get; set; }

    /// <summary>
    /// Kế hoạch bón phân
    /// </summary>
    [MaxLength(500)]
    public string? FertilizationPlan { get; set; }

    /// <summary>
    /// Nhu cầu nhân công
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? LaborRequirement { get; set; }

    /// <summary>
    /// Thiết bị cần dùng
    /// </summary>
    [MaxLength(500)]
    public string? EquipmentRequired { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public PlanStatus Status { get; set; } = PlanStatus.Draft;

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public CreatePlantingPlanRequest CreateRequest()
    {
        return new CreatePlantingPlanRequest
        (
            CropCycleId: this.CropCycleId,
            PlanName: this.PlanName,
            FieldAllocation: this.FieldAllocation,
            PlantingMethod: this.PlantingMethod,
            SeedQuantityRequired: this.SeedQuantityRequired,
            SeedSource: this.SeedSource,
            SeedbedPreparation: this.SeedbedPreparation,
            ExpectedGerminationRate: this.ExpectedGerminationRate,
            IrrigationPlan: this.IrrigationPlan,
            FertilizationPlan: this.FertilizationPlan,
            LaborRequirement: this.LaborRequirement,
            EquipmentRequired: this.EquipmentRequired,
            Status: this.Status,
            Notes: this.Notes
        );
    }
}