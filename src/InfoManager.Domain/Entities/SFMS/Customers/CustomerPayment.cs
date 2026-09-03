namespace InfoManager.Domain.Entities.SFMS.Customers;

/// <summary>
/// Thanh toán của khách hàng
/// </summary>
public class CustomerPayment : BaseAuditableEntity
{
    /// <summary>
    /// ID khách hàng
    /// </summary>
    public required string CustomerId { get; set; }

    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// ID đơn bán hàng liên quan (tùy chọn)
    /// </summary>
    public string? SaleId { get; set; }

    /// <summary>
    /// ID doanh thu liên quan (tùy chọn)
    /// </summary>
    public string? FarmRevenueId { get; set; }

    /// <summary>
    /// Số tiền thanh toán
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Ngày thanh toán
    /// </summary>
    public DateTimeOffset PaymentDate { get; set; }

    /// <summary>
    /// Phương thức thanh toán (Tiền mặt, Chuyển khoản, Séc...)
    /// </summary>
    [MaxLength(50)]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    /// <summary>
    /// Mã giao dịch / số tham chiếu
    /// </summary>
    [MaxLength(100)]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Ghi chú thanh toán
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    public virtual Customer? Customer { get; set; }
    public virtual Farm? Farm { get; set; }
    public virtual Sale? Sale { get; set; }
    public virtual FarmRevenue? FarmRevenue { get; set; }
}
