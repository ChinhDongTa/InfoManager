using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class CreateCropPlantingModel
{
    /// <summary>
    /// Thửa đất trồng
    /// </summary>
    [Required]
    public string FieldId { get; set; } = string.Empty;

    /// <summary>
    /// Cây trồng
    /// </summary>
    [Required]
    public string CropId { get; set; } = string.Empty;

    /// <summary>
    /// Giống cây trồng
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// Lịch canh tác
    /// </summary>
    public string? CropScheduleId { get; set; }

    /// <summary>
    /// Ngày gieo trồng
    /// </summary>
    public DateTimeOffset PlantingDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch thực tế
    /// </summary>
    public DateTimeOffset? ActualHarvestDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedHarvestDate { get; set; }

    /// <summary>
    /// Diện tích trồng
    /// </summary>
    public decimal PlantedArea { get; set; }

    /// <summary>
    /// Số lượng đã trồng
    /// </summary>
    public decimal? QuantityPlanted { get; set; }

    /// <summary>
    /// Đơn vị trồng
    /// </summary>
    public string? PlantedUnit { get; set; }

    /// <summary>
    /// Trạng thái trồng
    /// </summary>
    public PlantingStatus Status { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateCropPlantingRequest CreateRequest()
    {
        return new CreateCropPlantingRequest
        (
            FieldId: this.FieldId,
            CropId: this.CropId,
            CropVarietyId: this.CropVarietyId,
            CropScheduleId: this.CropScheduleId,
            PlantingDate: this.PlantingDate,
            ActualHarvestDate: this.ActualHarvestDate,
            ExpectedHarvestDate: this.ExpectedHarvestDate,
            PlantedArea: this.PlantedArea,
            QuantityPlanted: this.QuantityPlanted,
            PlantedUnit: this.PlantedUnit,
            Status: this.Status,
            Notes: this.Notes
        );
    }
}