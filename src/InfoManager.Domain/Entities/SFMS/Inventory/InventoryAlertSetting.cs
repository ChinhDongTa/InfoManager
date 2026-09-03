namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Ngưỡng cảnh báo tồn kho / hạn dùng theo nông trại
/// </summary>
public class InventoryAlertSetting : BaseAuditableEntity
{
    public required string FarmId { get; set; }

    /// <summary>Số ngày trước hạn dùng để cảnh báo "Sắp hết hạn"</summary>
    public int ExpiringSoonDays { get; set; } = 30;

    /// <summary>Tự tạo cảnh báo tồn thấp</summary>
    public bool EnableLowStockAlert { get; set; } = true;

    /// <summary>Tự tạo cảnh báo hết hàng</summary>
    public bool EnableOutOfStockAlert { get; set; } = true;

    /// <summary>Tự tạo cảnh báo hạn dùng</summary>
    public bool EnableExpiryAlert { get; set; } = true;

    public virtual Farm? Farm { get; set; }
}