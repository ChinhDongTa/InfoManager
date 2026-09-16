namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record PesticideDto(
    string Id,
    string Name,
    string? ActiveIngredient,
    PesticideType PesticideType,
    string PesticideTypeName,
    ToxicityLevel ToxicityLevel,
    string ToxicityLevelName,
    int? PreHarvestIntervalDays,
    string Unit,
    string? Manufacturer,
    string? RegistrationNumber,
    bool IsActive,
    string? Notes,
    DateTimeOffset Created
);

public record PesticideSummaryDto(
    string Id,
    string Name,
    string PesticideTypeName,
    string Unit,
    bool IsActive
);

public record CreatePesticideRequest(
    string Name,
    string? ActiveIngredient,
    PesticideType PesticideType,
    ToxicityLevel ToxicityLevel,
    int? PreHarvestIntervalDays,
    string Unit,
    string? Manufacturer,
    string? RegistrationNumber,
    bool IsActive,
    string? Notes
);

public record UpdatePesticideRequest(
    string Id,
    string? Name,
    string? ActiveIngredient,
    PesticideType? PesticideType,
    ToxicityLevel? ToxicityLevel,
    int? PreHarvestIntervalDays,
    string? Unit,
    string? Manufacturer,
    string? RegistrationNumber,
    bool? IsActive,
    string? Notes
);