using InfoManager.Application.Features.SFMS.Agricultural.Commands;
using InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class GrowthStageAlertMappings
{
    public static CreateGrowthStageAlertCommand ToCreateCommand(CreateGrowthStageAlertRequest request)
        => new()
        {
            AlertTime = request.AlertTime,
            AlertType = request.AlertType,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            Message = request.Message,
            Severity = request.Severity,
            ActionTaken = request.ActionTaken,
            ActualAchievementDate = request.ActualAchievementDate,
            ExpectedAchievementDate = request.ExpectedAchievementDate,
            IsResolved = request.IsResolved,
        };

    public static SearchGrowthStageAlertsQuery ToSearchQuery(SearchGrowthStageAlertRequest request)
    => new(
        CropPlantingId: request.CropPlantingId,
        GrowthStageId: request.GrowthStageId,
        AlertType: request.AlertType,
        Severity: request.Severity,
        IsResolved: request.IsResolved,
        PageNumber: request.PageNumber,
        PageSize: request.PageSize);

    public static UpdateGrowthStageAlertCommand ToUpdateCommand(string id, UpdateGrowthStageAlertRequest request)
    => new()
    {
        Id = id,
        AlertType = request.AlertType,
        IsResolved = request.IsResolved,
        Severity = request.Severity,
        ActionTaken = request.ActionTaken,
        ActualAchievementDate = request.ActualAchievementDate,
        ExpectedAchievementDate = request.ExpectedAchievementDate,
        Message = request.Message
    };
}