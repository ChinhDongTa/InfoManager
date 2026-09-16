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
    FertilizerType FertilizerType,
    decimal? NitrogenPercent,
    decimal? PhosphorusPercent,
    decimal? PotassiumPercent,
    string Unit,
    string? Manufacturer,
    bool IsActive,
    string? Notes
);

public record UpdateFertilizerRequest(
    string Id,
    string? Name,
    FertilizerType? FertilizerType,
    decimal? NitrogenPercent,
    decimal? PhosphorusPercent,
    decimal? PotassiumPercent,
    string? Unit,
    string? Manufacturer,
    bool? IsActive,
    string? Notes
);