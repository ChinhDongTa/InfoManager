using InfoManager.Shared.Dtos.SFMS.Economics;

namespace InfoManager.ModelClient.SFMS.Economics;

public class UpdateCostAnalysisModel
{
    /// <summary>ID phân tích chi phí. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>ID lượt trồng liên kết.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>Ngày phân tích.</summary>
    public DateTimeOffset? AnalysisDate { get; set; }

    /// <summary>Từ ngày.</summary>
    public DateTimeOffset? FromDate { get; set; }

    /// <summary>Đến ngày.</summary>
    public DateTimeOffset? ToDate { get; set; }

    /// <summary>Tổng chi phí.</summary>
    public decimal? TotalCost { get; set; }

    /// <summary>Cơ cấu chi phí.</summary>
    public string? CostBreakdown { get; set; }

    /// <summary>Chi phí trên hecta.</summary>
    public decimal? CostPerHectare { get; set; }

    /// <summary>Chi phí trên đơn vị sản phẩm.</summary>
    public decimal? CostPerUnit { get; set; }

    /// <summary>Tổng doanh thu.</summary>
    public decimal? TotalRevenue { get; set; }

    /// <summary>Lợi nhuận gộp.</summary>
    public decimal? GrossProfit { get; set; }

    /// <summary>Lợi nhuận ròng.</summary>
    public decimal? NetProfit { get; set; }

    /// <summary>Tỷ suất lợi nhuận.</summary>
    public decimal? ProfitMargin { get; set; }

    /// <summary>Tỷ suất hoàn vốn.</summary>
    public decimal? ROI { get; set; }

    /// <summary>Phân tích hòa vốn.</summary>
    public string? BreakEvenAnalysis { get; set; }

    /// <summary>Điểm hiệu quả.</summary>
    public decimal? EfficiencyRating { get; set; }

    /// <summary>Khuyến nghị.</summary>
    public string? Recommendations { get; set; }

    /// <summary>Người lập.</summary>
    public string? PreparedBy { get; set; }

    public UpdateCostAnalysisModel(string id, CostAnalysisDto dto)
    {
        Id = id;
        FarmId = dto.FarmId;
        CropPlantingId = dto.CropPlantingId;
        AnalysisDate = dto.AnalysisDate;
        FromDate = dto.FromDate;
        ToDate = dto.ToDate;
        TotalCost = dto.TotalCost;
        CostBreakdown = dto.CostBreakdown;
        CostPerHectare = dto.CostPerHectare;
        CostPerUnit = dto.CostPerUnit;
        TotalRevenue = dto.TotalRevenue;
        GrossProfit = dto.GrossProfit;
        NetProfit = dto.NetProfit;
        ProfitMargin = dto.ProfitMargin;
        ROI = dto.ROI;
        BreakEvenAnalysis = dto.BreakEvenAnalysis;
        EfficiencyRating = dto.EfficiencyRating;
        Recommendations = dto.Recommendations;
        PreparedBy = dto.PreparedBy;
    }

    public UpdateCostAnalysisRequest CreateRequest()
    {
        return new UpdateCostAnalysisRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            CropPlantingId: this.CropPlantingId,
            AnalysisDate: this.AnalysisDate,
            FromDate: this.FromDate,
            ToDate: this.ToDate,
            TotalCost: this.TotalCost,
            CostBreakdown: this.CostBreakdown,
            CostPerHectare: this.CostPerHectare,
            CostPerUnit: this.CostPerUnit,
            TotalRevenue: this.TotalRevenue,
            GrossProfit: this.GrossProfit,
            NetProfit: this.NetProfit,
            ProfitMargin: this.ProfitMargin,
            ROI: this.ROI,
            BreakEvenAnalysis: this.BreakEvenAnalysis,
            EfficiencyRating: this.EfficiencyRating,
            Recommendations: this.Recommendations,
            PreparedBy: this.PreparedBy
        );
    }

    public bool HasChanges(UpdateCostAnalysisModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}