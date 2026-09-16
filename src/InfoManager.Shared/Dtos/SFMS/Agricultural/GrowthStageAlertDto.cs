namespace InfoManager.Shared.Dtos.SFMS.Agricultural;

// ======================== GrowthStageAlert ========================

public record GrowthStageAlertDto(
    string Id,
    string CropPlantingId,
    string? CropPlantingName,          // hoặc thông tin Field/Crop nếu cần
    string GrowthStageId,
    string? GrowthStageName,
    GrowthAlertType AlertType,
    string? AlertTypeName,
    string Message,
    AlertSeverity Severity,
    string? SeverityName,
    DateTimeOffset AlertTime,
    DateTimeOffset? ExpectedAchievementDate,
    DateTimeOffset? ActualAchievementDate,
    bool IsResolved,
    string? ActionTaken,
    DateTimeOffset Created
);

public record GrowthStageAlertSummaryDto(
    string Id,
    string? GrowthStageName,
    string? AlertTypeName,
    string Message,
    string? SeverityName,
    DateTimeOffset AlertTime,
    bool IsResolved
);

public record CreateGrowthStageAlertRequest(
    string CropPlantingId,
    string GrowthStageId,
    GrowthAlertType AlertType,
    string Message,
    AlertSeverity Severity,
    DateTimeOffset AlertTime,
    DateTimeOffset? ExpectedAchievementDate,
    DateTimeOffset? ActualAchievementDate,
    bool IsResolved,
    string? ActionTaken
);

public record UpdateGrowthStageAlertRequest(
    string Id,
    GrowthAlertType? AlertType,
    string? Message,
    AlertSeverity? Severity,
    DateTimeOffset? ExpectedAchievementDate,
    DateTimeOffset? ActualAchievementDate,
    bool? IsResolved,
    string? ActionTaken
);

public record SearchGrowthStageAlertRequest(
    string? CropPlantingId,
    string? GrowthStageId,
    GrowthAlertType? AlertType,
    AlertSeverity? Severity,
    bool? IsResolved,
    int PageNumber,
    int PageSize
);