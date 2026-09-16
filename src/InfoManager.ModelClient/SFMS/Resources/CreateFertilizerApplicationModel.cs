using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreateFertilizerApplicationModel
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
    /// Ngày bón
    /// </summary>
    [Required]
    public DateTimeOffset AppliedDate { get; set; }

    /// <summary>
    /// Khối lượng đã bón
    /// </summary>
    [Required]
    public decimal AppliedQuantity { get; set; }

    /// <summary>
    /// ID thửa đất
    /// </summary>
    public string? FieldId { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID kế hoạch bón phân
    /// </summary>
    public string? FertilizationPlanId { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Phương pháp bón
    /// </summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Người bón
    /// </summary>
    public string? AppliedBy { get; set; }

    /// <summary>
    /// Chi phí
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateFertilizerApplicationRequest CreateRequest()
    {
        return new CreateFertilizerApplicationRequest
        (
            FarmId: this.FarmId,
            FertilizerId: this.FertilizerId,
            AppliedDate: this.AppliedDate,
            AppliedQuantity: this.AppliedQuantity,
            FieldId: this.FieldId,
            CropPlantingId: this.CropPlantingId,
            FertilizationPlanId: this.FertilizationPlanId,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            AppliedBy: this.AppliedBy,
            Cost: this.Cost,
            Notes: this.Notes
        );
    }
}