namespace InfoManager.Shared.Dtos.SFMS.Agricultural;

// ======================== GrowthStage ========================

public record GrowthStageDto(
    string Id,
    string StageName,
    string CropId,
    string? CropName,
    string? CropScheduleId,
    string? CropScheduleName,
    int StageSequence,
    int DaysAfterPlanting,
    int? StageDuration,
    string? Description,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? WaterRequirement,
    decimal? NitrogenRequirement,
    decimal? PhosphorusRequirement,
    decimal? PotassiumRequirement,
    string? CommonPests,
    string? CommonDiseases,
    string? ManagementActivities,
    DateTimeOffset Created
);

public record GrowthStageSummaryDto(
    string Id,
    string StageName,
    string? CropName,
    int StageSequence,
    int DaysAfterPlanting,
    int? StageDuration,
    string? Description
);

public record SearchGrowthStageRequest(string? Term,
                                       int? MinStageSequence,
                                       int? MaxStageSequence,
                                       int? MinDaysAfterPlanting,
                                       int? MaxDaysAfterPlanting,
                                       decimal? Temperature,
                                       decimal? Humidity,
                                       int PageNumber,
                                       int PageSize);

public record CreateGrowthStageRequest(
    string StageName,
    string CropId,
    string? CropScheduleId,
    int StageSequence,
    int DaysAfterPlanting,
    int? StageDuration,
    string? Description,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? WaterRequirement,
    decimal? NitrogenRequirement,
    decimal? PhosphorusRequirement,
    decimal? PotassiumRequirement,
    string? CommonPests,
    string? CommonDiseases,
    string? ManagementActivities
);

public record UpdateGrowthStageRequest(
    string Id,
    string? StageName,
    string? CropId,
    string? CropScheduleId,
    int? StageSequence,
    int? DaysAfterPlanting,
    int? StageDuration,
    string? Description,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? WaterRequirement,
    decimal? NitrogenRequirement,
    decimal? PhosphorusRequirement,
    decimal? PotassiumRequirement,
    string? CommonPests,
    string? CommonDiseases,
    string? ManagementActivities
);