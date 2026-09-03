
namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Đại diện cho loại cây trồng / loài cây được quản lý trong hệ thống nông trại thông minh.
/// Chứa thông tin đặc điểm, yêu cầu và các thông số sinh trưởng của cây trồng.
/// </summary>
public class Crop : BaseAuditableEntity
{
    /// <summary>
    /// Tên thông thường của cây trồng (ví dụ: "Lúa", "Ngô", "Khoai tây", "Cà chua")
    /// </summary>
    [MaxLength(100)]
    public required string CommonName { get; set; }

    /// <summary>
    /// Tên khoa học của cây trồng (ví dụ: "Ipomoea aquatica", "Solanum lycopersicum")
    /// </summary>
    [MaxLength(100)]
    public required string ScientificName { get; set; }

    /// <summary>
    /// Mô tả đặc điểm và công dụng của cây trồng
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Họ / danh mục cây trồng (ví dụ: "Solanaceae", "Poaceae")
    /// </summary>
    [MaxLength(100)]
    public string? Family { get; set; }

    /// <summary>
    /// Số ngày trung bình đến khi chín (từ khi trồng)
    /// </summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>
    /// Nhiệt độ tối thiểu tối ưu (°C)
    /// </summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối đa tối ưu (°C)
    /// </summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>
    /// Độ ẩm tối thiểu tối ưu (%)
    /// </summary>
    public decimal? MinHumidity { get; set; }

    /// <summary>
    /// Độ ẩm tối đa tối ưu (%)
    /// </summary>
    public decimal? MaxHumidity { get; set; }

    /// <summary>
    /// pH đất tối thiểu tối ưu
    /// </summary>
    public decimal? MinSoilPh { get; set; }

    /// <summary>
    /// pH đất tối đa tối ưu
    /// </summary>
    public decimal? MaxSoilPh { get; set; }

    /// <summary>
    /// Nhu cầu nước (mm mỗi ngày)
    /// </summary>
    public decimal? WaterRequirement { get; set; }

    /// <summary>
    /// Nhu cầu ánh sáng mặt trời (giờ mỗi ngày)
    /// </summary>
    public decimal? SunLightHours { get; set; }

    /// <summary>
    /// Cây trồng còn đang hoạt động / sử dụng hay không
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<CropVariety> Varieties { get; set; } = [];
    public virtual ICollection<CropSchedule> Schedules { get; set; } = [];
    public virtual ICollection<GrowthStage> GrowthStages { get; set; } = [];
}