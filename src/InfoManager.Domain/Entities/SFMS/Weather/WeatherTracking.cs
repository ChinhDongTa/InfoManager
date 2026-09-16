namespace InfoManager.Domain.Entities.SFMS.Weather;

/// <summary>
/// Bản ghi dữ liệu thời tiết để theo dõi điều kiện thời tiết lịch sử
/// </summary>
public class WeatherData : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// Thời điểm ghi nhận dữ liệu thời tiết
    /// </summary>
    public DateTimeOffset RecordingTime { get; set; }

    /// <summary>
    /// Nhiệt độ (°C)
    /// </summary>
    public decimal? Temperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối thiểu (°C)
    /// </summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối đa (°C)
    /// </summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>
    /// Độ ẩm (%)
    /// </summary>
    public decimal? Humidity { get; set; }

    /// <summary>
    /// Điểm sương (°C)
    /// </summary>
    public decimal? DewPoint { get; set; }

    /// <summary>
    /// Lượng mưa (mm)
    /// </summary>
    public decimal? Rainfall { get; set; }

    /// <summary>
    /// Tốc độ gió (km/h)
    /// </summary>
    public decimal? WindSpeed { get; set; }

    /// <summary>
    /// Hướng gió (độ 0-360)
    /// </summary>
    public decimal? WindDirection { get; set; }

    /// <summary>
    /// Tốc độ gió giật (km/h)
    /// </summary>
    public decimal? WindGustSpeed { get; set; }

    /// <summary>
    /// Áp suất khí quyển (hPa)
    /// </summary>
    public decimal? Pressure { get; set; }

    /// <summary>
    /// Bức xạ mặt trời (W/m²)
    /// </summary>
    public decimal? SolarRadiation { get; set; }

    /// <summary>
    /// Chỉ số UV
    /// </summary>
    public decimal? UVIndex { get; set; }

    /// <summary>
    /// Độ che phủ mây (%)
    /// </summary>
    public decimal? CloudCover { get; set; }

    /// <summary>
    /// Tầm nhìn (km)
    /// </summary>
    public decimal? Visibility { get; set; }

    /// <summary>
    /// Mô tả điều kiện thời tiết
    /// </summary>
    [MaxLength(100)]
    public string? WeatherCondition { get; set; }

    /// <summary>
    /// Nguồn dữ liệu (Trạm thời tiết, Cảm biến, API, Nhập tay, v.v.)
    /// </summary>
    [MaxLength(100)]
    public string? DataSource { get; set; }

    /// <summary>
    /// Đánh giá chất lượng dữ liệu
    /// </summary>
    public DataQuality Quality { get; set; } = DataQuality.Good;

    // Navigation properties
    /// <summary>
    /// Thông tin nông trại liên quan
    /// </summary>
    public virtual Farm? Farm { get; set; }
}