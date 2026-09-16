namespace InfoManager.Shared.Dtos.SFMS.Agricultural;

// ======================== CropSchedule ========================

public record CropScheduleDto(
    string Id,
    string ScheduleName,
    string CropId,
    string? CropName,
    string? CropVarietyId,
    string? CropVarietyName,
    string? PlantingSeason,
    string? PlantingDateRange,
    string? HarvestDateRange,
    int DaysToHarvest,
    decimal? PlantSpacing,
    decimal? RowSpacing,
    string? IrrigationSchedule,
    string? FertilizationSchedule,
    string? PesticideSchedule,
    decimal? ExpectedYield,
    decimal? EstimatedCost,
    bool IsActive,
    string? Notes,
    DateTimeOffset Created
);

public record CropScheduleSummaryDto(
    string Id,
    string ScheduleName,
    string? CropName,
    string? CropVarietyName,
    string? PlantingSeason,
    int DaysToHarvest,
    decimal? ExpectedYield,
    bool IsActive
);

public record CreateCropScheduleRequest(
    string ScheduleName,
    string CropId,
    string? CropVarietyId,
    string? PlantingSeason,
    string? PlantingDateRange,
    string? HarvestDateRange,
    int DaysToHarvest,
    decimal? PlantSpacing,
    decimal? RowSpacing,
    string? IrrigationSchedule,
    string? FertilizationSchedule,
    string? PesticideSchedule,
    decimal? ExpectedYield,
    decimal? EstimatedCost,
    bool IsActive,
    string? Notes
);

public record UpdateCropScheduleRequest(
    string Id,
    string? ScheduleName,
    string? CropId,
    string? CropVarietyId,
    string? PlantingSeason,
    string? PlantingDateRange,
    string? HarvestDateRange,
    int? DaysToHarvest,
    decimal? PlantSpacing,
    decimal? RowSpacing,
    string? IrrigationSchedule,
    string? FertilizationSchedule,
    string? PesticideSchedule,
    decimal? ExpectedYield,
    decimal? EstimatedCost,
    bool? IsActive,
    string? Notes
);
public record SearchCropSchedulesRequest(
    string? Term,
    int? MinDaysToHarvest,
    int? MaxDaysToHarvest,
    decimal? MinExpectedYield,
    decimal? MaxExpectedYield,
    bool? IsActive,
    int PageNumber,
    int PageSize
);