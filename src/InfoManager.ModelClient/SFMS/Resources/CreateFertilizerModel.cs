using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class CreateFertilizerModel
{
    /// <summary>
    /// Tên phân bón
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Loại phân bón
    /// </summary>
    public FertilizerType FertilizerType { get; set; } = FertilizerType.NPK;

    /// <summary>
    /// Tỷ lệ đạm (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? NitrogenPercent { get; set; }

    /// <summary>
    /// Tỷ lệ lân (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? PhosphorusPercent { get; set; }

    /// <summary>
    /// Tỷ lệ kali (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? PotassiumPercent { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Nhà sản xuất
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Đang hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateFertilizerRequest CreateRequest()
    {
        return new CreateFertilizerRequest
        (
            Name: this.Name,
            FertilizerType: this.FertilizerType,
            NitrogenPercent: this.NitrogenPercent,
            PhosphorusPercent: this.PhosphorusPercent,
            PotassiumPercent: this.PotassiumPercent,
            Unit: this.Unit,
            Manufacturer: this.Manufacturer,
            IsActive: this.IsActive,
            Notes: this.Notes
        );
    }
}