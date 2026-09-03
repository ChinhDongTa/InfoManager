
namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Dòng chi tiết phiếu nhập
/// </summary>
public class InventoryReceiptItem : BaseAuditableEntity
{
    public required string InventoryReceiptId { get; set; }

    /// <summary>ID tồn kho được cộng vào sau khi ghi sổ (nếu có)</summary>
    public string? FarmInventoryId { get; set; }

    public ResourceType ResourceType { get; set; }

    [MaxLength(200)]
    public required string ResourceName { get; set; }

    public string? FertilizerId { get; set; }
    public string? PesticideId { get; set; }
    public string? CropVarietyId { get; set; }

    [MaxLength(200)]
    public string? Brand { get; set; }

    public decimal Quantity { get; set; }

    [MaxLength(50)]
    public required string Unit { get; set; }

    public decimal? CostPerUnit { get; set; }
    public decimal? LineAmount { get; set; }

    [MaxLength(100)]
    public string? BatchNumber { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual InventoryReceipt? InventoryReceipt { get; set; }
    public virtual FarmInventory? FarmInventory { get; set; }
    public virtual Fertilizer? Fertilizer { get; set; }
    public virtual Pesticide? Pesticide { get; set; }
    public virtual CropVariety? CropVariety { get; set; }
}
