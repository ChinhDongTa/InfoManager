using InfoManager.Application.Features.SFMS.Planning.Commands;
using InfoManager.Application.Features.SFMS.Planning.Queries.Gets;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.Application.Common.Mappings;

public static   class CropCycleMappings
{
    public static CreateCropCycleCommand ToCreateCommand(CreateCropCycleRequest request)
    => new()
    {
        FarmId = request.FarmId,
        CycleName = request.CycleName,
        CropId = request.CropId,
        CropVarietyId = request.CropVarietyId,
        CropScheduleId = request.CropScheduleId,
        StartYear = request.StartYear,
        Season = request.Season,
        PlannedPlantingDate = request.PlannedPlantingDate,
        PlannedHarvestDate = request.PlannedHarvestDate,
        PlannedArea = request.PlannedArea,
        Status = request.Status,
        EstimatedCost = request.EstimatedCost,
        EstimatedRevenue = request.EstimatedRevenue,
        EstimatedProfit = request.EstimatedProfit,
        ExpectedYield = request.ExpectedYield,
        TargetMarket = request.TargetMarket,
        TargetSellingPrice = request.TargetSellingPrice,
        Notes = request.Notes
    };

    public static SearchCropCyclesQuery ToSearchQuery(SearchCropCycleRequest request)
    => new(request.Term, request.StartYear, request.Status, request.PageNumber, request.PageSize);

    public static UpdateCropCycleCommand ToUpdateCommand(UpdateCropCycleRequest request, string id)
    => new()
    {
        Id = id,
        FarmId = request.FarmId,
        CycleName = request.CycleName,
        CropId = request.CropId,
        CropVarietyId = request.CropVarietyId,
        CropScheduleId = request.CropScheduleId,
        StartYear = request.StartYear,
        Season = request.Season,
        PlannedPlantingDate = request.PlannedPlantingDate,
        PlannedHarvestDate = request.PlannedHarvestDate,
        PlannedArea = request.PlannedArea,
        Status = request.Status,
        EstimatedCost = request.EstimatedCost,
        EstimatedRevenue = request.EstimatedRevenue,
        EstimatedProfit = request.EstimatedProfit,
        ExpectedYield = request.ExpectedYield,
        TargetMarket = request.TargetMarket,
        TargetSellingPrice = request.TargetSellingPrice,
        Notes = request.Notes
    };
}
