using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class CreateSaleModel
{
    /// <summary>
    /// ID sản phẩm
    /// </summary>
    [Required]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày bán
    /// </summary>
    [Required]
    public DateTimeOffset SaleDate { get; set; }

    /// <summary>
    /// Tên người mua
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string BuyerName { get; set; } = string.Empty;

    /// <summary>
    /// Số lượng bán
    /// </summary>
    [Required]
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal QuantitySold { get; set; }

    /// <summary>
    /// Đơn giá
    /// </summary>
    [Required]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Thành tiền
    /// </summary>
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Chiết khấu (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? DiscountPercentage { get; set; }

    /// <summary>
    /// Thực nhận
    /// </summary>
    public decimal? NetAmount { get; set; }

    /// <summary>
    /// Kênh bán
    /// </summary>
    [MaxLength(50)]
    public string? SaleChannel { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    /// <summary>
    /// Ngày thanh toán
    /// </summary>
    public DateTimeOffset? PaymentDate { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public CreateSaleRequest CreateRequest()
    {
        return new CreateSaleRequest
        (
            ProductId: this.ProductId,
            SaleDate: this.SaleDate,
            BuyerName: this.BuyerName,
            QuantitySold: this.QuantitySold,
            UnitPrice: this.UnitPrice,
            TotalAmount: this.TotalAmount,
            DiscountPercentage: this.DiscountPercentage,
            NetAmount: this.NetAmount,
            SaleChannel: this.SaleChannel,
            PaymentStatus: this.PaymentStatus,
            PaymentDate: this.PaymentDate,
            InvoiceNumber: this.InvoiceNumber,
            Notes: this.Notes
        );
    }
}