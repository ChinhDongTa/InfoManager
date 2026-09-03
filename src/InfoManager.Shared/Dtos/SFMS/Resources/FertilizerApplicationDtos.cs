namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record FertilizerApplicationDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? FieldId,
    string? FieldName,
    string? CropPlantingId,
    string? PlantingCode,
    string? FertilizationPlanId,
    string FertilizerId,
    string? FertilizerName,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string Unit,
    string? ApplicationMethod,
    string? AppliedBy,
    decimal? Cost,
    string? Notes,
    DateTimeOffset Created
);

public record FertilizerApplicationSummaryDto(
    string Id,
    string? PlantingCode,
    string? FertilizerName,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string Unit
);

public record CreateFertilizerApplicationRequest(
    string FarmId,
    string FertilizerId,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string? FieldId = null,
    string? CropPlantingId = null,
    string? FertilizationPlanId = null,
    string Unit = "kg",
    string? ApplicationMethod = null,
    string? AppliedBy = null,
    decimal? Cost = null,
    string? Notes = null
);

public record UpdateFertilizerApplicationRequest(
    string Id,
    string? FieldId = null,
    string? CropPlantingId = null,
    string? FertilizationPlanId = null,
    string? FertilizerId = null,
    DateTimeOffset? AppliedDate = null,
    decimal? AppliedQuantity = null,
    string? Unit = null,
    string? ApplicationMethod = null,
    string? AppliedBy = null,
    decimal? Cost = null,
    string? Notes = null
);