using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class CreateSoilAnalysisModel
{
    /// <summary>
    /// ID thửa ruộng
    /// </summary>
    [Required]
    public string FieldId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày phân tích
    /// </summary>
    [Required]
    public DateTimeOffset AnalysisDate { get; set; }

    /// <summary>
    /// Tên phòng thí nghiệm
    /// </summary>
    [MaxLength(200)]
    public string? LabName { get; set; }

    /// <summary>
    /// Độ sâu lấy mẫu (cm)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? SamplingDepth { get; set; }

    /// <summary>
    /// pH đất
    /// </summary>
    [Range(0, 14)]
    public decimal? PH { get; set; }

    /// <summary>
    /// Độ dẫn điện (dS/m)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ElectricalConductivity { get; set; }

    /// <summary>
    /// Đạm (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Nitrogen { get; set; }

    /// <summary>
    /// Lân (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Phosphorus { get; set; }

    /// <summary>
    /// Kali (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Potassium { get; set; }

    /// <summary>
    /// Canxi (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Calcium { get; set; }

    /// <summary>
    /// Magie (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Magnesium { get; set; }

    /// <summary>
    /// Lưu huỳnh (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Sulfur { get; set; }

    /// <summary>
    /// Chất hữu cơ (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? OrganicMatter { get; set; }

    /// <summary>
    /// Sắt (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Iron { get; set; }

    /// <summary>
    /// Mangan (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Manganese { get; set; }

    /// <summary>
    /// Kẽm (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Zinc { get; set; }

    /// <summary>
    /// Đồng (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Copper { get; set; }

    /// <summary>
    /// Bo (mg/kg)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? Boron { get; set; }

    /// <summary>
    /// CEC (meq/100g)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? CationExchangeCapacity { get; set; }

    /// <summary>
    /// Cát (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? SandPercentage { get; set; }

    /// <summary>
    /// Thịt (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? SiltPercentage { get; set; }

    /// <summary>
    /// Sét (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? ClayPercentage { get; set; }

    /// <summary>
    /// Đường dẫn báo cáo
    /// </summary>
    [MaxLength(500)]
    public string? ReportUrl { get; set; }

    /// <summary>
    /// Nhận xét phòng thí nghiệm
    /// </summary>
    [MaxLength(1000)]
    public string? LabRemarks { get; set; }

    /// <summary>
    /// Khuyến nghị
    /// </summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public CreateSoilAnalysisRequest CreateRequest()
    {
        return new CreateSoilAnalysisRequest
        (
            FieldId: this.FieldId,
            AnalysisDate: this.AnalysisDate,
            LabName: this.LabName,
            SamplingDepth: this.SamplingDepth,
            PH: this.PH,
            ElectricalConductivity: this.ElectricalConductivity,
            Nitrogen: this.Nitrogen,
            Phosphorus: this.Phosphorus,
            Potassium: this.Potassium,
            Calcium: this.Calcium,
            Magnesium: this.Magnesium,
            Sulfur: this.Sulfur,
            OrganicMatter: this.OrganicMatter,
            Iron: this.Iron,
            Manganese: this.Manganese,
            Zinc: this.Zinc,
            Copper: this.Copper,
            Boron: this.Boron,
            CationExchangeCapacity: this.CationExchangeCapacity,
            SandPercentage: this.SandPercentage,
            SiltPercentage: this.SiltPercentage,
            ClayPercentage: this.ClayPercentage,
            ReportUrl: this.ReportUrl,
            LabRemarks: this.LabRemarks,
            Recommendations: this.Recommendations
        );
    }
}