using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Economics;

namespace InfoManager.ModelClient.SFMS.Economics;

public class UpdateFarmRevenueModel
{
    /// <summary>ID doanh thu nông trại. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>ID lượt trồng liên kết.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>ID đợt thu hoạch liên kết.</summary>
    public string? HarvestId { get; set; }

    /// <summary>ID đơn bán liên kết.</summary>
    public string? SaleId { get; set; }

    /// <summary>Nguồn doanh thu.</summary>
    public string? Source { get; set; }

    /// <summary>Số tiền.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Đơn vị tiền tệ.</summary>
    public string? Currency { get; set; }

    /// <summary>Ngày ghi nhận doanh thu.</summary>
    public DateTimeOffset? RevenueDate { get; set; }

    /// <summary>Tên người mua.</summary>
    public string? BuyerName { get; set; }

    /// <summary>Trạng thái thanh toán.</summary>
    public PaymentStatus? PaymentStatus { get; set; }

    /// <summary>Ngày nhận thanh toán.</summary>
    public DateTimeOffset? PaymentReceivedDate { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateFarmRevenueModel(string id, FarmRevenueDto dto)
    {
        Id = id;
        FarmId = dto.FarmId;
        CropPlantingId = dto.CropPlantingId;
        HarvestId = dto.HarvestId;
        SaleId = dto.SaleId;
        Source = dto.Source;
        Amount = dto.Amount;
        Currency = dto.Currency;
        RevenueDate = dto.RevenueDate;
        BuyerName = dto.BuyerName;
        PaymentStatus = dto.PaymentStatus;
        PaymentReceivedDate = dto.PaymentReceivedDate;
        Notes = dto.Notes;
    }

    public UpdateFarmRevenueRequest CreateRequest()
    {
        return new UpdateFarmRevenueRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateFarmRevenueModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}