namespace InfoManager.Shared.Dtos.SFMS.Resources;

public record PesticideDto(
    string Id,
    string Name,
    string? ActiveIngredient,
    string PesticideTypeName,
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
    string? ActiveIngredient = null,
    PesticideType PesticideType = PesticideType.Insecticide,
    ToxicityLevel ToxicityLevel = ToxicityLevel.Moderate,
    int? PreHarvestIntervalDays = null,
    string Unit = "lít",
    string? Manufacturer = null,
    string? RegistrationNumber = null,
    bool IsActive = true,
    string? Notes = null
);

public record UpdatePesticideRequest(
    string Id,
    string? Name = null,
    string? ActiveIngredient = null,
    PesticideType? PesticideType = null,
    ToxicityLevel? ToxicityLevel = null,
    int? PreHarvestIntervalDays = null,
    string? Unit = null,
    string? Manufacturer = null,
    string? RegistrationNumber = null,
    bool? IsActive = null,
    string? Notes = null
);
