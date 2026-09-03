
namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Cảnh báo tồn kho vật tư
/// </summary>
public class InventoryAlert : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Nhóm vật tư
    /// </summary>
    public InventoryItemType ItemType { get; set; }

    /// <summary>
    /// ID phân bón (nếu là phân)
    /// </summary>
    public string? FertilizerId { get; set; }

    /// <summary>
    /// ID thuốc BVTV (nếu là thuốc)
    /// </summary>
    public string? PesticideId { get; set; }

    /// <summary>ID giống cây (nếu là hạt giống / cây giống).</summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// ID vật tư kho chung (nếu là vật tư khác)
    /// </summary>
    public string? FarmInventoryId { get; set; }

    /// <summary>
    /// Tên vật tư tại thời điểm cảnh báo
    /// </summary>
    [MaxLength(200)]
    public required string ItemName { get; set; }

    /// <summary>
    /// Loại cảnh báo
    /// </summary>
    public InventoryAlertType AlertType { get; set; }

    /// <summary>
    /// Mức độ
    /// </summary>
    public AlertSeverity Severity { get; set; } = AlertSeverity.Info;

    /// <summary>
    /// Số lượng hiện tại
    /// </summary>
    public decimal CurrentQuantity { get; set; }

    /// <summary>
    /// Ngưỡng tối thiểu
    /// </summary>
    public decimal? MinQuantity { get; set; }

    /// <summary>
    /// Hạn sử dụng (nếu cảnh báo hết hạn)
    /// </summary>
    public DateOnly? ExpiryDate { get; set; }

    /// <summary>
    /// Nội dung cảnh báo
    /// </summary>
    [MaxLength(500)]
    public required string Message { get; set; }

    /// <summary>
    /// Thời điểm cảnh báo
    /// </summary>
    public DateTimeOffset AlertTime { get; set; }

    /// <summary>
    /// Đã xử lý hay chưa
    /// </summary>
    public bool IsResolved { get; set; }

    /// <summary>
    /// Thời điểm xử lý
    /// </summary>
    public DateTimeOffset? ResolvedTime { get; set; }

    /// <summary>
    /// Ghi chú xử lý
    /// </summary>
    [MaxLength(500)]
    public string? ResolutionNotes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual Fertilizer? Fertilizer { get; set; }
    public virtual Pesticide? Pesticide { get; set; }
    public virtual FarmInventory? FarmInventory { get; set; }
}
