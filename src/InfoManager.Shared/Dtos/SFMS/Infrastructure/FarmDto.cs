namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

// ======================== Farm ========================

public record FarmDto(
    string Id,
    string Name,
    string? Description,
    decimal TotalArea,
    decimal CultivableArea,
    string? Location,
    decimal? Latitude,
    decimal? Longitude,
    string FarmerId,
    string? FarmerName,
    string? LicenseNumber,
    FarmStatus Status,
    string StatusName,
    DateTimeOffset? EstablishedDate,
    DateTimeOffset Created

);

public record FarmSummaryDto(
    string Id,
    string Name,
    string? Location,
    decimal TotalArea,
    decimal CultivableArea,
    string StatusName
);

public record SearchFarmsRequest(string? Term,
                                decimal? MinCultivableArea,
                                decimal? MaxCultivableArea,
                                FarmStatus? Status,
                                int PageNumber,
                                int PageSize)
    ;

public record CreateFarmRequest(
    string Name,
    string FarmerId,
    string? Description,
    decimal TotalArea,
    decimal CultivableArea,
    string? Location,
    decimal? Latitude,
    decimal? Longitude,
    string? LicenseNumber,
    FarmStatus Status,
    DateTimeOffset? EstablishedDate
);

public record UpdateFarmRequest(
    string Id,
    string? Name,
    string? Description,
    decimal? TotalArea,
    decimal? CultivableArea,
    string? Location,
    decimal? Latitude,
    decimal? Longitude,
    string? FarmerId,
    string? LicenseNumber,
    FarmStatus? Status,
    DateTimeOffset? EstablishedDate
);