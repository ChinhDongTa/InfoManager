using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class UpdateYieldModel
{
    /// <summary>ID bản ghi năng suất. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>ID đợt thu hoạch.</summary>
    public string? HarvestId { get; set; }

    /// <summary>Sản lượng thực tế. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ActualYield { get; set; }

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>Đơn vị. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? Unit { get; set; }

    /// <summary>Năng suất / hecta. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? YieldPerHectare { get; set; }

    /// <summary>Điểm chất lượng (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? QualityRating { get; set; }

    /// <summary>Tỷ lệ hao hụt (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? WastePercentage { get; set; }

    /// <summary>Chênh lệch (%).</summary>
    public decimal? YieldVariance { get; set; }

    /// <summary>Số ngày sinh trưởng. ≥ 0.</summary>
    [Range(0, int.MaxValue)]
    public int? GrowthDays { get; set; }

    /// <summary>Chi phí sản xuất. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ProductionCost { get; set; }

    /// <summary>Doanh thu. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? Revenue { get; set; }

    /// <summary>Lợi nhuận.</summary>
    public decimal? Profit { get; set; }

    /// <summary>ROI (%).</summary>
    public decimal? ROI { get; set; }

    /// <summary>Yếu tố ảnh hưởng. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? AffectingFactors { get; set; }

    /// <summary>Phân tích. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Analysis { get; set; }

    /// <summary>Khuyến nghị vụ sau. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Recommendations { get; set; }

    public UpdateYieldModel(string id, YieldDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropPlantingId = dto.CropPlantingId;
        HarvestId = dto.HarvestId;
        ActualYield = dto.ActualYield;
        ExpectedYield = dto.ExpectedYield;
        Unit = dto.Unit;
        YieldPerHectare = dto.YieldPerHectare;
        QualityRating = dto.QualityRating;
        WastePercentage = dto.WastePercentage;
        YieldVariance = dto.YieldVariance;
        GrowthDays = dto.GrowthDays;
        ProductionCost = dto.ProductionCost;
        Revenue = dto.Revenue;
        Profit = dto.Profit;
        ROI = dto.ROI;
        AffectingFactors = dto.AffectingFactors;
        Analysis = dto.Analysis;
        Recommendations = dto.Recommendations;
    }

    public UpdateYieldRequest CreateRequest()
    {
        return new UpdateYieldRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateYieldModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
