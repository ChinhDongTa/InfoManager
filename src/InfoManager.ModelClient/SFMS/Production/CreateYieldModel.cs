using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class CreateYieldModel
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    [Required]
    public string CropPlantingId { get; set; } = string.Empty;

    /// <summary>
    /// ID đợt thu hoạch
    /// </summary>
    public string? HarvestId { get; set; }

    /// <summary>
    /// Sản lượng thực tế
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public decimal ActualYield { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// Năng suất / hecta
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? YieldPerHectare { get; set; }

    /// <summary>
    /// Điểm chất lượng (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? QualityRating { get; set; }

    /// <summary>
    /// Tỷ lệ hao hụt (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? WastePercentage { get; set; }

    /// <summary>
    /// Chênh lệch (%)
    /// </summary>
    public decimal? YieldVariance { get; set; }

    /// <summary>
    /// Số ngày sinh trưởng
    /// </summary>
    [Range(0, int.MaxValue)]
    public int? GrowthDays { get; set; }

    /// <summary>
    /// Chi phí sản xuất
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ProductionCost { get; set; }

    /// <summary>
    /// Doanh thu
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Revenue { get; set; }

    /// <summary>
    /// Lợi nhuận
    /// </summary>
    public decimal? Profit { get; set; }

    /// <summary>
    /// ROI (%)
    /// </summary>
    public decimal? ROI { get; set; }

    /// <summary>
    /// Yếu tố ảnh hưởng
    /// </summary>
    [MaxLength(1000)]
    public string? AffectingFactors { get; set; }

    /// <summary>
    /// Phân tích
    /// </summary>
    [MaxLength(1000)]
    public string? Analysis { get; set; }

    /// <summary>
    /// Khuyến nghị vụ sau
    /// </summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public CreateYieldRequest CreateRequest()
    {
        return new CreateYieldRequest
        (
            CropPlantingId: this.CropPlantingId,
            HarvestId: this.HarvestId,
            ActualYield: this.ActualYield,
            ExpectedYield: this.ExpectedYield,
            Unit: this.Unit,
            YieldPerHectare: this.YieldPerHectare,
            QualityRating: this.QualityRating,
            WastePercentage: this.WastePercentage,
            YieldVariance: this.YieldVariance,
            GrowthDays: this.GrowthDays,
            ProductionCost: this.ProductionCost,
            Revenue: this.Revenue,
            Profit: this.Profit,
            ROI: this.ROI,
            AffectingFactors: this.AffectingFactors,
            Analysis: this.Analysis,
            Recommendations: this.Recommendations
        );
    }
}