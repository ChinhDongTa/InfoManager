using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class UpdatePlantingPlanModel
{
    /// <summary>ID kế hoạch. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID chu kỳ trồng.</summary>
    public string? CropCycleId { get; set; }

    /// <summary>Tên kế hoạch. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? PlanName { get; set; }

    /// <summary>Phân bổ thửa ruộng. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? FieldAllocation { get; set; }

    /// <summary>Phương pháp trồng. Tối đa 100 ký tự.</summary>
    [MaxLength(100)]
    public string? PlantingMethod { get; set; }

    /// <summary>Lượng giống cần. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? SeedQuantityRequired { get; set; }

    /// <summary>Nguồn giống. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? SeedSource { get; set; }

    /// <summary>Chuẩn bị luống / đất gieo. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? SeedbedPreparation { get; set; }

    /// <summary>Tỷ lệ nảy mầm kỳ vọng (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? ExpectedGerminationRate { get; set; }

    /// <summary>Kế hoạch tưới. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? IrrigationPlan { get; set; }

    /// <summary>Kế hoạch bón phân. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? FertilizationPlan { get; set; }

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? LaborRequirement { get; set; }

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? EquipmentRequired { get; set; }

    /// <summary>Trạng thái.</summary>
    public PlanStatus? Status { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public UpdatePlantingPlanModel(string id, PlantingPlanDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropCycleId = dto.CropCycleId;
        PlanName = dto.PlanName;
        FieldAllocation = dto.FieldAllocation;
        PlantingMethod = dto.PlantingMethod;
        SeedQuantityRequired = dto.SeedQuantityRequired;
        SeedSource = dto.SeedSource;
        SeedbedPreparation = dto.SeedbedPreparation;
        ExpectedGerminationRate = dto.ExpectedGerminationRate;
        IrrigationPlan = dto.IrrigationPlan;
        FertilizationPlan = dto.FertilizationPlan;
        LaborRequirement = dto.LaborRequirement;
        EquipmentRequired = dto.EquipmentRequired;
        Status = dto.Status;
        Notes = dto.Notes;
    }

    public UpdatePlantingPlanRequest CreateRequest()
    {
        return new UpdatePlantingPlanRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdatePlantingPlanModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}