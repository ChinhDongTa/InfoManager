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
    SoilCondition? SoilCondition,
    string? SoilConditionName,
    decimal? Elevation,
    decimal? Latitude,
    decimal? Longitude,
    FieldStatus Status,
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
    string? Term,
    string? FarmId,
    SoilCondition? SoilCondition,
    FieldStatus? Status,
    DateTimeOffset? StartLastPreparationDate,
    DateTimeOffset? EndLastPreparationDate,
    bool? HasIrrigation,
    int PageNumber,
    int PageSize
);

public record CreateFieldRequest(
    string Name,
    string? Description,
    decimal Area,
    string FarmId,
    string? SoilType,
    SoilCondition? SoilCondition,
    decimal? Elevation,
    decimal? Latitude,
    decimal? Longitude,
    FieldStatus Status,
    DateTimeOffset? LastPreparationDate,
    string? DrainageCondition,
    bool HasIrrigation = false
);

public record UpdateFieldRequest(
    string Id,
    string? Name,
    string? Description,
    decimal? Area,
    string? FarmId,
    string? SoilType,
    SoilCondition? SoilCondition,
    decimal? Elevation,
    decimal? Latitude,
    decimal? Longitude,
    FieldStatus? Status,
    DateTimeOffset? LastPreparationDate,
    string? DrainageCondition,
    bool? HasIrrigation
);