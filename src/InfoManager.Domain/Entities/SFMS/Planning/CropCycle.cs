namespace InfoManager.Domain.Entities.SFMS.Planning;

/// <summary>
/// Chu kỳ trồng — từ kế hoạch gieo đến thu hoạch
/// </summary>
public class CropCycle : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// Tên / mã chu kỳ
    /// </summary>
    [MaxLength(200)]
    public string CycleName { get; set; }

    /// <summary>
    /// ID loại cây trồng
    /// </summary>
    public string CropId { get; set; }

    /// <summary>
    /// ID giống cây
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// ID lịch trồng
    /// </summary>
    public string? CropScheduleId { get; set; }

    /// <summary>
    /// Năm bắt đầu chu kỳ
    /// </summary>
    public int StartYear { get; set; }

    /// <summary>
    /// Mùa vụ
    /// </summary>
    [MaxLength(50)]
    public string? Season { get; set; }

    /// <summary>
    /// Ngày trồng dự kiến
    /// </summary>
    public DateTimeOffset? PlannedPlantingDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch dự kiến
    /// </summary>
    public DateTimeOffset? PlannedHarvestDate { get; set; }

    /// <summary>
    /// Tổng diện tích kế hoạch (hecta)
    /// </summary>
    public decimal PlannedArea { get; set; }

    /// <summary>
    /// Trạng thái chu kỳ
    /// </summary>
    public CropCycleStatus Status { get; set; } = CropCycleStatus.Planned;

    /// <summary>
    /// Chi phí dự kiến
    /// </summary>
    public decimal? EstimatedCost { get; set; }

    /// <summary>
    /// Doanh thu dự kiến
    /// </summary>
    public decimal? EstimatedRevenue { get; set; }

    /// <summary>
    /// Lợi nhuận dự kiến
    /// </summary>
    public decimal? EstimatedProfit { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Thị trường / khách hàng mục tiêu
    /// </summary>
    [MaxLength(300)]
    public string? TargetMarket { get; set; }

    /// <summary>
    /// Giá bán mục tiêu / đơn vị
    /// </summary>
    public decimal? TargetSellingPrice { get; set; }

    /// <summary>
    /// Ghi chú chu kỳ
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual Crop? Crop { get; set; }
    public virtual CropVariety? CropVariety { get; set; }
    public virtual CropSchedule? CropSchedule { get; set; }
    public virtual ICollection<CropPlanting> Plantings { get; set; } = [];
}