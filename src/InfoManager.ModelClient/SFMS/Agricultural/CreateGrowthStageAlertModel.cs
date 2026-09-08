using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class CreateGrowthStageAlertModel
{
    /// <summary>
    /// Lượt trồng
    /// </summary>
    [Required]
    public string CropPlantingId { get; set; } = string.Empty;

    /// <summary>
    /// Giai đoạn sinh trưởng
    /// </summary>
    [Required]
    public string GrowthStageId { get; set; } = string.Empty;

    /// <summary>
    /// Loại cảnh báo
    /// </summary>
    [Required]
    public GrowthAlertType AlertType { get; set; }

    /// <summary>
    /// Nội dung cảnh báo
    /// </summary>
    [Required]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Mức độ cảnh báo
    /// </summary>
    public AlertSeverity Severity { get; set; }

    /// <summary>
    /// Thời điểm cảnh báo
    /// </summary>
    public DateTimeOffset AlertTime { get; set; }

    /// <summary>
    /// Ngày đạt giai đoạn dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedAchievementDate { get; set; }

    /// <summary>
    /// Ngày đạt giai đoạn thực tế
    /// </summary>
    public DateTimeOffset? ActualAchievementDate { get; set; }

    /// <summary>
    /// Đã xử lý hay chưa
    /// </summary>
    public bool IsResolved { get; set; }

    /// <summary>
    /// Hành động đã thực hiện
    /// </summary>
    public string? ActionTaken { get; set; }

    public CreateGrowthStageAlertRequest CreateRequest()
    {
        return new CreateGrowthStageAlertRequest
        (
            CropPlantingId: this.CropPlantingId,
            GrowthStageId: this.GrowthStageId,
            AlertType: this.AlertType,
            Message: this.Message,
            Severity: this.Severity,
            AlertTime: this.AlertTime,
            ExpectedAchievementDate: this.ExpectedAchievementDate,
            ActualAchievementDate: this.ActualAchievementDate,
            IsResolved: this.IsResolved,
            ActionTaken: this.ActionTaken
        );
    }
}