using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreatePesticidePlanModel
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// ID thuốc BVTV
    /// </summary>
    [Required]
    public string PesticideId { get; set; } = string.Empty;

    /// <summary>
    /// Tên kế hoạch
    /// </summary>
    [Required]
    public string PlanName { get; set; } = string.Empty;

    /// <summary>
    /// Ngày dự kiến phun
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
    /// Đối tượng phòng trừ
    /// </summary>
    public string? Target { get; set; }

    /// <summary>
    /// Khối lượng dự kiến
    /// </summary>
    public decimal PlannedQuantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "lít";

    /// <summary>
    /// Phương pháp phun
    /// </summary>
    public string? ApplicationMethod { get; set; }

    public PesticidePlanStatus? Status { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreatePesticidePlanRequest CreateRequest()
    {
        return new CreatePesticidePlanRequest
        (
            FarmId: this.FarmId,
            PesticideId: this.PesticideId,
            PlanName: this.PlanName,
            PlannedDate: this.PlannedDate,
            CropPlantingId: this.CropPlantingId,
            GrowthStageId: this.GrowthStageId,
            Target: this.Target,
            PlannedQuantity: this.PlannedQuantity,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            Status: this.Status,
            Notes: this.Notes
        );
    }
}