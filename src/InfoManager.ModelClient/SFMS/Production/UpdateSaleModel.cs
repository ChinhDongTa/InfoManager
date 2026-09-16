using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class UpdateSaleModel
{
    /// <summary>ID đơn bán. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID sản phẩm.</summary>
    public string? ProductId { get; set; }

    /// <summary>Ngày bán.</summary>
    public DateTimeOffset? SaleDate { get; set; }

    /// <summary>Tên người mua. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? BuyerName { get; set; }

    /// <summary>Số lượng bán. > 0.</summary>
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal? QuantitySold { get; set; }

    /// <summary>Đơn giá. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? UnitPrice { get; set; }

    /// <summary>Thành tiền.</summary>
    public decimal? TotalAmount { get; set; }

    /// <summary>Chiết khấu (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? DiscountPercentage { get; set; }

    /// <summary>Thực nhận.</summary>
    public decimal? NetAmount { get; set; }

    /// <summary>Kênh bán. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? SaleChannel { get; set; }

    /// <summary>Trạng thái thanh toán.</summary>
    public PaymentStatus? PaymentStatus { get; set; }

    /// <summary>Ngày thanh toán.</summary>
    public DateTimeOffset? PaymentDate { get; set; }

    /// <summary>Số hóa đơn. Tối đa 100 ký tự.</summary>
    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public UpdateSaleModel(string id, SaleDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        ProductId = dto.ProductId;
        SaleDate = dto.SaleDate;
        BuyerName = dto.BuyerName;
        QuantitySold = dto.QuantitySold;
        UnitPrice = dto.UnitPrice;
        TotalAmount = dto.TotalAmount;
        DiscountPercentage = dto.DiscountPercentage;
        NetAmount = dto.NetAmount;
        SaleChannel = dto.SaleChannel;
        PaymentStatus = dto.PaymentStatus;
        PaymentDate = dto.PaymentDate;
        InvoiceNumber = dto.InvoiceNumber;
        Notes = dto.Notes;
    }

    public UpdateSaleRequest CreateRequest()
    {
        return new UpdateSaleRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateSaleModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}