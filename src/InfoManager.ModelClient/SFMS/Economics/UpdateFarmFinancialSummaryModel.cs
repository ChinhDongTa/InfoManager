using InfoManager.Shared.Dtos.SFMS.Economics;

namespace InfoManager.ModelClient.SFMS.Economics;

public class UpdateFarmFinancialSummaryModel
{
    /// <summary>ID tổng hợp tài chính. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>Năm.</summary>
    public int? Year { get; set; }

    /// <summary>Tháng.</summary>
    public int? Month { get; set; }

    /// <summary>Tổng chi phí.</summary>
    public decimal? TotalExpenses { get; set; }

    /// <summary>Tổng doanh thu.</summary>
    public decimal? TotalRevenue { get; set; }

    /// <summary>Lợi nhuận.</summary>
    public decimal? Profit { get; set; }

    /// <summary>Số chu kỳ canh tác.</summary>
    public int? CropCycleCount { get; set; }

    /// <summary>Tổng diện tích canh tác.</summary>
    public decimal? TotalAreaCultivated { get; set; }

    /// <summary>Năng suất trung bình / hecta.</summary>
    public decimal? AverageYieldPerHectare { get; set; }

    /// <summary>Chi phí trung bình / hecta.</summary>
    public decimal? AverageCostPerHectare { get; set; }

    /// <summary>Doanh thu trung bình / hecta.</summary>
    public decimal? AverageRevenuePerHectare { get; set; }

    /// <summary>Điểm sức khỏe tài chính.</summary>
    public decimal? HealthScore { get; set; }

    /// <summary>Chỉ số KPI.</summary>
    public string? KPIs { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateFarmFinancialSummaryModel(string id, FarmFinancialSummaryDto dto)
    {
        Id = id;
        FarmId = dto.FarmId;
        Year = dto.Year;
        Month = dto.Month;
        TotalExpenses = dto.TotalExpenses;
        TotalRevenue = dto.TotalRevenue;
        Profit = dto.Profit;
        CropCycleCount = dto.CropCycleCount;
        TotalAreaCultivated = dto.TotalAreaCultivated;
        AverageYieldPerHectare = dto.AverageYieldPerHectare;
        AverageCostPerHectare = dto.AverageCostPerHectare;
        AverageRevenuePerHectare = dto.AverageRevenuePerHectare;
        HealthScore = dto.HealthScore;
        KPIs = dto.KPIs;
        Notes = dto.Notes;
    }

    public UpdateFarmFinancialSummaryRequest CreateRequest()
    {
        return new UpdateFarmFinancialSummaryRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            Year: this.Year,
            Month: this.Month,
            TotalExpenses: this.TotalExpenses,
            TotalRevenue: this.TotalRevenue,
            Profit: this.Profit,
            CropCycleCount: this.CropCycleCount,
            TotalAreaCultivated: this.TotalAreaCultivated,
            AverageYieldPerHectare: this.AverageYieldPerHectare,
            AverageCostPerHectare: this.AverageCostPerHectare,
            AverageRevenuePerHectare: this.AverageRevenuePerHectare,
            HealthScore: this.HealthScore,
            KPIs: this.KPIs,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateFarmFinancialSummaryModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}