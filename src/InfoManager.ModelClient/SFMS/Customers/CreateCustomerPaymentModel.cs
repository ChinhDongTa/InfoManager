using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class CreateCustomerPaymentModel
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    [Required]
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    /// Nông trại liên kết
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Số tiền thanh toán
    /// </summary>
    [Required]
    public decimal Amount { get; set; }

    /// <summary>
    /// Ngày thanh toán
    /// </summary>
    public DateTimeOffset PaymentDate { get; set; }

    /// <summary>
    /// ID đơn bán
    /// </summary>
    public string? SaleId { get; set; }

    /// <summary>
    /// ID doanh thu nông trại
    /// </summary>
    public string? FarmRevenueId { get; set; }

    /// <summary>
    /// Phương thức thanh toán
    /// </summary>
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Số chứng từ tham chiếu
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateCustomerPaymentRequest CreateRequest()
    {
        return new CreateCustomerPaymentRequest
        (
            CustomerId: this.CustomerId,
            FarmId: this.FarmId,
            Amount: this.Amount,
            PaymentDate: this.PaymentDate,
            SaleId: this.SaleId,
            FarmRevenueId: this.FarmRevenueId,
            PaymentMethod: this.PaymentMethod,
            PaymentStatus: this.PaymentStatus,
            ReferenceNumber: this.ReferenceNumber,
            Notes: this.Notes
        );
    }
}