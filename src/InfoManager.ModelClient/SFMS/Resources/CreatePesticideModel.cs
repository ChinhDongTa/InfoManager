using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreatePesticideModel
{
    /// <summary>
    /// Tên thuốc BVTV
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Hoạt chất
    /// </summary>
    public string? ActiveIngredient { get; set; }

    /// <summary>
    /// Loại thuốc
    /// </summary>
    public PesticideType PesticideType { get; set; } = PesticideType.Insecticide;

    /// <summary>
    /// Mức độc tính
    /// </summary>
    public ToxicityLevel ToxicityLevel { get; set; } = ToxicityLevel.Moderate;

    /// <summary>
    /// Thời gian cách ly trước thu hoạch (ngày)
    /// </summary>
    [Range(0, int.MaxValue)]
    public int? PreHarvestIntervalDays { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "lít";

    /// <summary>
    /// Nhà sản xuất
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Số đăng ký
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Đang hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreatePesticideRequest CreateRequest()
    {
        return new CreatePesticideRequest
        (
            Name: this.Name,
            ActiveIngredient: this.ActiveIngredient,
            PesticideType: this.PesticideType,
            ToxicityLevel: this.ToxicityLevel,
            PreHarvestIntervalDays: this.PreHarvestIntervalDays,
            Unit: this.Unit,
            Manufacturer: this.Manufacturer,
            RegistrationNumber: this.RegistrationNumber,
            IsActive: this.IsActive,
            Notes: this.Notes
        );
    }
}