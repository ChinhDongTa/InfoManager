namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Tồn kho vật tư nông trại (phân, thuốc, hạt giống, công cụ...)
/// Mỗi dòng = một lô trong một nông trại.
/// </summary>
public class FarmInventory : BaseAuditableEntity
{
    public string FarmId { get; set; }

    /// <summary>Tên vật tư</summary>
    [MaxLength(200)]
    public string ResourceName { get; set; }

    /// <summary>Nhóm vật tư</summary>
    public ResourceType ResourceType { get; set; }

    /// <summary>ID phân bón (nếu là phân)</summary>
    public string? FertilizerId { get; set; }

    /// <summary>ID thuốc BVTV (nếu là thuốc)</summary>
    public string? PesticideId { get; set; }

    /// <summary>ID giống cây (nếu là hạt giống / cây giống).</summary>
    public string? CropVarietyId { get; set; }

    public virtual CropVariety? CropVariety { get; set; }

    [MaxLength(200)]
    public string? Brand { get; set; }

    public decimal CurrentQuantity { get; set; }

    [MaxLength(50)]
    public string Unit { get; set; }

    public decimal? MinQuantity { get; set; }
    public decimal? MaxQuantity { get; set; }
    public decimal? CostPerUnit { get; set; }

    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    [MaxLength(100)]
    public string? BatchNumber { get; set; }

    public DateTimeOffset? PurchaseDate { get; set; }

    [MaxLength(200)]
    public string? Supplier { get; set; }

    [MaxLength(200)]
    public string? Certification { get; set; }

    [MaxLength(500)]
    public string? Specification { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual Farm? Farm { get; set; }
    public virtual Fertilizer? Fertilizer { get; set; }
    public virtual Pesticide? Pesticide { get; set; }
    public virtual ICollection<InventoryTransaction> Transactions { get; set; } = [];
}