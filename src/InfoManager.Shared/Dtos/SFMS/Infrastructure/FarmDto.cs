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
    string? Description = null,
    decimal TotalArea = 0,
    decimal CultivableArea = 0,
    string? Location = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    string? LicenseNumber = null,
    FarmStatus Status = FarmStatus.Active,
    DateTimeOffset? EstablishedDate = null
);

public record UpdateFarmRequest(
    string Id,
    string? Name = null,
    string? Description = null,
    decimal? TotalArea = null,
    decimal? CultivableArea = null,
    string? Location = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    string? FarmerId = null,
    string? LicenseNumber = null,
    FarmStatus? Status = null,
    DateTimeOffset? EstablishedDate = null
);