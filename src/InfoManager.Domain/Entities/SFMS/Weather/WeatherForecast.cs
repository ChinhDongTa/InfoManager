namespace InfoManager.Domain.Entities.SFMS.Weather;

/// <summary>
/// Dự báo thời tiết phục vụ lập kế hoạch
/// </summary>
public class WeatherForecast : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Thời điểm dự báo
    /// </summary>
    public DateTimeOffset ForecastTime { get; set; }

    /// <summary>
    /// Nhiệt độ dự báo (°C)
    /// </summary>
    public decimal? Temperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối thiểu dự báo (°C)
    /// </summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối đa dự báo (°C)
    /// </summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>
    /// Độ ẩm dự báo (%)
    /// </summary>
    public decimal? Humidity { get; set; }

    /// <summary>
    /// Xác suất có mưa / lượng mưa khả năng xảy ra (%)
    /// </summary>
    public decimal? PrecipitationProbability { get; set; }

    /// <summary>
    /// Lượng mưa dự kiến (mm)
    /// </summary>
    public decimal? ExpectedRainfall { get; set; }

    /// <summary>
    /// Tốc độ gió dự báo (km/h)
    /// </summary>
    public decimal? WindSpeed { get; set; }

    /// <summary>
    /// Hướng gió dự báo (độ)
    /// </summary>
    public decimal? WindDirection { get; set; }

    /// <summary>
    /// Độ che phủ mây dự kiến (%)
    /// </summary>
    public decimal? CloudCover { get; set; }

    /// <summary>
    /// Áp suất khí quyển (hPa)
    /// </summary>
    public decimal? Pressure { get; set; }

    /// <summary>
    /// Bức xạ mặt trời dự báo (W/m²)
    /// </summary>
    public decimal? SolarRadiation { get; set; }

    /// <summary>
    /// Chỉ số UV dự báo
    /// </summary>
    public decimal? UVIndex { get; set; }

    /// <summary>
    /// Dự báo điều kiện thời tiết (mưa, nắng, mây, v.v.)
    /// </summary>
    [MaxLength(100)]
    public string? ForecastedCondition { get; set; }

    /// <summary>
    /// Mức độ tin cậy của dự báo (0-100%)
    /// </summary>
    public decimal? Confidence { get; set; }

    /// <summary>
    /// Nguồn dự báo (Weather API, Trạm thời tiết, v.v.)
    /// </summary>
    [MaxLength(100)]
    public string? ForecastSource { get; set; }

    /// <summary>
    /// Ngày giờ phát hành dự báo
    /// </summary>
    public DateTimeOffset? ForecastIssuedDate { get; set; }

    /// <summary>
    /// Cảnh báo / thông báo liên quan (nếu có)
    /// </summary>
    [MaxLength(500)]
    public string? Alerts { get; set; }

    /// <summary>
    /// Đánh giá độ chính xác của dự báo (sau khi có dữ liệu thực tế)
    /// </summary>
    public decimal? AccuracyRating { get; set; }

    // Navigation properties
    /// <summary>
    /// Thông tin nông trại liên quan
    /// </summary>
    public virtual Farm? Farm { get; set; }
}