namespace InfoManager.Domain.Entities.SFMS.Production;

/// <summary>
/// Harvested products after processing
/// </summary>
public class Product : BaseAuditableEntity
{
    /// <summary>
    /// Associated harvest ID
    /// </summary>
    public required string HarvestId { get; set; }

    /// <summary>
    /// Product name/variety
    /// </summary>
    [MaxLength(200)]
    public required string ProductName { get; set; }

    /// <summary>
    /// Product description
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Processing type (Fresh, Dried, Processed, etc.)
    /// </summary>
    [MaxLength(50)]
    public string? ProcessingType { get; set; }

    /// <summary>
    /// Quantity produced
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Unit of quantity (kg, liter, boxes, etc.)
    /// </summary>
    [MaxLength(50)]
    public required string Unit { get; set; }

    /// <summary>
    /// Storage location
    /// </summary>
    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    /// <summary>
    /// Expiry/Best-before date
    /// </summary>
    public DateTimeOffset? ExpiryDate { get; set; }

    /// <summary>
    /// Cost per unit
    /// </summary>
    public decimal? CostPerUnit { get; set; }

    /// <summary>
    /// Selling price per unit
    /// </summary>
    public decimal? SellingPrice { get; set; }

    /// <summary>
    /// Total value (Quantity × SellingPrice)
    /// </summary>
    public decimal? TotalValue { get; set; }

    /// <summary>
    /// Product status (Available, Sold, Damaged, Discarded)
    /// </summary>
    public ProductStatus Status { get; set; } = ProductStatus.Available;

    /// <summary>
    /// Quality certification (Organic, ISO, etc.)
    /// </summary>
    [MaxLength(200)]
    public string? Certification { get; set; }

    /// <summary>
    /// Product notes
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Harvest? Harvest { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
