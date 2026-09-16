namespace InfoManager.Domain.Entities.SFMS.Economics;

/// <summary>
/// Phân tích chi phí theo cây trồng hoặc nông trại
/// </summary>
public class CostAnalysis : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// ID lần trồng cây liên quan (tùy chọn)
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// Ngày phân tích
    /// </summary>
    public DateTimeOffset AnalysisDate { get; set; }

    /// <summary>
    /// Thời gian phân tích (Từ ngày)
    /// </summary>
    public DateTimeOffset FromDate { get; set; }

    /// <summary>
    /// Thời gian phân tích (Đến ngày)
    /// </summary>
    public DateTimeOffset ToDate { get; set; }

    /// <summary>
    /// Tổng chi phí trong kỳ
    /// </summary>
    public decimal TotalCost { get; set; }

    /// <summary>
    /// Phân bổ chi phí theo danh mục (JSON)
    /// </summary>
    [MaxLength(2000)]
    public string? CostBreakdown { get; set; }

    /// <summary>
    /// Chi phí trên mỗi hecta
    /// </summary>
    public decimal? CostPerHectare { get; set; }

    /// <summary>
    /// Chi phí trên mỗi đơn vị sản phẩm
    /// </summary>
    public decimal? CostPerUnit { get; set; }

    /// <summary>
    /// Tổng doanh thu trong kỳ
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// Lợi nhuận gộp
    /// </summary>
    public decimal GrossProfit { get; set; }

    /// <summary>
    /// Lợi nhuận ròng
    /// </summary>
    public decimal NetProfit { get; set; }

    /// <summary>
    /// Tỷ suất lợi nhuận (%)
    /// </summary>
    public decimal ProfitMargin { get; set; }

    /// <summary>
    /// Tỷ suất hoàn vốn đầu tư - ROI (%)
    /// </summary>
    public decimal ROI { get; set; }

    /// <summary>
    /// Phân tích điểm hòa vốn
    /// </summary>
    [MaxLength(500)]
    public string? BreakEvenAnalysis { get; set; }

    /// <summary>
    /// Điểm đánh giá hiệu quả chi phí
    /// </summary>
    public decimal? EfficiencyRating { get; set; }

    /// <summary>
    /// Khuyến nghị từ phân tích
    /// </summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    /// <summary>
    /// Người thực hiện phân tích
    /// </summary>
    [MaxLength(200)]
    public string? PreparedBy { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }

    public virtual CropPlanting? CropPlanting { get; set; }
}