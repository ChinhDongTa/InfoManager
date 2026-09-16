namespace InfoManager.Shared.Dtos.SFMS.Agricultural;
// ======================== Crop ========================

public record CropDto(
    string Id,
    string CommonName,
    string ScientificName,
    string? Description,
    string? Family,
    int? DaysToMaturity,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? MinSoilPh,
    decimal? MaxSoilPh,
    decimal? WaterRequirement,
    decimal? SunLightHours,
    bool IsActive,

    DateTimeOffset Created
);

public record CropSummaryDto(
    string Id,
    string CommonName,
    string ScientificName,
    string? Family,
    int? DaysToMaturity,
    bool IsActive
);

public record CreateCropRequest(
    string CommonName,
    string ScientificName,
    string? Description,
    string? Family,
    int? DaysToMaturity,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? MinSoilPh,
    decimal? MaxSoilPh,
    decimal? WaterRequirement,
    decimal? SunLightHours,
    bool IsActive
);

public record UpdateCropRequest(
    string Id,
    string? CommonName,
    string? ScientificName,
    string? Description,
    string? Family,
    int? DaysToMaturity,
    decimal? MinTemperature,
    decimal? MaxTemperature,
    decimal? MinHumidity,
    decimal? MaxHumidity,
    decimal? MinSoilPh,
    decimal? MaxSoilPh,
    decimal? WaterRequirement,
    decimal? SunLightHours,
    bool? IsActive
);

public record SearchCropRequest(string? Term,
                                int? MinDaysToMaturity,
                                int? MaxDaysToMaturity,
                                decimal? Temperature,
                                decimal? Humidity,
                                decimal? SoilPh,
                                bool? IsActive,
                                int PageNumber,
                                int PageSize);