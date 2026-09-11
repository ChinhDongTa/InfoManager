using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class CreateHarvestPlanModel
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
    /// Ngày bắt đầu thu dự kiến
    /// </summary>
    [Required]
    public DateTimeOffset ExpectedStartDate { get; set; }

    /// <summary>
    /// Ngày kết thúc thu dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedEndDate { get; set; }

    /// <summary>
    /// Phương pháp thu hoạch
    /// </summary>
    [MaxLength(100)]
    public string? HarvestMethod { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị sản lượng
    /// </summary>
    [MaxLength(50)]
    public string? YieldUnit { get; set; }

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
    /// Kế hoạch sơ chế
    /// </summary>
    [MaxLength(1000)]
    public string? PostHarvestProcessing { get; set; }

    /// <summary>
    /// Nhu cầu kho chứa
    /// </summary>
    [MaxLength(500)]
    public string? StorageRequirement { get; set; }

    /// <summary>
    /// Thời gian lưu kho (ngày)
    /// </summary>
    [Range(0, int.MaxValue)]
    public int? StorageDuration { get; set; }

    /// <summary>
    /// Kế hoạch vận chuyển
    /// </summary>
    [MaxLength(500)]
    public string? TransportationPlan { get; set; }

    /// <summary>
    /// Ngày bán dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedSaleDate { get; set; }

    /// <summary>
    /// Khách hàng mục tiêu
    /// </summary>
    [MaxLength(300)]
    public string? TargetBuyer { get; set; }

    /// <summary>
    /// Giá bán dự kiến
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedSellingPrice { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public PlanStatus Status { get; set; } = PlanStatus.Draft;

    /// <summary>
    /// Đánh giá rủi ro
    /// </summary>
    [MaxLength(1000)]
    public string? RiskAssessment { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public CreateHarvestPlanRequest CreateRequest()
    {
        return new CreateHarvestPlanRequest
        (
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
}