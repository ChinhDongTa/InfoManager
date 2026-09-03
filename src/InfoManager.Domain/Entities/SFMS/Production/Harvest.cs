namespace InfoManager.Domain.Entities.SFMS.Production;

/// <summary>
/// Harvest records for completed crop plantings
/// </summary>
public class Harvest : BaseAuditableEntity
{
    /// <summary>
    /// Associated crop planting ID
    /// </summary>
    public required string CropPlantingId { get; set; }

    /// <summary>
    /// Harvest date
    /// </summary>
    public DateTimeOffset HarvestDate { get; set; }

    /// <summary>
    /// Method used for harvest (Manual, Mechanical, Partial, etc.)
    /// </summary>
    [MaxLength(50)]
    public string? HarvestMethod { get; set; }

    /// <summary>
    /// Area harvested (hectares)
    /// </summary>
    public decimal HarvestedArea { get; set; }

    /// <summary>
    /// Total quantity harvested
    /// </summary>
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// Unit of quantity (kg, ton, bags, etc.)
    /// </summary>
    [MaxLength(50)]
    public required string QuantityUnit { get; set; }

    /// <summary>
    /// Estimated yield (quantity/hectare)
    /// </summary>
    public decimal? YieldPerHectare { get; set; }

    /// <summary>
    /// Quality grading (A, B, C, etc.)
    /// </summary>
    [MaxLength(10)]
    public string? QualityGrade { get; set; }

    /// <summary>
    /// Harvester/crew name
    /// </summary>
    [MaxLength(200)]
    public string? HarvesterName { get; set; }

    /// <summary>
    /// Weather condition during harvest
    /// </summary>
    [MaxLength(200)]
    public string? WeatherCondition { get; set; }

    /// <summary>
    /// Harvest loss percentage
    /// </summary>
    public decimal? LossPercentage { get; set; }

    /// <summary>
    /// Harvest notes
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Photo URL from harvest
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    // Navigation properties
    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual ICollection<Product> Products { get; set; } = [];
}