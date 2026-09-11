using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class UpdateHarvestPlanModel
{
    /// <summary>ID kế hoạch. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID chu kỳ trồng.</summary>
    public string? CropCycleId { get; set; }

    /// <summary>Tên kế hoạch. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? PlanName { get; set; }

    /// <summary>Ngày bắt đầu thu dự kiến.</summary>
    public DateTimeOffset? ExpectedStartDate { get; set; }

    /// <summary>Ngày kết thúc thu dự kiến.</summary>
    public DateTimeOffset? ExpectedEndDate { get; set; }

    /// <summary>Phương pháp thu hoạch. Tối đa 100 ký tự.</summary>
    [MaxLength(100)]
    public string? HarvestMethod { get; set; }

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>Đơn vị sản lượng. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? YieldUnit { get; set; }

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? LaborRequirement { get; set; }

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? EquipmentRequired { get; set; }

    /// <summary>Kế hoạch sơ chế. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? PostHarvestProcessing { get; set; }

    /// <summary>Nhu cầu kho chứa. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? StorageRequirement { get; set; }

    /// <summary>Thời gian lưu kho (ngày). ≥ 0.</summary>
    [Range(0, int.MaxValue)]
    public int? StorageDuration { get; set; }

    /// <summary>Kế hoạch vận chuyển. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? TransportationPlan { get; set; }

    /// <summary>Ngày bán dự kiến.</summary>
    public DateTimeOffset? ExpectedSaleDate { get; set; }

    /// <summary>Khách hàng mục tiêu. Tối đa 300 ký tự.</summary>
    [MaxLength(300)]
    public string? TargetBuyer { get; set; }

    /// <summary>Giá bán dự kiến. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedSellingPrice { get; set; }

    /// <summary>Trạng thái.</summary>
    public PlanStatus? Status { get; set; }

    /// <summary>Đánh giá rủi ro. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? RiskAssessment { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public UpdateHarvestPlanModel(string id, HarvestPlanDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropCycleId = dto.CropCycleId;
        PlanName = dto.PlanName;
        ExpectedStartDate = dto.ExpectedStartDate;
        ExpectedEndDate = dto.ExpectedEndDate;
        HarvestMethod = dto.HarvestMethod;
        ExpectedYield = dto.ExpectedYield;
        YieldUnit = dto.YieldUnit;
        LaborRequirement = dto.LaborRequirement;
        EquipmentRequired = dto.EquipmentRequired;
        PostHarvestProcessing = dto.PostHarvestProcessing;
        StorageRequirement = dto.StorageRequirement;
        StorageDuration = dto.StorageDuration;
        TransportationPlan = dto.TransportationPlan;
        ExpectedSaleDate = dto.ExpectedSaleDate;
        TargetBuyer = dto.TargetBuyer;
        ExpectedSellingPrice = dto.ExpectedSellingPrice;
        Status = dto.Status;
        RiskAssessment = dto.RiskAssessment;
        Notes = dto.Notes;
    }

    public UpdateHarvestPlanRequest CreateRequest()
    {
        return new UpdateHarvestPlanRequest
        (
            Id: this.Id,
            CropCycleId: this.CropCycleId,
            PlanName: this.PlanName,
            ExpectedStartDate: this.ExpectedStartDate,
            ExpectedEndDate: this.ExpectedEndDate,
            HarvestMethod: this.HarvestMethod,
            ExpectedYield: this.ExpectedYield,
            YieldUnit: this.YieldUnit,
            LaborRequirement: this.LaborRequirement,
            EquipmentRequired: this.EquipmentRequired,
            PostHarvestProcessing: this.PostHarvestProcessing,
            StorageRequirement: this.StorageRequirement,
            StorageDuration: this.StorageDuration,
            TransportationPlan: this.TransportationPlan,
            ExpectedSaleDate: this.ExpectedSaleDate,
            TargetBuyer: this.TargetBuyer,
            ExpectedSellingPrice: this.ExpectedSellingPrice,
            Status: this.Status,
            RiskAssessment: this.RiskAssessment,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateHarvestPlanModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
