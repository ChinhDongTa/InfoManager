using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;
public class UpdateCropPlantingModel
{
    /// <summary>ID lượt trồng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Mã lượt trồng.</summary>
    public string? PlantingCode { get; set; }

    /// <summary>ID thửa đất.</summary>
    public string? FieldId { get; set; }

    /// <summary>ID cây trồng.</summary>
    public string? CropId { get; set; }

    /// <summary>ID giống cây trồng.</summary>
    public string? CropVarietyId { get; set; }

    /// <summary>ID lịch canh tác.</summary>
    public string? CropScheduleId { get; set; }

    /// <summary>Ngày gieo trồng.</summary>
    public DateTimeOffset? PlantingDate { get; set; }

    /// <summary>Ngày thu hoạch dự kiến.</summary>
    public DateTimeOffset? ExpectedHarvestDate { get; set; }

    /// <summary>Ngày thu hoạch thực tế.</summary>
    public DateTimeOffset? ActualHarvestDate { get; set; }

    /// <summary>Diện tích trồng.</summary>
    public decimal? PlantedArea { get; set; }

    /// <summary>Số lượng đã trồng.</summary>
    public decimal? QuantityPlanted { get; set; }

    /// <summary>Đơn vị trồng.</summary>
    public string? PlantedUnit { get; set; }

    /// <summary>Trạng thái trồng.</summary>
    public PlantingStatus? Status { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateCropPlantingModel(string id, CropPlantingDto dto)
    {
        Id = id;
        PlantingCode = dto.PlantingCode;
        FieldId = dto.FieldId;
        CropId = dto.CropId;
        CropVarietyId = dto.CropVarietyId;
        CropScheduleId = dto.CropScheduleId;
        PlantingDate = dto.PlantingDate;
        ExpectedHarvestDate = dto.ExpectedHarvestDate;
        ActualHarvestDate = dto.ActualHarvestDate;
        PlantedArea = dto.PlantedArea;
        QuantityPlanted = dto.QuantityPlanted;
        PlantedUnit = dto.PlantedUnit;
        Status = dto.Status;
        Notes = dto.Notes;
    }

    public UpdateCropPlantingRequest CreateRequest()
    {
        return new UpdateCropPlantingRequest
        (
            Id: this.Id,
            PlantingCode: this.PlantingCode,
            FieldId: this.FieldId,
            CropId: this.CropId,
            CropVarietyId: this.CropVarietyId,
            CropScheduleId: this.CropScheduleId,
            PlantingDate: this.PlantingDate,
            ExpectedHarvestDate: this.ExpectedHarvestDate,
            ActualHarvestDate: this.ActualHarvestDate,
            PlantedArea: this.PlantedArea,
            QuantityPlanted: this.QuantityPlanted,
            PlantedUnit: this.PlantedUnit,
            Status: this.Status,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateCropPlantingModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}