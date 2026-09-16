namespace InfoManager.Domain.Entities.SFMS.Monitoring;

/// <summary>
/// Kết quả phân tích đất của thửa ruộng
/// </summary>
public class SoilAnalysis : BaseAuditableEntity
{
    /// <summary>
    /// ID thửa ruộng
    /// </summary>
    public string FieldId { get; set; }

    /// <summary>
    /// Ngày phân tích
    /// </summary>
    public DateTimeOffset AnalysisDate { get; set; }

    /// <summary>
    /// Tên phòng thí nghiệm
    /// </summary>
    [MaxLength(200)]
    public string? LabName { get; set; }

    /// <summary>
    /// Độ sâu lấy mẫu (cm)
    /// </summary>
    public decimal? SamplingDepth { get; set; }

    /// <summary>
    /// pH đất
    /// </summary>
    public decimal? PH { get; set; }

    /// <summary>
    /// Độ dẫn điện (dS/m)
    /// </summary>
    public decimal? ElectricalConductivity { get; set; }

    /// <summary>
    /// Hàm lượng đạm (mg/kg)
    /// </summary>
    public decimal? Nitrogen { get; set; }

    /// <summary>
    /// Hàm lượng lân (mg/kg)
    /// </summary>
    public decimal? Phosphorus { get; set; }

    /// <summary>
    /// Hàm lượng kali (mg/kg)
    /// </summary>
    public decimal? Potassium { get; set; }

    /// <summary>
    /// Hàm lượng canxi (mg/kg)
    /// </summary>
    public decimal? Calcium { get; set; }

    /// <summary>
    /// Hàm lượng magie (mg/kg)
    /// </summary>
    public decimal? Magnesium { get; set; }

    /// <summary>
    /// Hàm lượng lưu huỳnh (mg/kg)
    /// </summary>
    public decimal? Sulfur { get; set; }

    /// <summary>
    /// Tỷ lệ chất hữu cơ (%)
    /// </summary>
    public decimal? OrganicMatter { get; set; }

    /// <summary>
    /// Hàm lượng sắt (mg/kg)
    /// </summary>
    public decimal? Iron { get; set; }

    /// <summary>
    /// Hàm lượng mangan (mg/kg)
    /// </summary>
    public decimal? Manganese { get; set; }

    /// <summary>
    /// Hàm lượng kẽm (mg/kg)
    /// </summary>
    public decimal? Zinc { get; set; }

    /// <summary>
    /// Hàm lượng đồng (mg/kg)
    /// </summary>
    public decimal? Copper { get; set; }

    /// <summary>
    /// Hàm lượng bo (mg/kg)
    /// </summary>
    public decimal? Boron { get; set; }

    /// <summary>
    /// CEC — khả năng trao đổi cation (meq/100g)
    /// </summary>
    public decimal? CationExchangeCapacity { get; set; }

    /// <summary>
    /// Tỷ lệ cát (%)
    /// </summary>
    public decimal? SandPercentage { get; set; }

    /// <summary>
    /// Tỷ lệ thịt (%)
    /// </summary>
    public decimal? SiltPercentage { get; set; }

    /// <summary>
    /// Tỷ lệ sét (%)
    /// </summary>
    public decimal? ClayPercentage { get; set; }

    /// <summary>
    /// Đường dẫn báo cáo / file PDF
    /// </summary>
    [MaxLength(500)]
    public string? ReportUrl { get; set; }

    /// <summary>
    /// Nhận xét của phòng thí nghiệm
    /// </summary>
    [MaxLength(1000)]
    public string? LabRemarks { get; set; }

    /// <summary>
    /// Khuyến nghị dựa trên kết quả
    /// </summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public virtual Field? Field { get; set; }
}