using InfoManager.Application.Features.SFMS.Agricultural.Commands;
using InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class CropScheduleMappings
{
    public static CreateCropScheduleCommand ToCreateCommand(CreateCropScheduleRequest request)
        => new()
        {
            CropId = request.CropId,
            ScheduleName = request.ScheduleName,
            CropVarietyId = request.CropVarietyId,
            DaysToHarvest = request.DaysToHarvest,
            EstimatedCost = request.EstimatedCost,
            ExpectedYield = request.ExpectedYield,
            FertilizationSchedule = request.FertilizationSchedule,
            HarvestDateRange = request.HarvestDateRange,
            IrrigationSchedule = request.IrrigationSchedule,
            IsActive = request.IsActive,
            Notes = request.Notes,
            PesticideSchedule = request.PesticideSchedule,
            PlantingDateRange = request.PlantingDateRange,
            PlantingSeason = request.PlantingSeason,
            PlantSpacing = request.PlantSpacing,
            RowSpacing = request.RowSpacing
        };

    public static UpdateCropScheduleCommand ToUpdateCommand(string id, UpdateCropScheduleRequest request)
       => new()
       {
           Id = id,
           CropId = request.CropId,
           ScheduleName = request.ScheduleName,
           CropVarietyId = request.CropVarietyId,
           DaysToHarvest = request.DaysToHarvest,
           EstimatedCost = request.EstimatedCost,
           ExpectedYield = request.ExpectedYield,
           FertilizationSchedule = request.FertilizationSchedule,
           HarvestDateRange = request.HarvestDateRange,
           IrrigationSchedule = request.IrrigationSchedule,
           IsActive = request.IsActive,
           Notes = request.Notes,
           PesticideSchedule = request.PesticideSchedule,
           PlantingDateRange = request.PlantingDateRange,
           PlantingSeason = request.PlantingSeason,
           PlantSpacing = request.PlantSpacing,
           RowSpacing = request.RowSpacing
       };

    public static SearchCropSchedulesQuery ToSearchQuery(SearchCropSchedulesRequest request)
        => new(request.Term,
               request.MinDaysToHarvest,
               request.MaxDaysToHarvest,
               request.MinExpectedYield,
               request.MaxExpectedYield,
               request.IsActive,
               request.PageNumber,
               request.PageSize);
}