namespace InfoManager.Application.Features.SFMS.Agricultural.Queries;

internal static class QueryableExtensions
{
    //=============================== Crop Queryable Extensions ==========================================
    public static IQueryable<CropDto> ToCropDto(this IQueryable<Crop> query)
    {
        return query.Select(a => new CropDto(Id: a.Id,
                                             CommonName: a.CommonName,
                                             ScientificName: a.ScientificName,
                                             Description: a.Description,
                                             Family: a.Family,
                                             DaysToMaturity: a.DaysToMaturity,
                                             MinTemperature: a.MinTemperature,
                                             MaxTemperature: a.MaxTemperature,
                                             MinHumidity: a.MinHumidity,
                                             MaxHumidity: a.MaxHumidity,
                                             MinSoilPh: a.MinSoilPh,
                                             MaxSoilPh: a.MaxSoilPh,
                                             WaterRequirement: a.WaterRequirement,
                                             SunLightHours: a.SunLightHours,
                                             IsActive: a.IsActive,
                                             Created: a.Created));
    }

    public static IQueryable<CropSummaryDto> ToCropSummaryDto(this IQueryable<Crop> query)
    {
        return query.Select(a => new CropSummaryDto(Id: a.Id,
                                                    CommonName: a.CommonName,
                                                    ScientificName: a.ScientificName,
                                                    Family: a.Family,
                                                    DaysToMaturity: a.DaysToMaturity,
                                                    IsActive: a.IsActive));
    }

