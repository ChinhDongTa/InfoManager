namespace InfoManager.Shared.Dtos.SFMS.Agricultural;

// ======================== CropVariety ========================

public record CropVarietyDto(
    string Id,
    string VarietyName,
    string CropId,
    string? CropName,
    string? BreederName,
    int? DaysToMaturity,
    decimal? ExpectedYield,
    string? YieldUnit,
    decimal? SeedRate,
    string? DiseaseResistance,
    string? PestResistance,
    string? ClimateSuitability,
    int? YearOfRelease,
    bool IsActive,
    DateTimeOffset Created
);

public record CropVarietySummaryDto(
    string Id,
    string VarietyName,
    string? CropName,
    string? BreederName,
    int? DaysToMaturity,
    decimal? ExpectedYield,
    string? YieldUnit,
    bool IsActive
);

public record CreateCropVarietyRequest(
    string VarietyName,
    string CropId,
    string? BreederName,
    int? DaysToMaturity,
    decimal? ExpectedYield,
    string? YieldUnit,
    decimal? SeedRate,
    string? DiseaseResistance,
    string? PestResistance,
    string? ClimateSuitability,
    int? YearOfRelease,
    bool IsActive
);

public record UpdateCropVarietyRequest(
    string Id,
    string? VarietyName,
    string? CropId,
    string? BreederName,
    int? DaysToMaturity,
    decimal? ExpectedYield,
    string? YieldUnit,
    decimal? SeedRate,
    string? DiseaseResistance,
    string? PestResistance,
    string? ClimateSuitability,
    int? YearOfRelease,
    bool? IsActive
);
public record SearchCropVarietyRequest(
    string? Term,
    string? CropId,
    int? DaysToMaturity,
    decimal? MinExpectedYield,
    decimal? MaxExpectedYield,
    bool? IsActive,
    int PageNumber,
    int PageSize
);