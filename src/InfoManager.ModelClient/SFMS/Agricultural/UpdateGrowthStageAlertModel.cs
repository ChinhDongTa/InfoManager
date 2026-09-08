using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class UpdateGrowthStageAlertModel
{
    /// <summary>ID cảnh báo giai đoạn sinh trưởng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Loại cảnh báo.</summary>
    public GrowthAlertType? AlertType { get; set; }

    /// <summary>Nội dung cảnh báo.</summary>
    public string? Message { get; set; }

    /// <summary>Mức độ cảnh báo.</summary>
    public AlertSeverity? Severity { get; set; }

    /// <summary>Ngày đạt giai đoạn dự kiến.</summary>
    public DateTimeOffset? ExpectedAchievementDate { get; set; }

    /// <summary>Ngày đạt giai đoạn thực tế.</summary>
    public DateTimeOffset? ActualAchievementDate { get; set; }

    /// <summary>Đã xử lý hay chưa.</summary>
    public bool? IsResolved { get; set; }

    /// <summary>Hành động đã thực hiện.</summary>
    public string? ActionTaken { get; set; }

    public UpdateGrowthStageAlertModel(string id, GrowthStageAlertDto dto)
    {
        Id = id;
        AlertType = dto.AlertType;
        Message = dto.Message;
        Severity = dto.Severity;
        ExpectedAchievementDate = dto.ExpectedAchievementDate;
        ActualAchievementDate = dto.ActualAchievementDate;
        IsResolved = dto.IsResolved;
        ActionTaken = dto.ActionTaken;
    }

    public UpdateGrowthStageAlertRequest CreateRequest()
    {
        return new UpdateGrowthStageAlertRequest
        (
            Id: this.Id,
            AlertType: this.AlertType,
            Message: this.Message,
            Severity: this.Severity,
            ExpectedAchievementDate: this.ExpectedAchievementDate,
            ActualAchievementDate: this.ActualAchievementDate,
            IsResolved: this.IsResolved,
            ActionTaken: this.ActionTaken
        );
    }

    public bool HasChanges(UpdateGrowthStageAlertModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
