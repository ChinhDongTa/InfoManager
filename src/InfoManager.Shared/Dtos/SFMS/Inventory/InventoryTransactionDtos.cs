namespace InfoManager.Shared.Dtos.SFMS.Inventory;

public record InventoryTransactionDto(
    string Id,
    string FarmId,
    string FarmInventoryId,
    string? ResourceName,
    string? BatchNumber,
    InventoryTransactionType TransactionType,
    ResourceUsageType? UsageType,
    decimal Quantity,
    string Unit,
    decimal QuantityBefore,
    decimal QuantityAfter,
    decimal? CostPerUnit,
    decimal? Amount,
    DateTimeOffset TransactionDate,
    string? InventoryReceiptId,
    string? CropPlantingId,
    string? PlantingCode,
    string? FertilizerApplicationId,
    string? PesticideApplicationId,
    string? Purpose,
    string? ApplicationMethod,
    string? Notes,
    DateTimeOffset Created
);

public record InventoryTransactionSummaryDto(
    string Id,
    string? ResourceName,
    InventoryTransactionType TransactionType,
    ResourceUsageType? UsageType,
    decimal Quantity,
    string Unit,
    decimal QuantityAfter,
    DateTimeOffset TransactionDate,
    string? Purpose
);

public record SearchInventoryTransactionRequest(
    string? FarmId,
    string? FarmInventoryId,
    InventoryTransactionType? TransactionType,
    ResourceUsageType? UsageType,
    DateTimeOffset? FromDate,
    DateTimeOffset? ToDate,
    int PageNumber = 1,
    int PageSize = 20
);