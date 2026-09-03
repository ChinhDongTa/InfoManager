namespace InfoManager.Domain.Entities.SFMS.Weather;

/// <summary>
/// Cảnh báo thời tiết và các cảnh báo thời tiết nghiêm trọng liên quan
/// </summary>
public class WeatherAlert : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Loại cảnh báo (Sương giá, Mưa đá, Mưa lớn, Hạn hán, Gió mạnh, v.v.)
    /// </summary>
    public required WeatherAlertType AlertType { get; set; }

    /// <summary>
    /// Mô tả cảnh báo
    /// </summary>
    [MaxLength(500)]
    public required string Description { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng của cảnh báo
    /// </summary>
    public AlertSeverity Severity { get; set; }

    /// <summary>
    /// Thời gian bắt đầu dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedStartTime { get; set; }

    /// <summary>
    /// Thời gian kết thúc dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedEndTime { get; set; }

    /// <summary>
    /// Thời điểm phát cảnh báo
    /// </summary>
    public DateTimeOffset AlertIssuedTime { get; set; }

    /// <summary>
    /// Trạng thái cảnh báo (Active, Expired, Cancelled)
    /// </summary>
    public WeatherAlertStatus Status { get; set; } = WeatherAlertStatus.Active;

    /// <summary>
    /// Tác động tới hoạt động nông nghiệp (ví dụ: hoãn gieo trồng, che chắn cây trồng)
    /// </summary>
    [MaxLength(500)]
    public string? FarmingImpact { get; set; }

    /// <summary>
    /// Hành động khuyến nghị
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedActions { get; set; }

    /// <summary>
    /// Nguồn phát cảnh báo
    /// </summary>
    [MaxLength(200)]
    public string? Source { get; set; }

    // Navigation properties
    /// <summary>
    /// Thông tin nông trại liên quan
    /// </summary>
    public virtual Farm? Farm { get; set; }
}