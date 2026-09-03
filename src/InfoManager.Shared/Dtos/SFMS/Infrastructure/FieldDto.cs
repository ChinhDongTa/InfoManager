namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

// ======================== Field ========================

public record FieldDto(
    string Id,
    string Name,
    string? Description,
    decimal Area,
    string FarmId,
    string? FarmName,
    string? SoilType,
    string? SoilConditionName,
    decimal? Elevation,
    decimal? Latitude,
    decimal? Longitude,
    string StatusName,
    DateTimeOffset? LastPreparationDate,
    string? DrainageCondition,
    bool HasIrrigation,
    int CropPlantingCount,
    int SensorCount,
    int SoilAnalysisCount,
    int TaskCount,
    DateTimeOffset Created
);

public record FieldSummaryDto(
    string Id,
    string Name,
    string? FarmName,
    decimal Area,
    string? SoilType,
    string? SoilConditionName,
    string StatusName,
    bool HasIrrigation
);

public record SearchFieldsRequest(
    string? Term ,
    string? FarmId ,
    SoilCondition? SoilCondition,
    FieldStatus? Status,
    DateTimeOffset? StartLastPreparationDate,
    DateTimeOffset? EndLastPreparationDate,
    bool? HasIrrigation,
    int PageNumber ,
    int PageSize
);

public record CreateFieldRequest(
    string Name,
    string? Description = null,
    decimal Area = 0,
    string FarmId = "",
    string? SoilType = null,
    SoilCondition? SoilCondition = null,
    decimal? Elevation = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    FieldStatus Status = FieldStatus.Vacant,
    DateTimeOffset? LastPreparationDate = null,
    string? DrainageCondition = null,
    bool HasIrrigation = false
);

public record UpdateFieldRequest(
    string Id,
    string? Name = null,
    string? Description = null,
    decimal? Area = null,
    string? FarmId = null,
    string? SoilType = null,
    SoilCondition? SoilCondition = null,
    decimal? Elevation = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    FieldStatus? Status = null,
    DateTimeOffset? LastPreparationDate = null,
    string? DrainageCondition = null,
    bool? HasIrrigation = null
);