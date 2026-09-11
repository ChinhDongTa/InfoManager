using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreateFertilizationPlanModel
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// ID phân bón
    /// </summary>
    [Required]
    public string FertilizerId { get; set; } = string.Empty;

    /// <summary>
    /// Tên kế hoạch
    /// </summary>
    [Required]
    public string PlanName { get; set; } = string.Empty;

    /// <summary>
    /// Ngày dự kiến bón
    /// </summary>
    [Required]
    public DateTimeOffset PlannedDate { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID giai đoạn sinh trưởng
    /// </summary>
    public string? GrowthStageId { get; set; }

    /// <summary>
    /// Số ngày sau khi trồng
    /// </summary>
    public int? DaysAfterPlanting { get; set; }

    /// <summary>
    /// Khối lượng dự kiến
    /// </summary>
    public decimal PlannedQuantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Phương pháp bón
    /// </summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public FertilizationPlanStatus Status { get; set; } = FertilizationPlanStatus.Planned;

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateFertilizationPlanRequest CreateRequest()
    {
        return new CreateFertilizationPlanRequest
        (
            FarmId: this.FarmId,
            FertilizerId: this.FertilizerId,
            PlanName: this.PlanName,
            PlannedDate: this.PlannedDate,
            CropPlantingId: this.CropPlantingId,
            GrowthStageId: this.GrowthStageId,
            DaysAfterPlanting: this.DaysAfterPlanting,
            PlannedQuantity: this.PlannedQuantity,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            Status: this.Status,
            Notes: this.Notes
        );
    }
}