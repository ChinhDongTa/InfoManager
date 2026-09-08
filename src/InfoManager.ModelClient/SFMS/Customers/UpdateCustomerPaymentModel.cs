using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class UpdateCustomerPaymentModel
{
    /// <summary>ID thanh toán. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Số tiền thanh toán.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Ngày thanh toán.</summary>
    public DateTimeOffset? PaymentDate { get; set; }

    /// <summary>ID đơn bán.</summary>
    public string? SaleId { get; set; }

    /// <summary>ID doanh thu nông trại.</summary>
    public string? FarmRevenueId { get; set; }

    /// <summary>Phương thức thanh toán.</summary>
    public string? PaymentMethod { get; set; }

    /// <summary>Trạng thái thanh toán.</summary>
    public PaymentStatus? PaymentStatus { get; set; }

    /// <summary>Số chứng từ tham chiếu.</summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateCustomerPaymentModel(string id, CustomerPaymentDto dto)
    {
        Id = id;
        Amount = dto.Amount;
        PaymentDate = dto.PaymentDate;
        SaleId = dto.SaleId;
        FarmRevenueId = dto.FarmRevenueId;
        PaymentMethod = dto.PaymentMethod;
        PaymentStatus = dto.PaymentStatus;
        ReferenceNumber = dto.ReferenceNumber;
        Notes = dto.Notes;
    }

    public UpdateCustomerPaymentRequest CreateRequest()
    {
        return new UpdateCustomerPaymentRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateCustomerPaymentModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}