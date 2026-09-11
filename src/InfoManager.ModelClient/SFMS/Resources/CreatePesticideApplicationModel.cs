using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreatePesticideApplicationModel
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// ID thuốc BVTV
    /// </summary>
    [Required]
    public string PesticideId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày phun / xử lý
    /// </summary>
    [Required]
    public DateTimeOffset AppliedDate { get; set; }

    /// <summary>
    /// Khối lượng đã dùng
    /// </summary>
    [Required]
    public decimal AppliedQuantity { get; set; }

    /// <summary>
    /// ID thửa đất
    /// </summary>
    public string? FieldId { get; set; }

    /// <summary>
    /// ID lần trồng
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// ID kế hoạch sử dụng thuốc
    /// </summary>
    public string? PesticidePlanId { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "lít";

    /// <summary>
    /// Phương pháp phun / xử lý
    /// </summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>
    /// Người thực hiện
    /// </summary>
    public string? AppliedBy { get; set; }

    /// <summary>
    /// Chi phí
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreatePesticideApplicationRequest CreateRequest()
    {
        return new CreatePesticideApplicationRequest
        (
            FarmId: this.FarmId,
            PesticideId: this.PesticideId,
            AppliedDate: this.AppliedDate,
            AppliedQuantity: this.AppliedQuantity,
            FieldId: this.FieldId,
            CropPlantingId: this.CropPlantingId,
            PesticidePlanId: this.PesticidePlanId,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            AppliedBy: this.AppliedBy,
            Cost: this.Cost,
            Notes: this.Notes
        );
    }
}