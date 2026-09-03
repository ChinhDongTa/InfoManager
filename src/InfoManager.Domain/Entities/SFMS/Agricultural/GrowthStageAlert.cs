namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Cảnh báo theo dõi giai đoạn sinh trưởng của cây trồng
/// </summary>
public class GrowthStageAlert : BaseAuditableEntity
{
    /// <summary>
    /// ID lần trồng cây liên quan
    /// </summary>
    public required string CropPlantingId { get; set; }

    /// <summary>
    /// ID giai đoạn sinh trưởng liên quan
    /// </summary>
    public required string GrowthStageId { get; set; }

    /// <summary>
    /// Loại cảnh báo
    /// </summary>
    public required GrowthAlertType AlertType { get; set; }

    /// <summary>
    /// Nội dung cảnh báo
    /// </summary>
    [MaxLength(500)]
    public required string Message { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng của cảnh báo
    /// </summary>
    public AlertSeverity Severity { get; set; }

    /// <summary>
    /// Thời điểm cảnh báo được kích hoạt
    /// </summary>
    public DateTimeOffset AlertTime { get; set; }

    /// <summary>
    /// Ngày dự kiến đạt giai đoạn
    /// </summary>
    public DateTimeOffset? ExpectedAchievementDate { get; set; }

    /// <summary>
    /// Ngày thực tế phát hiện / đạt giai đoạn
    /// </summary>
    public DateTimeOffset? ActualAchievementDate { get; set; }

    /// <summary>
    /// Cảnh báo đã được xử lý hay chưa
    /// </summary>
    public bool IsResolved { get; set; } = false;

    /// <summary>
    /// Hành động đã thực hiện để xử lý
    /// </summary>
    [MaxLength(500)]
    public string? ActionTaken { get; set; }

    // Navigation properties
    public virtual GrowthStage? GrowthStage { get; set; }
    public virtual CropPlanting? CropPlanting { get; set; }
}