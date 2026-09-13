namespace InfoManager.Shared.Dtos.SFMS.Economics;

// ======================== CostAnalysis ========================

public record CostAnalysisDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CropPlantingId,
    string? CropPlantingName,          // hoặc thông tin Crop/Field nếu cần
    DateTimeOffset AnalysisDate,
    DateTimeOffset FromDate,
    DateTimeOffset ToDate,
    decimal TotalCost,
    string? CostBreakdown,
    decimal? CostPerHectare,
    decimal? CostPerUnit,
    decimal TotalRevenue,
    decimal GrossProfit,
    decimal NetProfit,
    decimal ProfitMargin,
    decimal ROI,
    string? BreakEvenAnalysis,
    decimal? EfficiencyRating,
    string? Recommendations,
    string? PreparedBy,
    DateTimeOffset Created
);

public record CostAnalysisSummaryDto(
    string Id,
    string? FarmName,
    string? CropPlantingName,
    DateTimeOffset AnalysisDate,
    DateTimeOffset FromDate,
    DateTimeOffset ToDate,
    decimal TotalCost,
    decimal TotalRevenue,
    decimal NetProfit,
    decimal ProfitMargin,
    decimal ROI
);
public record SearchCostAnalysesRequest(
    string? Term,
    string? FarmId,
    string? CropPlantingId,
    DateTimeOffset? StartAnalysisDate,
    DateTimeOffset? EndAnalysisDate,
    DateTimeOffset? StartFromDate,
    DateTimeOffset? EndToDate,
    int PageNumber,
    int PageSize);
public record CreateCostAnalysisRequest(
    string FarmId,
    string? CropPlantingId ,
    DateTimeOffset AnalysisDate,
    DateTimeOffset FromDate,
    DateTimeOffset ToDate,
    decimal TotalCost,
    string? CostBreakdown ,
    decimal? CostPerHectare ,
    decimal? CostPerUnit ,
    decimal TotalRevenue,
    decimal GrossProfit,
    decimal NetProfit,
    decimal ProfitMargin,
    decimal ROI,
    string? BreakEvenAnalysis ,
    decimal? EfficiencyRating ,
    string? Recommendations ,
    string? PreparedBy 
);

public record UpdateCostAnalysisRequest(
    string Id,
    string? FarmId ,
    string? CropPlantingId ,
    DateTimeOffset? AnalysisDate ,
    DateTimeOffset? FromDate ,
    DateTimeOffset? ToDate ,
    decimal? TotalCost ,
    string? CostBreakdown ,
    decimal? CostPerHectare ,
    decimal? CostPerUnit ,
    decimal? TotalRevenue ,
    decimal? GrossProfit ,
    decimal? NetProfit ,
    decimal? ProfitMargin ,
    decimal? ROI ,
    string? BreakEvenAnalysis ,
    decimal? EfficiencyRating ,
    string? Recommendations ,
    string? PreparedBy 
);