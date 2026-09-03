namespace InfoManager.Shared.Dtos.SFMS.Economics;

// ======================== FarmFinancialSummary ========================

public record FarmFinancialSummaryDto(
    string Id,
    string FarmId,
    string? FarmName,
    int Year,
    int? Month,
    decimal TotalExpenses,
    decimal TotalRevenue,
    decimal Profit,
    int? CropCycleCount,
    decimal? TotalAreaCultivated,
    decimal? AverageYieldPerHectare,
    decimal? AverageCostPerHectare,
    decimal? AverageRevenuePerHectare,
    decimal? HealthScore,
    string? KPIs,
    string? Notes,
    DateTimeOffset Created
);

public record FarmFinancialSummarySummaryDto(
    string Id,
    string? FarmName,
    int Year,
    int? Month,
    decimal TotalExpenses,
    decimal TotalRevenue,
    decimal Profit,
    decimal? HealthScore
);

public record CreateFarmFinancialSummaryRequest(
    string FarmId,
    int Year,
    int? Month,
    decimal TotalExpenses,
    decimal TotalRevenue,
    decimal Profit,
    int? CropCycleCount,
    decimal? TotalAreaCultivated,
    decimal? AverageYieldPerHectare,
    decimal? AverageCostPerHectare,
    decimal? AverageRevenuePerHectare,
    decimal? HealthScore,
    string? KPIs,
    string? Notes
);

public record UpdateFarmFinancialSummaryRequest(
    string Id,
    string? FarmId,
    int? Year,
    int? Month,
    decimal? TotalExpenses,
    decimal? TotalRevenue,
    decimal? Profit,
    int? CropCycleCount,
    decimal? TotalAreaCultivated,
    decimal? AverageYieldPerHectare,
    decimal? AverageCostPerHectare,
    decimal? AverageRevenuePerHectare,
    decimal? HealthScore,
    string? KPIs,
    string? Notes
);