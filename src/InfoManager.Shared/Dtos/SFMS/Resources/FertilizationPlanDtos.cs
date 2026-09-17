namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record FertilizationPlanDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CropPlantingId,
    string? PlantingCode,
    string? GrowthStageId,
    string? GrowthStageName,
    string FertilizerId,
    string? FertilizerName,
    string PlanName,
    DateTimeOffset PlannedDate,
    int? DaysAfterPlanting,
    decimal PlannedQuantity,
    string Unit,
    string? ApplicationMethod,
    FertilizationPlanStatus Status,
    string StatusName,
    string? Notes,
    DateTimeOffset Created
);

public record FertilizationPlanSummaryDto(
    string Id,
    string PlanName,
    string? PlantingCode,
    string? FertilizerName,
    DateTimeOffset PlannedDate,
    decimal PlannedQuantity,
    string StatusName
);

public record CreateFertilizationPlanRequest(
    string FarmId,
    string FertilizerId,
    string PlanName,
    DateTimeOffset PlannedDate,
    string? CropPlantingId,
    string? GrowthStageId,
    int? DaysAfterPlanting,
    decimal PlannedQuantity,
    string Unit,
    string? ApplicationMethod,
    FertilizationPlanStatus Status,
    string? Notes
);

public record UpdateFertilizationPlanRequest(
    string Id,
    string? FertilizerId,
    string? PlanName,
    DateTimeOffset? PlannedDate,
    string? CropPlantingId,
    string? GrowthStageId,
    int? DaysAfterPlanting,
    decimal? PlannedQuantity,
    string? Unit,
    string? ApplicationMethod,
    FertilizationPlanStatus? Status,
    string? Notes
);

public record SearchFertilizationPlansRequest(string? Term, string? FarmId, string? FertilizerId, FertilizationPlanStatus? Status, int PageNumber, int PageSize);