namespace InfoManager.Shared.Dtos.SFMS.Resources;
public record PesticideApplicationDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? FieldId,
    string? FieldName,
    string? CropPlantingId,
    string? PlantingCode,
    string PesticideId,
    string? PesticideName,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string Unit,
    string? AppliedBy,
    decimal? Cost,
    DateOnly? SafeHarvestDate,
    string? Notes,
    DateTimeOffset Created
);

public record CreatePesticideApplicationRequest(
    string FarmId,
    string PesticideId,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string? FieldId = null,
    string? CropPlantingId = null,
    string? PesticidePlanId = null,
    string Unit = "lít",
    string? ApplicationMethod = null,
    string? AppliedBy = null,
    decimal? Cost = null,
    string? Notes = null
);