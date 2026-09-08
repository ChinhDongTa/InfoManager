using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class CreateDeviceAlertModel
{
    /// <summary>
    /// Thiết bị phát sinh cảnh báo
    /// </summary>
    [Required]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// Loại cảnh báo
    /// </summary>
    [Required]
    public AlertType AlertType { get; set; }

    /// <summary>
    /// Nội dung cảnh báo
    /// </summary>
    [Required]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Mức độ cảnh báo
    /// </summary>
    public AlertSeverity Severity { get; set; } = AlertSeverity.Info;

    /// <summary>
    /// Thời điểm cảnh báo
    /// </summary>
    public DateTimeOffset AlertTime { get; set; }

    /// <summary>
    /// Đã xử lý hay chưa
    /// </summary>
    public bool IsResolved { get; set; }

    /// <summary>
    /// Ghi chú xử lý
    /// </summary>
    public string? ResolutionNotes { get; set; }

    public CreateDeviceAlertRequest CreateRequest()
    {
        return new CreateDeviceAlertRequest
        (
            DeviceId: this.DeviceId,
            AlertType: this.AlertType,
            Message: this.Message,
            Severity: this.Severity,
            AlertTime: this.AlertTime,
            IsResolved: this.IsResolved,
            ResolutionNotes: this.ResolutionNotes
        );
    }
}