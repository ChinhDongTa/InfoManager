namespace InfoManager.Domain.Entities.SFMS.Economics;

/// <summary>
/// Theo dõi chi phí nông trại
/// </summary>
public class FarmExpense : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// ID lần trồng cây liên quan (tùy chọn)
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// Loại chi phí
    /// </summary>
    public required ExpenseType ExpenseType { get; set; }

    /// <summary>
    /// Mô tả chi phí
    /// </summary>
    [MaxLength(500)]
    public required string Description { get; set; }

    /// <summary>
    /// Số tiền đã chi
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Danh mục chi phí
    /// </summary>
    [MaxLength(100)]
    public string? Category { get; set; }

    /// <summary>
    /// Ngày phát sinh chi phí
    /// </summary>
    public DateTimeOffset ExpenseDate { get; set; }

    /// <summary>
    /// Tên nhà cung cấp / đại lý
    /// </summary>
    [MaxLength(200)]
    public string? Vendor { get; set; }

    /// <summary>
    /// Số hóa đơn / biên lai
    /// </summary>
    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Phương thức thanh toán (Tiền mặt, Séc, Chuyển khoản...)
    /// </summary>
    [MaxLength(50)]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Paid;

    /// <summary>
    /// Trạng thái phê duyệt chi phí
    /// </summary>
    public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Approved;

    /// <summary>
    /// Người phê duyệt
    /// </summary>
    [MaxLength(100)]
    public string? ApprovedBy { get; set; }

    /// <summary>
    /// Đường dẫn tệp đính kèm / hóa đơn
    /// </summary>
    [MaxLength(500)]
    public string? AttachmentUrl { get; set; }

    /// <summary>
    /// Ghi chú chi phí
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
}