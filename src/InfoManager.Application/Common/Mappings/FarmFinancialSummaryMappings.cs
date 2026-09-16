using InfoManager.Application.Features.SFMS.Economics.Commands;
using InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class FarmFinancialSummaryMappings
{
    public static CreateFarmFinancialSummaryCommand ToCreateCommand(CreateFarmFinancialSummaryRequest request)
    => new()
    {
        FarmId = request.FarmId,
        Year = request.Year,
        Month = request.Month,
        TotalExpenses = request.TotalExpenses,
        TotalRevenue = request.TotalRevenue,
        Profit = request.Profit,
        CropCycleCount = request.CropCycleCount,
        TotalAreaCultivated = request.TotalAreaCultivated,
        AverageYieldPerHectare = request.AverageYieldPerHectare,
        AverageCostPerHectare = request.AverageCostPerHectare,
        AverageRevenuePerHectare = request.AverageRevenuePerHectare,
        HealthScore = request.HealthScore,
        KPIs = request.KPIs,
        Notes = request.Notes
    };

    public static SearchFarmFinancialSummariesQuery ToSearchQuery(SearchFarmFinancialSummariesRequest request) => new(
    request.Term,
    request.FarmId,
    request.Year,
    request.Month,
    request.PageNumber,
    request.PageSize);

    public static UpdateFarmFinancialSummaryCommand ToUpdateCommand(UpdateFarmFinancialSummaryRequest request, string id)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            Year = request.Year,
            Month = request.Month,
            TotalExpenses = request.TotalExpenses,
            TotalRevenue = request.TotalRevenue,
            Profit = request.Profit,
            CropCycleCount = request.CropCycleCount,
            TotalAreaCultivated = request.TotalAreaCultivated,
            AverageYieldPerHectare = request.AverageYieldPerHectare,
            AverageCostPerHectare = request.AverageCostPerHectare,
            AverageRevenuePerHectare = request.AverageRevenuePerHectare,
            HealthScore = request.HealthScore,
            KPIs = request.KPIs,
            Notes = request.Notes
        };
}