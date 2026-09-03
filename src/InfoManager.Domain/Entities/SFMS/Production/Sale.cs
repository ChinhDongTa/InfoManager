namespace InfoManager.Domain.Entities.SFMS.Production;

/// <summary>
/// Product sales record
/// </summary>
public class Sale : BaseAuditableEntity
{
    /// <summary>
    /// Associated product ID
    /// </summary>
    public required string ProductId { get; set; }

    /// <summary>
    /// Sale date
    /// </summary>
    public DateTimeOffset SaleDate { get; set; }

    /// <summary>
    /// Buyer name
    /// </summary>
    [MaxLength(200)]
    public required string BuyerName { get; set; }

    /// <summary>
    /// Quantity sold
    /// </summary>
    public decimal QuantitySold { get; set; }

    /// <summary>
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Total sale amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Discount given (%)
    /// </summary>
    public decimal? DiscountPercentage { get; set; }

    /// <summary>
    /// Final net amount received
    /// </summary>
    public decimal NetAmount { get; set; }

    /// <summary>
    /// Sale channel (Direct, Wholesale, Market, Online, etc.)
    /// </summary>
    [MaxLength(50)]
    public string? SaleChannel { get; set; }

    /// <summary>
    /// Payment status
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    /// <summary>
    /// Payment date
    /// </summary>
    public DateTimeOffset? PaymentDate { get; set; }

    /// <summary>
    /// Invoice number
    /// </summary>
    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Sale notes
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Product? Product { get; set; }
}
