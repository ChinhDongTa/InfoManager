namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Farm equipment/machinery records
/// </summary>
public class Equipment : BaseAuditableEntity
{
    /// <summary>
    /// Equipment name/identifier
    /// </summary>
    [MaxLength(100)]
    public required string Name { get; set; }

    /// <summary>
    /// Equipment type (Tractor, Pump, Sprayer, Harrow, etc.)
    /// </summary>
    [MaxLength(50)]
    public required EquipmentType EquipmentType { get; set; }

    /// <summary>
    /// Associated farm ID
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    [MaxLength(100)]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Model number
    /// </summary>
    [MaxLength(100)]
    public string? Model { get; set; }

    /// <summary>
    /// Serial number
    /// </summary>
    [MaxLength(100)]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Power rating (HP) if applicable
    /// </summary>
    public decimal? PowerRating { get; set; }

    /// <summary>
    /// Capacity/Specifications
    /// </summary>
    [MaxLength(500)]
    public string? Specifications { get; set; }

    /// <summary>
    /// Purchase date
    /// </summary>
    public DateTimeOffset? PurchaseDate { get; set; }

    /// <summary>
    /// Purchase cost
    /// </summary>
    public decimal? PurchaseCost { get; set; }

    /// <summary>
    /// Current value/Book value
    /// </summary>
    public decimal? CurrentValue { get; set; }

    /// <summary>
    /// Equipment status (Active, Idle, Under Maintenance, Retired)
    /// </summary>
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Active;

    /// <summary>
    /// Operating hours (for engines)
    /// </summary>
    public decimal? OperatingHours { get; set; }

    /// <summary>
    /// Last maintenance date
    /// </summary>
    public DateTimeOffset? LastMaintenanceDate { get; set; }

    /// <summary>
    /// Next scheduled maintenance date
    /// </summary>
    public DateTimeOffset? NextMaintenanceDate { get; set; }

    /// <summary>
    /// Equipment location/storage
    /// </summary>
    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    /// <summary>
    /// Equipment notes
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }
    public virtual ICollection<Maintenance> MaintenanceRecords { get; set; } = [];
    public virtual ICollection<Domain.Entities.SFMS.Operations.Task> Tasks { get; set; } = [];
}

