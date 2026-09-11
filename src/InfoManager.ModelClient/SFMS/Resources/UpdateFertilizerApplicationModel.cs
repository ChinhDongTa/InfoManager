using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class UpdateFertilizerApplicationModel
{
    /// <summary>ID lần bón phân. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID thửa đất.</summary>
    public string? FieldId { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>ID kế hoạch bón phân.</summary>
    public string? FertilizationPlanId { get; set; }

    /// <summary>ID phân bón.</summary>
    public string? FertilizerId { get; set; }

    /// <summary>Ngày bón.</summary>
    public DateTimeOffset? AppliedDate { get; set; }

    /// <summary>Khối lượng đã bón.</summary>
    public decimal? AppliedQuantity { get; set; }

    /// <summary>Đơn vị.</summary>
    public string? Unit { get; set; }

    /// <summary>Phương pháp bón.</summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>Người bón.</summary>
    public string? AppliedBy { get; set; }

    /// <summary>Chi phí.</summary>
    public decimal? Cost { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateFertilizerApplicationModel(string id, FertilizerApplicationDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FieldId = dto.FieldId;
        CropPlantingId = dto.CropPlantingId;
        FertilizationPlanId = dto.FertilizationPlanId;
        FertilizerId = dto.FertilizerId;
        AppliedDate = dto.AppliedDate;
        AppliedQuantity = dto.AppliedQuantity;
        Unit = dto.Unit;
        ApplicationMethod = dto.ApplicationMethod;
        AppliedBy = dto.AppliedBy;
        Cost = dto.Cost;
        Notes = dto.Notes;
    }

    public UpdateFertilizerApplicationRequest CreateRequest()
    {
        return new UpdateFertilizerApplicationRequest
        (
            Id: this.Id,
            FieldId: this.FieldId,
            CropPlantingId: this.CropPlantingId,
            FertilizationPlanId: this.FertilizationPlanId,
            FertilizerId: this.FertilizerId,
            AppliedDate: this.AppliedDate,
            AppliedQuantity: this.AppliedQuantity,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            AppliedBy: this.AppliedBy,
            Cost: this.Cost,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateFertilizerApplicationModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}