using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Economics;

namespace InfoManager.ModelClient.SFMS.Economics;

public class CreateFarmRevenueModel
{
    /// <summary>
    /// Nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Lượt trồng liên kết
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// Đợt thu hoạch liên kết
    /// </summary>
    public string? HarvestId { get; set; }

    /// <summary>
    /// Đơn bán liên kết
    /// </summary>
    public string? SaleId { get; set; }

    /// <summary>
    /// Nguồn doanh thu
    /// </summary>
    [Required]
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Số tiền
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Đơn vị tiền tệ
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// Ngày ghi nhận doanh thu
    /// </summary>
    public DateTimeOffset RevenueDate { get; set; }

    /// <summary>
    /// Tên người mua
    /// </summary>
    public string? BuyerName { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Ngày nhận thanh toán
    /// </summary>
    public DateTimeOffset? PaymentReceivedDate { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateFarmRevenueRequest CreateRequest()
    {
        return new CreateFarmRevenueRequest
        (
            FarmId: this.FarmId,
            CropPlantingId: this.CropPlantingId,
            HarvestId: this.HarvestId,
            SaleId: this.SaleId,
            Source: this.Source,
            Amount: this.Amount,
            Currency: this.Currency,
            RevenueDate: this.RevenueDate,
            BuyerName: this.BuyerName,
            PaymentStatus: this.PaymentStatus,
            PaymentReceivedDate: this.PaymentReceivedDate,
            Notes: this.Notes
        );
    }
}