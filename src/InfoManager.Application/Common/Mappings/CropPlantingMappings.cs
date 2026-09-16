using InfoManager.Application.Features.SFMS.Agricultural.Commands;
using InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Provides mapping methods for converting between request objects and command/query objects related to crop planting operations.
/// </summary>
public static class CropPlantingMappings
{
    public static CreateCropPlantingCommand ToCreateCommand(CreateCropPlantingRequest request)
    {
        return new CreateCropPlantingCommand
        {
            FieldId = request.FieldId,
            CropId = request.CropId,
            CropVarietyId = request.CropVarietyId,
            CropScheduleId = request.CropScheduleId,
            PlantingDate = request.PlantingDate,
            ExpectedHarvestDate = request.ExpectedHarvestDate,
            ActualHarvestDate = request.ActualHarvestDate,
            PlantedArea = request.PlantedArea,
            QuantityPlanted = request.QuantityPlanted,
            PlantedUnit = request.PlantedUnit,
            Status = request.Status,
            Notes = request.Notes
        };
    }

    public static UpdateCropPlantingCommand ToUpdateCommand(string id, UpdateCropPlantingRequest request)
    {
        return new UpdateCropPlantingCommand
        {
            Id = id,
            PlantingCode = request.PlantingCode,
            FieldId = request.FieldId,
            CropId = request.CropId,
            CropVarietyId = request.CropVarietyId,
            CropScheduleId = request.CropScheduleId,
            PlantingDate = request.PlantingDate,
            ExpectedHarvestDate = request.ExpectedHarvestDate,
            ActualHarvestDate = request.ActualHarvestDate,
            PlantedArea = request.PlantedArea,
            QuantityPlanted = request.QuantityPlanted,
            PlantedUnit = request.PlantedUnit,
            Status = request.Status,
            Notes = request.Notes
        };
    }

    public static SearchCropPlantingsQuery ToSearchQuery(SearchCropPlantingRequest request)
    {
        return new SearchCropPlantingsQuery(request.Term,
                                                request.StartPlantingDate,
                                                request.EndPlantingDate,
                                                request.MinPlantedArea,
                                                request.MaxPlantedArea,
                                                request.Status,
                                                request.PageNumber,
                                                request.PageSize);
    }
}