namespace InfoManager.Domain.Entities.SFMS.Economics;

/// <summary>
/// Theo dõi doanh thu nông trại
/// </summary>
public class FarmRevenue : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// ID lần trồng cây liên quan (tùy chọn)
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID đợt thu hoạch liên quan (tùy chọn)
    /// </summary>
    public string? HarvestId { get; set; }

    /// <summary>
    /// ID giao dịch bán hàng liên quan (tùy chọn)
    /// </summary>
    public string? SaleId { get; set; }

    /// <summary>
    /// Nguồn doanh thu
    /// </summary>
    [MaxLength(200)]
    public string Source { get; set; }

    /// <summary>
    /// Tổng số tiền doanh thu
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Đơn vị tiền tệ
    /// </summary>
    [MaxLength(10)]
    public string? Currency { get; set; } = "VNĐ";

    /// <summary>
    /// Ngày phát sinh doanh thu
    /// </summary>
    public DateTimeOffset RevenueDate { get; set; }

    /// <summary>
    /// Tên người mua / khách hàng
    /// </summary>
    [MaxLength(200)]
    public string? BuyerName { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    /// <summary>
    /// Ngày nhận được thanh toán
    /// </summary>
    public DateTimeOffset? PaymentReceivedDate { get; set; }

    /// <summary>
    /// Ghi chú doanh thu
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }

    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual Harvest? Harvest { get; set; }
    public virtual Sale? Sale { get; set; }
}