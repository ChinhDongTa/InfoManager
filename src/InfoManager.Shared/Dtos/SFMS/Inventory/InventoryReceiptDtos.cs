namespace InfoManager.Shared.Dtos.SFMS.Inventory;

public record InventoryReceiptDto(
    string Id,
    string FarmId,
    string? FarmName,
    string ReceiptNumber,
    DateTimeOffset ReceiptDate,
    string? Supplier,
    string? InvoiceNumber,
    decimal TotalAmount,
    InventoryReceiptStatus Status,
    DateTimeOffset? PostedAt,
    string? Notes,
    IReadOnlyList<InventoryReceiptItemDto> Items,
    DateTimeOffset Created
);

public record InventoryReceiptSummaryDto(
    string Id,
    string ReceiptNumber,
    DateTimeOffset ReceiptDate,
    string? Supplier,
    decimal TotalAmount,
    InventoryReceiptStatus Status
);

public record InventoryReceiptItemDto(
    string Id,
    string? FarmInventoryId,
    ResourceType ResourceType,
    string ResourceName,
    string? FertilizerId,
    string? FertilizerName,
    string? PesticideId,
    string? PesticideName,
    string? CropVarietyId,
    string? CropVarietyName,
    string? Brand,
    decimal Quantity,
    string Unit,
    decimal? CostPerUnit,
    decimal? LineAmount,
    string? BatchNumber,
    DateOnly? ExpiryDate,
    string? StorageLocation,
    string? Notes
);

public record CreateInventoryReceiptRequest(
    /// <summary>ID nông trại. Bắt buộc.</summary>
    string FarmId,

    /// <summary>Số phiếu. Để trống thì server tự sinh.</summary>
    string? ReceiptNumber,

    /// <summary>Ngày nhập. Bắt buộc.</summary>
    DateTimeOffset ReceiptDate,

    /// <summary>Nhà cung cấp. Tối đa 200 ký tự.</summary>
    string? Supplier,

    /// <summary>Số hóa đơn. Tối đa 100 ký tự.</summary>
    string? InvoiceNumber,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes,

    /// <summary>Danh sách dòng nhập. Bắt buộc, ít nhất 1 dòng.</summary>
    IReadOnlyList<CreateInventoryReceiptItemRequest> Items
);

public record CreateInventoryReceiptItemRequest(
    /// <summary>Nhóm vật tư. Bắt buộc.</summary>
    ResourceType ResourceType,

    /// <summary>Tên vật tư. Bắt buộc, tối đa 200 ký tự.</summary>
    string ResourceName,

    /// <summary>Bắt buộc nếu ResourceType = Fertilizer.</summary>
    string? FertilizerId,

    /// <summary>Bắt buộc nếu ResourceType = Pesticide.</summary>
    string? PesticideId,

    /// <summary>Tùy chọn nếu ResourceType = Seed.</summary>
    string? CropVarietyId,

    /// <summary>Thương hiệu. Tối đa 200 ký tự.</summary>
    string? Brand,

    /// <summary>Số lượng nhập. Bắt buộc, > 0.</summary>
    decimal Quantity,

    /// <summary>Đơn vị. Bắt buộc, tối đa 50 ký tự.</summary>
    string Unit,

    /// <summary>Đơn giá. Không âm.</summary>
    decimal? CostPerUnit,

    /// <summary>Số lô. Tối đa 100 ký tự.</summary>
    string? BatchNumber,

    /// <summary>Hạn sử dụng.</summary>
    DateOnly? ExpiryDate,

    /// <summary>Vị trí kho. Tối đa 200 ký tự.</summary>
    string? StorageLocation,

    /// <summary>Ghi chú dòng. Tối đa 500 ký tự.</summary>
    string? Notes
);

public record UpdateInventoryReceiptRequest(
    /// <summary>ID phiếu. Bắt buộc.</summary>
    string Id,

    /// <summary>Chỉ sửa khi Status = Draft.</summary>
    DateTimeOffset? ReceiptDate,

    string? Supplier,
    string? InvoiceNumber,
    string? Notes,
    IReadOnlyList<CreateInventoryReceiptItemRequest>? Items
);