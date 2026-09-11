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
    string? CropPlantingId = null,
    string? GrowthStageId = null,
    int? DaysAfterPlanting = null,
    decimal PlannedQuantity = 0,
    string Unit = "kg",
    string? ApplicationMethod = null,
    FertilizationPlanStatus Status = FertilizationPlanStatus.Planned,
    string? Notes = null
);

public record UpdateFertilizationPlanRequest(
    string Id,
    string? FertilizerId = null,
    string? PlanName = null,
    DateTimeOffset? PlannedDate = null,
    string? CropPlantingId = null,
    string? GrowthStageId = null,
    int? DaysAfterPlanting = null,
    decimal? PlannedQuantity = null,
    string? Unit = null,
    string? ApplicationMethod = null,
    FertilizationPlanStatus? Status = null,
    string? Notes = null
);
