namespace InfoManager.Domain.Entities.SFMS.Planning;

/// <summary>
/// Kế hoạch thu hoạch
/// </summary>
public class HarvestPlan : BaseAuditableEntity
{
    /// <summary>
    /// ID chu kỳ trồng
    /// </summary>
    public required string CropCycleId { get; set; }

    /// <summary>
    /// Tên kế hoạch
    /// </summary>
    [MaxLength(200)]
    public required string PlanName { get; set; }

    /// <summary>
    /// Ngày bắt đầu thu dự kiến
    /// </summary>
    public DateTimeOffset ExpectedStartDate { get; set; }

    /// <summary>
    /// Ngày kết thúc thu dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedEndDate { get; set; }

    /// <summary>
    /// Phương pháp thu hoạch (Thủ công, Máy, Kết hợp)
    /// </summary>
    [MaxLength(100)]
    public string? HarvestMethod { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị sản lượng
    /// </summary>
    [MaxLength(50)]
    public string? YieldUnit { get; set; }

    /// <summary>
    /// Nhu cầu nhân công (ngày công)
    /// </summary>
    public decimal? LaborRequirement { get; set; }

    /// <summary>
    /// Thiết bị cần dùng (cách nhau bởi dấu phẩy)
    /// </summary>
    [MaxLength(500)]
    public string? EquipmentRequired { get; set; }

    /// <summary>
    /// Kế hoạch sơ chế sau thu hoạch
    /// </summary>
    [MaxLength(1000)]
    public string? PostHarvestProcessing { get; set; }

    /// <summary>
    /// Nhu cầu kho chứa
    /// </summary>
    [MaxLength(500)]
    public string? StorageRequirement { get; set; }

    /// <summary>
    /// Thời gian lưu kho dự kiến (ngày)
    /// </summary>
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
    /// Khách hàng / thị trường mục tiêu
    /// </summary>
    [MaxLength(300)]
    public string? TargetBuyer { get; set; }

    /// <summary>
    /// Giá bán dự kiến / đơn vị
    /// </summary>
    public decimal? ExpectedSellingPrice { get; set; }

    /// <summary>
    /// Trạng thái kế hoạch
    /// </summary>
    public PlanStatus Status { get; set; } = PlanStatus.Draft;

    /// <summary>
    /// Đánh giá rủi ro và biện pháp giảm thiểu
    /// </summary>
    [MaxLength(1000)]
    public string? RiskAssessment { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public virtual CropCycle? CropCycle { get; set; }
}