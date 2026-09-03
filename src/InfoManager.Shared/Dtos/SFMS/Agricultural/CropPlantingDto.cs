namespace InfoManager.Shared.Dtos.SFMS.Agricultural;

// ======================== CropPlanting ========================

public record CropPlantingDto(
    string Id,
    string PlantingCode,
    string FieldId,
    string? FieldName,
    string CropId,
    string? CropName,
    string? CropVarietyId,
    string? CropVarietyName,
    string? CropScheduleId,
    string? CropScheduleName,
    DateTimeOffset PlantingDate,
    DateTimeOffset? ExpectedHarvestDate,
    DateTimeOffset? ActualHarvestDate,
    decimal PlantedArea,
    decimal? QuantityPlanted,
    string? PlantedUnit,
    string? StatusName,
    string? Notes,
    DateTimeOffset Created
);

public record CropPlantingSummaryDto(
    string Id,
    string PlantingCode,
    string? CropVarietyName,
    DateTimeOffset PlantingDate,
    DateTimeOffset? ExpectedHarvestDate,
    decimal PlantedArea,
    string StatusName
);

public record CreateCropPlantingRequest(
    string FieldId,
    string CropId,
    string? CropVarietyId,
    string? CropScheduleId,
    DateTimeOffset PlantingDate,
    DateTimeOffset? ActualHarvestDate,
    DateTimeOffset? ExpectedHarvestDate,
    decimal PlantedArea ,
    decimal? QuantityPlanted,
    string? PlantedUnit,
    PlantingStatus Status,
    string? Notes
);

public record UpdateCropPlantingRequest(
    string Id,
    string? PlantingCode,
    string? FieldId,
    string? CropId,
    string? CropVarietyId,
    string? CropScheduleId,
    DateTimeOffset? PlantingDate,
    DateTimeOffset? ExpectedHarvestDate,
    DateTimeOffset? ActualHarvestDate,
    decimal? PlantedArea,
    decimal? QuantityPlanted,
    string? PlantedUnit,
    PlantingStatus? Status,
    string? Notes
);
public record SearchCropPlantingRequest(string? Term,
                                        DateTimeOffset? StartPlantingDate,
                                        DateTimeOffset? EndPlantingDate,
                                        decimal? MinPlantedArea,
                                        decimal? MaxPlantedArea,
                                        PlantingStatus? Status,
                                        int PageNumber,
                                        int PageSize);