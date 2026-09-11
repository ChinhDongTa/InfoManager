namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record FertilizerDto(
    string Id,
    string Name,
    FertilizerType FertilizerType,
    string FertilizerTypeName,
    decimal? NitrogenPercent,
    decimal? PhosphorusPercent,
    decimal? PotassiumPercent,
    string Unit,
    string? Manufacturer,
    bool IsActive,
    string? Notes,
    DateTimeOffset Created
);

public record FertilizerSummaryDto(
    string Id,
    string Name,
    string FertilizerTypeName,
    string Unit,
    bool IsActive
);

public record CreateFertilizerRequest(
    string Name,
    FertilizerType FertilizerType = FertilizerType.NPK,
    decimal? NitrogenPercent = null,
    decimal? PhosphorusPercent = null,
    decimal? PotassiumPercent = null,
    string Unit = "kg",
    string? Manufacturer = null,
    bool IsActive = true,
    string? Notes = null
);

public record UpdateFertilizerRequest(
    string Id,
    string? Name = null,
    FertilizerType? FertilizerType = null,
    decimal? NitrogenPercent = null,
    decimal? PhosphorusPercent = null,
    decimal? PotassiumPercent = null,
    string? Unit = null,
    string? Manufacturer = null,
    bool? IsActive = null,
    string? Notes = null
);