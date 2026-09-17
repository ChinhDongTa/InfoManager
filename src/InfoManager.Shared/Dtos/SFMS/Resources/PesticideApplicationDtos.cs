namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record PesticideApplicationDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? FieldId,
    string? FieldName,
    string? CropPlantingId,
    string? PesticidePlanId,
    string? PlantingCode,
    string PesticideId,
    string? PesticideName,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string Unit,
    string? ApplicationMethod,
    string? AppliedBy,
    decimal? Cost,
    DateOnly? SafeHarvestDate,
    string? Notes,
    DateTimeOffset Created
);

public record PesticideApplicationSummaryDto(
    string Id,
    string? PlantingCode,
    string? PesticideName,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string Unit);

public record CreatePesticideApplicationRequest(
    string FarmId,
    string PesticideId,
    DateTimeOffset AppliedDate,
    decimal AppliedQuantity,
    string? FieldId,
    string? CropPlantingId,
    string? PesticidePlanId,
    string Unit,
    string? ApplicationMethod,
    string? AppliedBy,
    decimal? Cost,
    string? Notes
);
public record UpdatePesticideApplicationRequest(
    string Id,
    string? FarmId,
    string? PesticideId,
    DateTimeOffset? AppliedDate,
    decimal AppliedQuantity,
    string? FieldId,
    string? CropPlantingId,
    string? PesticidePlanId,
    string Unit,
    string? ApplicationMethod,
    string? AppliedBy,
    decimal? Cost,
    string? Notes
);
public record SearchFertilizerApplicationsRequest(string? Term, string? FarmId, string? FertilizerId, string? CropPlantingId, int PageNumber, int PageSize);