    /// <summary>
    /// Applies sorting to the Crop query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">commonname, scientificname, daysToMaturity</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Crop> ApplySorting(this IQueryable<Crop> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "commonname" => ascending ? query.OrderBy(a => a.CommonName) : query.OrderByDescending(a => a.CommonName),
            "scientificname" => ascending ? query.OrderBy(a => a.ScientificName) : query.OrderByDescending(a => a.ScientificName),
            "daysToMaturity" => ascending ? query.OrderBy(a => a.DaysToMaturity) : query.OrderByDescending(a => a.DaysToMaturity),
            _ => query
        };
    }

    //=============================== CropPlanting Queryable Extensions ==========================================
    public static IQueryable<CropPlantingDto> ToCropPlantingDto(this IQueryable<CropPlanting> query)
    {
        return query.Select(a => new CropPlantingDto(
            Id: a.Id,
            PlantingCode: a.PlantingCode,
            FieldId: a.FieldId,
            FieldName: a.Field!= null ? a.Field.Name : null,
            CropId: a.CropId,
            CropName: a.Crop!= null ? a.Crop.CommonName : null,
            CropVarietyId: a.CropVarietyId,
            CropVarietyName: a.CropVariety != null ? a.CropVariety.VarietyName : null,
            CropScheduleId: a.CropScheduleId,
            CropScheduleName: a.CropSchedule != null ? a.CropSchedule.ScheduleName : null,
            PlantingDate: a.PlantingDate,
            ExpectedHarvestDate: a.ExpectedHarvestDate,
            ActualHarvestDate: a.ActualHarvestDate,
            PlantedArea: a.PlantedArea,
            QuantityPlanted: a.QuantityPlanted,
            PlantedUnit: a.PlantedUnit,
            StatusName: a.Status.ToDisplayName(),
            Notes: a.Notes,
            Created: a.Created
        ));
    }
    public static IQueryable<CropPlantingSummaryDto> ToCropPlantingSummaryDto(this IQueryable<CropPlanting> query)
    {
        return query.Select(a => new CropPlantingSummaryDto(
            Id: a.Id,
            PlantingCode: a.PlantingCode,
            CropVarietyName: a.CropVariety != null ? a.CropVariety.VarietyName : null,
            PlantingDate: a.PlantingDate,
            ExpectedHarvestDate: a.ExpectedHarvestDate,
            PlantedArea: a.PlantedArea,
            StatusName: a.Status.ToDisplayName()
        ));
    }

    /// <summary>
    /// Applies sorting to the CropPlanting query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">plantingdate, expectedharvestdate, plantedarea</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<CropPlanting> ApplySorting(this IQueryable<CropPlanting> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "plantingdate" => ascending ? query.OrderBy(a => a.PlantingDate) : query.OrderByDescending(a => a.PlantingDate),
            "expectedharvestdate" => ascending ? query.OrderBy(a => a.ExpectedHarvestDate) : query.OrderByDescending(a => a.ExpectedHarvestDate),
            "plantedarea" => ascending ? query.OrderBy(a => a.PlantedArea) : query.OrderByDescending(a => a.PlantedArea),
            _ => query
        };
    }
    //=============================== CropSchedule Queryable Extensions ==========================================

    public static IQueryable<CropScheduleDto> ToCropScheduleDto(this IQueryable<CropSchedule> query)
    {
        return query.Select(a => new CropScheduleDto(
            Id: a.Id,
            ScheduleName: a.ScheduleName,
            CropId: a.CropId,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            CropVarietyId: a.CropVarietyId,
            CropVarietyName: a.CropVariety != null ? a.CropVariety.VarietyName : null,
            PlantingSeason: a.PlantingSeason,
            PlantingDateRange: a.PlantingDateRange,
            HarvestDateRange: a.HarvestDateRange,
            DaysToHarvest: a.DaysToHarvest,
            PlantSpacing: a.PlantSpacing,
            RowSpacing: a.RowSpacing,
            IrrigationSchedule: a.IrrigationSchedule,
            FertilizationSchedule: a.FertilizationSchedule,
            PesticideSchedule: a.PesticideSchedule,
            ExpectedYield: a.ExpectedYield,
            EstimatedCost: a.EstimatedCost,
            IsActive: a.IsActive,
            Notes: a.Notes,
            Created: a.Created
        ));
    }
    public static IQueryable<CropScheduleSummaryDto> ToCropScheduleSummaryDto(this IQueryable<CropSchedule> query)
    {
        return query.Select(a => new CropScheduleSummaryDto(
            Id: a.Id,
            ScheduleName: a.ScheduleName,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            CropVarietyName: a.CropVariety != null ? a.CropVariety.VarietyName : null,
            PlantingSeason: a.PlantingSeason,
            DaysToHarvest: a.DaysToHarvest,
            ExpectedYield: a.ExpectedYield,
            IsActive: a.IsActive
        ));
    }
    /// <summary>
    /// Applies sorting to the CropSchedule query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">schedulename, daysToHarvest, expectedyield</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<CropSchedule> ApplySorting(this IQueryable<CropSchedule> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "schedulename" => ascending ? query.OrderBy(a => a.ScheduleName) : query.OrderByDescending(a => a.ScheduleName),
            "daysToHarvest" => ascending ? query.OrderBy(a => a.DaysToHarvest) : query.OrderByDescending(a => a.DaysToHarvest),
            "expectedyield" => ascending ? query.OrderBy(a => a.ExpectedYield) : query.OrderByDescending(a => a.ExpectedYield),
            _ => query
        };
    }

    //=============================== CropVariety Queryable Extensions ==========================================
    public static IQueryable<CropVarietyDto> ToCropVarietyDto(this IQueryable<CropVariety> query)
    {
        return query.Select(a => new CropVarietyDto(
            Id: a.Id,
            VarietyName: a.VarietyName,
            CropId: a.CropId,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            BreederName: a.BreederName,
            DaysToMaturity: a.DaysToMaturity,
            ExpectedYield: a.ExpectedYield,
            YieldUnit: a.YieldUnit,
            SeedRate: a.SeedRate,
            DiseaseResistance: a.DiseaseResistance,
            PestResistance: a.PestResistance,
            ClimateSuitability: a.ClimateSuitability,
            YearOfRelease: a.YearOfRelease,
            IsActive: a.IsActive,
            Created: a.Created
        ));
    }
    public static IQueryable<CropVarietySummaryDto> ToCropVarietySummaryDto(this IQueryable<CropVariety> query)
    {
        return query.Select(a => new CropVarietySummaryDto(
            Id: a.Id,
            VarietyName: a.VarietyName,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            BreederName: a.BreederName,
            DaysToMaturity: a.DaysToMaturity,
            ExpectedYield: a.ExpectedYield,
            YieldUnit: a.YieldUnit,
            IsActive: a.IsActive
        ));
    }

    /// <summary>
    /// Applies sorting to the CropVariety query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">varietyname, daystomaturity, expectedyield</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<CropVariety> ApplySorting(this IQueryable<CropVariety> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "varietyname" => ascending ? query.OrderBy(a => a.VarietyName) : query.OrderByDescending(a => a.VarietyName),
            "daystomaturity" => ascending ? query.OrderBy(a => a.DaysToMaturity) : query.OrderByDescending(a => a.DaysToMaturity),
            "expectedyield" => ascending ? query.OrderBy(a => a.ExpectedYield) : query.OrderByDescending(a => a.ExpectedYield),
            _ => query
        };
    }

    //=============================== GrowthStageAlert Queryable Extensions ==========================================
    public static IQueryable<GrowthStageAlertDto> ToGrowthStageAlertDto(this IQueryable<GrowthStageAlert> query)
    {
        return query.Select(a => new GrowthStageAlertDto(
            Id: a.Id,
            CropPlantingId: a.CropPlantingId,
            CropPlantingName: a.CropPlanting != null ? a.CropPlanting.PlantingCode : null,
            GrowthStageId: a.GrowthStageId,
            GrowthStageName: a.GrowthStage!=null?a.GrowthStage.StageName : null,
            AlertTypeName: a.AlertType.ToDisplayName(),
            Message: a.Message,
            SeverityName: a.Severity.ToDisplayName(),
            AlertTime: a.AlertTime,
            ExpectedAchievementDate: a.ExpectedAchievementDate,
            ActualAchievementDate: a.ActualAchievementDate,
            IsResolved: a.IsResolved,
            ActionTaken: a.ActionTaken,
            Created: a.Created
        ));
    }

    public static IQueryable<GrowthStageAlertSummaryDto> ToGrowthStageAlertSummaryDto(this IQueryable<GrowthStageAlert> query)
    {
        return query.Select(a => new GrowthStageAlertSummaryDto(
            Id: a.Id,
            GrowthStageName: a.GrowthStage != null ? a.GrowthStage.StageName : null,
            AlertTypeName: a.AlertType.ToDisplayName(),
            Message: a.Message,
            SeverityName: a.Severity.ToDisplayName(),
            AlertTime: a.AlertTime,
            IsResolved: a.IsResolved
        ));
    }

    /// <summary>
    /// Applies sorting to the GrowthStageAlert query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">alerttime, severity</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<GrowthStageAlert> ApplySorting(this IQueryable<GrowthStageAlert> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "alerttime" => ascending ? query.OrderBy(a => a.AlertTime) : query.OrderByDescending(a => a.AlertTime),
            "severity" => ascending ? query.OrderBy(a => a.Severity) : query.OrderByDescending(a => a.Severity),
            _ => query
        };
    }

    //=============================== GrowthStage Queryable Extensions ==========================================
    public static IQueryable<GrowthStageDto> ToGrowthStageDto(this IQueryable<GrowthStage> query)
    {
        return query.Select(a => new GrowthStageDto(
            Id: a.Id,
            StageName: a.StageName,
            CropId: a.CropId,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            CropScheduleId: a.CropScheduleId,
            CropScheduleName: a.CropSchedule != null ? a.CropSchedule.ScheduleName : null,
            StageSequence: a.StageSequence,
            DaysAfterPlanting: a.DaysAfterPlanting,
            StageDuration: a.StageDuration,
            Description: a.Description,
            MinTemperature: a.MinTemperature,
            MaxTemperature: a.MaxTemperature,
            MinHumidity: a.MinHumidity,
            MaxHumidity: a.MaxHumidity,
            WaterRequirement: a.WaterRequirement,
            NitrogenRequirement: a.NitrogenRequirement,
            PhosphorusRequirement: a.PhosphorusRequirement,
            PotassiumRequirement: a.PotassiumRequirement,
            CommonPests: a.CommonPests,
            CommonDiseases: a.CommonDiseases,
            ManagementActivities: a.ManagementActivities,
            Created: a.Created
        ));
    }

    public static IQueryable<GrowthStageSummaryDto> ToGrowthStageSummaryDto(this IQueryable<GrowthStage> query)
    {
        return query.Select(a => new GrowthStageSummaryDto(
            Id: a.Id,
            StageName: a.StageName,
            CropName: a.Crop != null ? a.Crop.CommonName : null,
            StageSequence: a.StageSequence,
            DaysAfterPlanting: a.DaysAfterPlanting,
            StageDuration: a.StageDuration,
            Description: a.Description
        ));
    }
    /// <summary>
    /// Applies sorting to the GrowthStage query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">stagename, stageSequence, daysAfterPlanting</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<GrowthStage> ApplySorting(this IQueryable<GrowthStage> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "stagename" => ascending ? query.OrderBy(a => a.StageName) : query.OrderByDescending(a => a.StageName),
            "stageSequence" => ascending ? query.OrderBy(a => a.StageSequence) : query.OrderByDescending(a => a.StageSequence),
            "daysAfterPlanting" => ascending ? query.OrderBy(a => a.DaysAfterPlanting) : query.OrderByDescending(a => a.DaysAfterPlanting),
            _ => query
        };
    }
}