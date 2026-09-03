using InfoManager.Application.Features.SFMS.Agricultural.Commands;
using InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;
public static class GrowthStageMappings
{
    public static CreateGrowthStageCommand ToCreateCommand(CreateGrowthStageRequest request)
        => new()
        {
            StageName = request.StageName,
            CropId = request.CropId,
            CropScheduleId = request.CropScheduleId,
            StageSequence = request.StageSequence,
            DaysAfterPlanting = request.DaysAfterPlanting,
            StageDuration = request.StageDuration,
            Description = request.Description,
            MinTemperature = request.MinTemperature,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MaxHumidity = request.MaxHumidity,
            WaterRequirement = request.WaterRequirement,
            NitrogenRequirement = request.NitrogenRequirement,
            PhosphorusRequirement = request.PhosphorusRequirement,
            PotassiumRequirement = request.PotassiumRequirement,
            CommonPests = request.CommonPests,
            CommonDiseases = request.CommonDiseases,
            ManagementActivities = request.ManagementActivities
        };

    public static UpdateGrowthStageCommand ToUpdateCommand(string id, UpdateGrowthStageRequest request)
        => new()
        {
            Id = id,
            StageName = request.StageName,
            CropId = request.CropId,
            CropScheduleId = request.CropScheduleId,
            StageSequence = request.StageSequence,
            DaysAfterPlanting = request.DaysAfterPlanting,
            StageDuration = request.StageDuration,
            Description = request.Description,
            MinTemperature = request.MinTemperature,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MaxHumidity = request.MaxHumidity,
            WaterRequirement = request.WaterRequirement,
            NitrogenRequirement = request.NitrogenRequirement,
            PhosphorusRequirement = request.PhosphorusRequirement,
            PotassiumRequirement = request.PotassiumRequirement,
            CommonPests = request.CommonPests,
            CommonDiseases = request.CommonDiseases,
            ManagementActivities = request.ManagementActivities
        };
    public static SearchGrowthStageQuery ToSearchQuery(SearchGrowthStageRequest request)
        => new(Term: request.Term,
                                                 MinStageSequence: request.MinStageSequence,
                                                 MaxStageSequence: request.MaxStageSequence,
                                                 MinDaysAfterPlanting: request.MinDaysAfterPlanting,
                                                 MaxDaysAfterPlanting: request.MaxDaysAfterPlanting,
                                                 Temperature: request.Temperature,
                                                 Humidity: request.Humidity,
                                                 PageNumber: request.PageNumber,
                                                 PageSize: request.PageSize);
}
