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
    string StatusName,
    string? Notes,
    DateTimeOffset Created
);

public record CreatePesticidePlanRequest(
    string FarmId,
    string PesticideId,
    string PlanName,
    DateTimeOffset PlannedDate,
    string? CropPlantingId = null,
    string? GrowthStageId = null,
    string? Target = null,
    decimal PlannedQuantity = 0,
    string Unit = "lít",
    string? ApplicationMethod = null,
    string? Notes = null
);

public record UpdatePesticidePlanRequest(
    string Id,
    string? PesticideId = null,
    string? PlanName = null,
    string? Target = null,
    DateTimeOffset? PlannedDate = null,
    decimal? PlannedQuantity = null,
    string? Unit = null,
    string? ApplicationMethod = null,
    PesticidePlanStatus? Status = null,
    string? Notes = null
);
