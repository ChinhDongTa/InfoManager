using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateDeviceAlertModel
{
    /// <summary>ID cảnh báo. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Loại cảnh báo.</summary>
    public AlertType? AlertType { get; set; }

    /// <summary>Nội dung cảnh báo.</summary>
    public string? Message { get; set; }

    /// <summary>Mức độ cảnh báo.</summary>
    public AlertSeverity? Severity { get; set; }

    /// <summary>Thời điểm xử lý.</summary>
    public DateTimeOffset? ResolvedTime { get; set; }

    /// <summary>Đã xử lý hay chưa.</summary>
    public bool? IsResolved { get; set; }

    /// <summary>Ghi chú xử lý.</summary>
    public string? ResolutionNotes { get; set; }

    public UpdateDeviceAlertModel(string id, DeviceAlertDto dto)
    {
        Id = id;
        AlertType = dto.AlertType;
        Message = dto.Message;
        Severity = dto.Severity;
        ResolvedTime = dto.ResolvedTime;
        IsResolved = dto.IsResolved;
        ResolutionNotes = dto.ResolutionNotes;
    }

    public UpdateDeviceAlertRequest CreateRequest()
    {
        return new UpdateDeviceAlertRequest
        (
            Id: this.Id,
            AlertType: this.AlertType,
            Message: this.Message,
            Severity: this.Severity,
            ResolvedTime: this.ResolvedTime,
            IsResolved: this.IsResolved,
            ResolutionNotes: this.ResolutionNotes
        );
    }

    public bool HasChanges(UpdateDeviceAlertModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}