using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class UpdateFertilizationPlanModel
{
    /// <summary>ID kế hoạch bón phân. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID phân bón.</summary>
    public string? FertilizerId { get; set; }

    /// <summary>Tên kế hoạch.</summary>
    public string? PlanName { get; set; }

    /// <summary>Ngày dự kiến bón.</summary>
    public DateTimeOffset? PlannedDate { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>ID giai đoạn sinh trưởng.</summary>
    public string? GrowthStageId { get; set; }

    /// <summary>Số ngày sau khi trồng.</summary>
    public int? DaysAfterPlanting { get; set; }

    /// <summary>Khối lượng dự kiến.</summary>
    public decimal? PlannedQuantity { get; set; }

    /// <summary>Đơn vị.</summary>
    public string? Unit { get; set; }

    /// <summary>Phương pháp bón.</summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>Trạng thái.</summary>
    public FertilizationPlanStatus? Status { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateFertilizationPlanModel(string id, FertilizationPlanDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FertilizerId = dto.FertilizerId;
        PlanName = dto.PlanName;
        PlannedDate = dto.PlannedDate;
        CropPlantingId = dto.CropPlantingId;
        GrowthStageId = dto.GrowthStageId;
        DaysAfterPlanting = dto.DaysAfterPlanting;
        PlannedQuantity = dto.PlannedQuantity;
        Unit = dto.Unit;
        ApplicationMethod = dto.ApplicationMethod;
        Status = dto.Status;
        Notes = dto.Notes;
    }

    public UpdateFertilizationPlanRequest CreateRequest()
    {
        return new UpdateFertilizationPlanRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateFertilizationPlanModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
