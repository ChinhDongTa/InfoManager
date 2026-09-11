using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Weather;

namespace InfoManager.ModelClient.SFMS.Weather;

public class UpdateWeatherAlertModel
{
    /// <summary>ID cảnh báo. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại liên quan.</summary>
    public string? FarmId { get; set; }

    /// <summary>Loại cảnh báo.</summary>
    public WeatherAlertType? AlertType { get; set; }

    /// <summary>Mô tả cảnh báo.</summary>
    public string? Description { get; set; }

    /// <summary>Mức độ nghiêm trọng.</summary>
    public AlertSeverity? Severity { get; set; }

    /// <summary>Thời gian bắt đầu dự kiến.</summary>
    public DateTimeOffset? ExpectedStartTime { get; set; }

    /// <summary>Thời gian kết thúc dự kiến.</summary>
    public DateTimeOffset? ExpectedEndTime { get; set; }

    /// <summary>Thời điểm phát cảnh báo.</summary>
    public DateTimeOffset? AlertIssuedTime { get; set; }

    /// <summary>Trạng thái cảnh báo.</summary>
    public WeatherAlertStatus? Status { get; set; }

    /// <summary>Tác động tới nông nghiệp.</summary>
    public string? FarmingImpact { get; set; }

    /// <summary>Hành động khuyến nghị.</summary>
    public string? RecommendedActions { get; set; }

    /// <summary>Nguồn phát cảnh báo.</summary>
    public string? Source { get; set; }

    public UpdateWeatherAlertModel(string id, WeatherAlertDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FarmId = dto.FarmId;
        AlertType = dto.AlertType;
        Description = dto.Description;
        Severity = dto.Severity;
        ExpectedStartTime = dto.ExpectedStartTime;
        ExpectedEndTime = dto.ExpectedEndTime;
        AlertIssuedTime = dto.AlertIssuedTime;
        Status = dto.Status;
        FarmingImpact = dto.FarmingImpact;
        RecommendedActions = dto.RecommendedActions;
        Source = dto.Source;
    }

    public UpdateWeatherAlertRequest CreateRequest()
    {
        return new UpdateWeatherAlertRequest
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

    public bool HasChanges(UpdateWeatherAlertModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
