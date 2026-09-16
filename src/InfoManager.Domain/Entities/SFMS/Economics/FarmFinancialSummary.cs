namespace InfoManager.Domain.Entities.SFMS.Economics;

/// <summary>
/// Tổng hợp tài chính phục vụ báo cáo
/// </summary>
public class FarmFinancialSummary : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// Năm của bản tổng hợp
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Tháng của bản tổng hợp (1-12), null nếu là tổng hợp năm
    /// </summary>
    public int? Month { get; set; }

    /// <summary>
    /// Tổng chi phí trong kỳ
    /// </summary>
    public decimal TotalExpenses { get; set; }

    /// <summary>
    /// Tổng doanh thu trong kỳ
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// Tổng lợi nhuận / lỗ
    /// </summary>
    public decimal Profit { get; set; }

    /// <summary>
    /// Số chu kỳ trồng cây
    /// </summary>
    public int? CropCycleCount { get; set; }

    /// <summary>
    /// Tổng diện tích canh tác (hecta)
    /// </summary>
    public decimal? TotalAreaCultivated { get; set; }

    /// <summary>
    /// Năng suất trung bình trên mỗi hecta
    /// </summary>
    public decimal? AverageYieldPerHectare { get; set; }

    /// <summary>
    /// Chi phí trung bình trên mỗi hecta
    /// </summary>
    public decimal? AverageCostPerHectare { get; set; }

    /// <summary>
    /// Doanh thu trung bình trên mỗi hecta
    /// </summary>
    public decimal? AverageRevenuePerHectare { get; set; }

    /// <summary>
    /// Điểm sức khỏe tài chính (0-100)
    /// </summary>
    public decimal? HealthScore { get; set; }

    /// <summary>
    /// Các chỉ số hiệu suất chính (KPIs)
    /// </summary>
    [MaxLength(1000)]
    public string? KPIs { get; set; }

    /// <summary>
    /// Ghi chú tổng hợp
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }
}