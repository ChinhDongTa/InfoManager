namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record PesticidePlanDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CropPlantingId,
    string? PlantingCode,
    string PesticideId,
    string? PesticideName,
    string PlanName,
    string? Target,
    DateTimeOffset PlannedDate,
    decimal PlannedQuantity,
    string Unit,
    string? ApplicationMethod,
    PesticidePlanStatus? Status,
    string StatusName,
    string? Notes,
    DateTimeOffset Created
);

public record CreatePesticidePlanRequest(
    string FarmId,
    string PesticideId,
    string PlanName,
    DateTimeOffset PlannedDate,
    string? CropPlantingId,
    string? GrowthStageId,
    string? Target,
    decimal PlannedQuantity,
    string Unit,
    string? ApplicationMethod,
    PesticidePlanStatus? Status,
    string? Notes
);

public record UpdatePesticidePlanRequest(
    string Id,
    string? PesticideId,
    string? PlanName,
    string? Target,
    DateTimeOffset? PlannedDate,
    decimal? PlannedQuantity,
    string? Unit,
    string? ApplicationMethod,
    PesticidePlanStatus? Status,
    string? Notes
);