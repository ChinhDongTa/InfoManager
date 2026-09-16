namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Sổ lịch sử tồn kho. Mỗi lần cộng/trừ kho tạo 1 dòng, không sửa số lượng sau khi ghi.
/// </summary>
public class InventoryTransaction : BaseAuditableEntity
{
    public string FarmId { get; set; }
    public string FarmInventoryId { get; set; }

    /// <summary>Nhập / Xuất / Điều chỉnh</summary>
    public InventoryTransactionType TransactionType { get; set; }

    /// <summary>Lý do xuất: Gieo, Bón, Phun... (chỉ dùng khi xuất)</summary>
    public ResourceUsageType? UsageType { get; set; }

    /// <summary>Số lượng. Nhập > 0, xuất < 0, điều chỉnh có thể âm hoặc dương.</summary>
    public decimal Quantity { get; set; }

    [MaxLength(50)]
    public string Unit { get; set; }

    /// <summary>Tồn trước giao dịch</summary>
    public decimal QuantityBefore { get; set; }

    /// <summary>Tồn sau giao dịch</summary>
    public decimal QuantityAfter { get; set; }

    public decimal? CostPerUnit { get; set; }
    public decimal? Amount { get; set; }

    public DateTimeOffset TransactionDate { get; set; }

    public string? InventoryReceiptId { get; set; }
    public string? InventoryReceiptItemId { get; set; }
    public string? CropPlantingId { get; set; }
    public string? FieldId { get; set; }
    public string? TaskId { get; set; }
    public string? FertilizerApplicationId { get; set; }
    public string? PesticideApplicationId { get; set; }

    [MaxLength(500)]
    public string? Purpose { get; set; }

    [MaxLength(200)]
    public string? ApplicationMethod { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual FarmInventory? FarmInventory { get; set; }
    public virtual InventoryReceipt? InventoryReceipt { get; set; }
    public virtual InventoryReceiptItem? InventoryReceiptItem { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual Field? Field { get; set; }
    public virtual FertilizerApplication? FertilizerApplication { get; set; }
    public virtual PesticideApplication? PesticideApplication { get; set; }
}