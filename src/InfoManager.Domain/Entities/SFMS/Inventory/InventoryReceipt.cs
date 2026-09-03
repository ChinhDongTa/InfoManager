
namespace InfoManager.Domain.Entities.SFMS.Inventory;

/// <summary>
/// Phiếu nhập vật tư
/// </summary>
public class InventoryReceipt : BaseAuditableEntity
{
    /// <summary>ID nông trại</summary>
    public required string FarmId { get; set; }

    /// <summary>Số phiếu nhập</summary>
    [MaxLength(50)]
    public required string ReceiptNumber { get; set; }

    /// <summary>Ngày nhập</summary>
    public DateTimeOffset ReceiptDate { get; set; }

    /// <summary>Nhà cung cấp</summary>
    [MaxLength(200)]
    public string? Supplier { get; set; }

    /// <summary>Số hóa đơn</summary>
    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }

    /// <summary>Tổng tiền</summary>
    public decimal TotalAmount { get; set; }

    /// <summary>Trạng thái phiếu</summary>
    public InventoryReceiptStatus Status { get; set; } = InventoryReceiptStatus.Draft;

    /// <summary>Ngày ghi sổ (cộng tồn)</summary>
    public DateTimeOffset? PostedAt { get; set; }

    /// <summary>Ghi chú</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual ICollection<InventoryReceiptItem> Items { get; set; } = [];
}
