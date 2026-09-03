namespace InfoManager.Domain.Entities.SFMS.Production;

/// <summary>
/// Tổng hợp năng suất và phân tích cho lần trồng
/// </summary>
public class Yield : BaseAuditableEntity
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    public required string CropPlantingId { get; set; }

    /// <summary>
    /// ID đợt thu hoạch liên quan
    /// </summary>
    public string? HarvestId { get; set; }

    /// <summary>
    /// Sản lượng thực tế
    /// </summary>
    public decimal ActualYield { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng để so sánh
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị năng suất
    /// </summary>
    [MaxLength(50)]
    public required string Unit { get; set; }

    /// <summary>
    /// Năng suất trên mỗi hecta
    /// </summary>
    public decimal YieldPerHectare { get; set; }

    /// <summary>
    /// Điểm chất lượng (%)
    /// </summary>
    public decimal? QualityRating { get; set; }

    /// <summary>
    /// Tỷ lệ hao hụt / thải loại (%)
    /// </summary>
    public decimal? WastePercentage { get; set; }

    /// <summary>
    /// Chênh lệch so với kỳ vọng (%)
    /// </summary>
    public decimal? YieldVariance { get; set; }

    /// <summary>
    /// Số ngày sinh trưởng (từ trồng đến thu hoạch)
    /// </summary>
    public int? GrowthDays { get; set; }

    /// <summary>
    /// Tổng chi phí sản xuất
    /// </summary>
    public decimal? ProductionCost { get; set; }

    /// <summary>
    /// Doanh thu từ sản lượng này
    /// </summary>
    public decimal? Revenue { get; set; }

    /// <summary>
    /// Lợi nhuận của vụ
    /// </summary>
    public decimal? Profit { get; set; }

    /// <summary>
    /// Tỷ suất hoàn vốn ROI (%)
    /// </summary>
    public decimal? ROI { get; set; }

    /// <summary>
    /// Các yếu tố ảnh hưởng đến năng suất
    /// </summary>
    [MaxLength(1000)]
    public string? AffectingFactors { get; set; }

    /// <summary>
    /// Phân tích và nhận xét
    /// </summary>
    [MaxLength(1000)]
    public string? Analysis { get; set; }

    /// <summary>
    /// Khuyến nghị cho vụ sau
    /// </summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual Harvest? Harvest { get; set; }
}