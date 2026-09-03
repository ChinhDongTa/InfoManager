namespace InfoManager.Shared.Dtos.SFMS.Economics;

// ======================== FarmRevenue ========================

public record FarmRevenueDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CropPlantingId,
    string? CropPlantingName,
    string? HarvestId,
    string? HarvestName,
    string? SaleId,
    string? SaleName,
    string Source,
    decimal Amount,
    string? Currency,
    DateTimeOffset RevenueDate,
    string? BuyerName,
    string PaymentStatusName,
    DateTimeOffset? PaymentReceivedDate,
    string? Notes,
    DateTimeOffset Created
);

public record FarmRevenueSummaryDto(
    string Id,
    string? FarmName,
    string Source,
    decimal Amount,
    string? Currency,
    DateTimeOffset RevenueDate,
    string? BuyerName,
    string PaymentStatusName
);

public record CreateFarmRevenueRequest(
    string FarmId,
    string? CropPlantingId ,
    string? HarvestId ,
    string? SaleId ,
    string Source ,
    decimal Amount,
    string? Currency,
    DateTimeOffset RevenueDate ,
    string? BuyerName ,
    PaymentStatus PaymentStatus ,
    DateTimeOffset? PaymentReceivedDate ,
    string? Notes 
);

public record UpdateFarmRevenueRequest(
    string Id,
    string? FarmId ,
    string? CropPlantingId ,
    string? HarvestId ,
    string? SaleId ,
    string? Source ,
    decimal? Amount ,
    string? Currency ,
    DateTimeOffset? RevenueDate ,
    string? BuyerName ,
    PaymentStatus? PaymentStatus ,
    DateTimeOffset? PaymentReceivedDate ,
    string? Notes 
);