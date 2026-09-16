using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Weather;

namespace InfoManager.ModelClient.SFMS.Weather;

public class CreateWeatherAlertModel
{
    /// <summary>
    /// ID cảnh báo
    /// </summary>
    [Required]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Loại cảnh báo
    /// </summary>
    [Required]
    public WeatherAlertType AlertType { get; set; }

    /// <summary>
    /// Mô tả cảnh báo
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Mức độ nghiêm trọng
    /// </summary>
    [Required]
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
    [Required]
    public DateTimeOffset AlertIssuedTime { get; set; }

    /// <summary>
    /// Trạng thái cảnh báo
    /// </summary>
    public WeatherAlertStatus? Status { get; set; }

    /// <summary>
    /// Tác động tới nông nghiệp
    /// </summary>
    public string? FarmingImpact { get; set; }

    /// <summary>
    /// Hành động khuyến nghị
    /// </summary>
    public string? RecommendedActions { get; set; }

    /// <summary>
    /// Nguồn phát cảnh báo
    /// </summary>
    public string? Source { get; set; }

    public CreateWeatherAlertRequest CreateRequest()
    {
        return new CreateWeatherAlertRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            AlertType: this.AlertType,
            Description: this.Description,
            Severity: this.Severity,
            ExpectedStartTime: this.ExpectedStartTime,
            ExpectedEndTime: this.ExpectedEndTime,
            AlertIssuedTime: this.AlertIssuedTime,
            Status: this.Status,
            FarmingImpact: this.FarmingImpact,
            RecommendedActions: this.RecommendedActions,
            Source: this.Source
        );
    }
}