namespace InfoManager.Shared.Dtos.SFMS.Inventory;
public record InventoryAlertDtos(
    string Id,
    string FarmId,
    string? FarmName,
    string ItemTypeName,
    string? FertilizerId,
    string? PesticideId,
    string? FarmInventoryId,
    string ItemName,
    string AlertTypeName,
    string SeverityName,
    decimal CurrentQuantity,
    decimal? MinQuantity,
    DateOnly? ExpiryDate,
    string Message,
    DateTimeOffset AlertTime,
    bool IsResolved,
    DateTimeOffset? ResolvedTime,
    string? ResolutionNotes,
    DateTimeOffset Created
);

public record InventoryAlertSummaryDto(
    string Id,
    string ItemName,
    string ItemTypeName,
    string AlertTypeName,
    string SeverityName,
    decimal CurrentQuantity,
    DateTimeOffset AlertTime,
    bool IsResolved
);

public record UpdateInventoryAlertRequest(
    string Id,
    bool? IsResolved = null,
    string? ResolutionNotes = null
);