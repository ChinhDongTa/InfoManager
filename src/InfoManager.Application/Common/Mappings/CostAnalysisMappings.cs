using InfoManager.Application.Features.SFMS.Economics.Commands;

namespace InfoManager.Application.Common.Mappings;

public static class CostAnalysisMappings
{
    public static CreateCostAnalysisCommand ToCreateCommand(CreateCostAnalysisRequest request)
    => new()
    {
        FarmId = request.FarmId,
        CropPlantingId = request.CropPlantingId,
        AnalysisDate = request.AnalysisDate,
        FromDate = request.FromDate,
        ToDate = request.ToDate,
        TotalCost = request.TotalCost,
        CostBreakdown = request.CostBreakdown,
        CostPerHectare = request.CostPerHectare,
        CostPerUnit = request.CostPerUnit,
        TotalRevenue = request.TotalRevenue,
        GrossProfit = request.GrossProfit,
        NetProfit = request.NetProfit,
        ProfitMargin = request.ProfitMargin,
        ROI = request.ROI,
        BreakEvenAnalysis = request.BreakEvenAnalysis,
        EfficiencyRating = request.EfficiencyRating,
        Recommendations = request.Recommendations,
        PreparedBy = request.PreparedBy
    };

    public static UpdateCostAnalysisCommand ToUpdateCommand(UpdateCostAnalysisRequest request, string id)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            AnalysisDate = request.AnalysisDate,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            TotalCost = request.TotalCost,
            CostBreakdown = request.CostBreakdown,
            CostPerHectare = request.CostPerHectare,
            CostPerUnit = request.CostPerUnit,
            TotalRevenue = request.TotalRevenue,
            GrossProfit = request.GrossProfit,
            NetProfit = request.NetProfit,
            ProfitMargin = request.ProfitMargin,
            ROI = request.ROI,
            BreakEvenAnalysis = request.BreakEvenAnalysis,
            EfficiencyRating = request.EfficiencyRating,
            Recommendations = request.Recommendations,
            PreparedBy = request.PreparedBy
        };
}
