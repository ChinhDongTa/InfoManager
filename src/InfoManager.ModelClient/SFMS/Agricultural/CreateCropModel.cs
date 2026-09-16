using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class CreateCropModel
{
    /// <summary>
    /// Tên thường gọi
    /// </summary>
    [Required]
    public string CommonName { get; set; } = string.Empty;

    /// <summary>
    /// Tên khoa học
    /// </summary>
    [Required]
    public string ScientificName { get; set; } = string.Empty;

    /// <summary>
    /// Mô tả
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Họ thực vật
    /// </summary>
    public string? Family { get; set; }

    /// <summary>
    /// Số ngày đến thu hoạch
    /// </summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>
    /// Nhiệt độ tối thiểu
    /// </summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối đa
    /// </summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>
    /// Độ ẩm tối thiểu
    /// </summary>
    public decimal? MinHumidity { get; set; }

    /// <summary>
    /// Độ ẩm tối đa
    /// </summary>
    public decimal? MaxHumidity { get; set; }

    /// <summary>
    /// pH đất tối thiểu
    /// </summary>
    public decimal? MinSoilPh { get; set; }

    /// <summary>
    /// pH đất tối đa
    /// </summary>
    public decimal? MaxSoilPh { get; set; }

    /// <summary>
    /// Nhu cầu nước
    /// </summary>
    public decimal? WaterRequirement { get; set; }

    /// <summary>
    /// Số giờ ánh sáng
    /// </summary>
    public decimal? SunLightHours { get; set; }

    /// <summary>
    /// Đang hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    public CreateCropRequest CreateRequest()
    {
        return new CreateCropRequest
        (
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            Description: this.Description,
            Family: this.Family,
            DaysToMaturity: this.DaysToMaturity,
            MinTemperature: this.MinTemperature,
            MaxTemperature: this.MaxTemperature,
            MinHumidity: this.MinHumidity,
            MaxHumidity: this.MaxHumidity,
            MinSoilPh: this.MinSoilPh,
            MaxSoilPh: this.MaxSoilPh,
            WaterRequirement: this.WaterRequirement,
            SunLightHours: this.SunLightHours,
            IsActive: this.IsActive
        );
    }
}