using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class UpdateSoilAnalysisModel
{
    /// <summary>ID bản ghi. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID thửa ruộng.</summary>
    public string? FieldId { get; set; }

    /// <summary>Ngày phân tích.</summary>
    public DateTimeOffset? AnalysisDate { get; set; }

    /// <summary>Tên phòng thí nghiệm. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? LabName { get; set; }

    /// <summary>Độ sâu lấy mẫu (cm). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? SamplingDepth { get; set; }

    /// <summary>pH đất. 0–14.</summary>
    [Range(0, 14)]
    public decimal? PH { get; set; }

    /// <summary>Độ dẫn điện (dS/m). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ElectricalConductivity { get; set; }

    /// <summary>Đạm (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Nitrogen { get; set; }

    /// <summary>Lân (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Phosphorus { get; set; }

    /// <summary>Kali (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Potassium { get; set; }

    /// <summary>Canxi (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Calcium { get; set; }

    /// <summary>Magie (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Magnesium { get; set; }

    /// <summary>Lưu huỳnh (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Sulfur { get; set; }

    /// <summary>Chất hữu cơ (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? OrganicMatter { get; set; }

    /// <summary>Sắt (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Iron { get; set; }

    /// <summary>Mangan (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Manganese { get; set; }

    /// <summary>Kẽm (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Zinc { get; set; }

    /// <summary>Đồng (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Copper { get; set; }

    /// <summary>Bo (mg/kg). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Boron { get; set; }

    /// <summary>CEC (meq/100g). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? CationExchangeCapacity { get; set; }

    /// <summary>Cát (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? SandPercentage { get; set; }

    /// <summary>Thịt (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? SiltPercentage { get; set; }

    /// <summary>Sét (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? ClayPercentage { get; set; }

    /// <summary>Đường dẫn báo cáo. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? ReportUrl { get; set; }

    /// <summary>Nhận xét phòng thí nghiệm. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? LabRemarks { get; set; }

    /// <summary>Khuyến nghị. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public UpdateSoilAnalysisModel(string id, SoilAnalysisDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FieldId = dto.FieldId;
        AnalysisDate = dto.AnalysisDate;
        LabName = dto.LabName;
        SamplingDepth = dto.SamplingDepth;
        PH = dto.PH;
        ElectricalConductivity = dto.ElectricalConductivity;
        Nitrogen = dto.Nitrogen;
        Phosphorus = dto.Phosphorus;
        Potassium = dto.Potassium;
        Calcium = dto.Calcium;
        Magnesium = dto.Magnesium;
        Sulfur = dto.Sulfur;
        OrganicMatter = dto.OrganicMatter;
        Iron = dto.Iron;
        Manganese = dto.Manganese;
        Zinc = dto.Zinc;
        Copper = dto.Copper;
        Boron = dto.Boron;
        CationExchangeCapacity = dto.CationExchangeCapacity;
        SandPercentage = dto.SandPercentage;
        SiltPercentage = dto.SiltPercentage;
        ClayPercentage = dto.ClayPercentage;
        ReportUrl = dto.ReportUrl;
        LabRemarks = dto.LabRemarks;
        Recommendations = dto.Recommendations;
    }

    public UpdateSoilAnalysisRequest CreateRequest()
    {
        return new UpdateSoilAnalysisRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateSoilAnalysisModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}