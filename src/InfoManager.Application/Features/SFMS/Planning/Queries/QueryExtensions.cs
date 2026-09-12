using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.Application.Features.SFMS.Planning.Queries;

public static class QueryExtensions
{
    //======================================== Crop Cycle =======================================================

    public static IQueryable<CropCycleDto> ToCropCycleDto(this IQueryable<CropCycle> query)
    {
        return query.Select(c => new CropCycleDto(
            Id: c.Id,
            FarmId: c.FarmId,
            FarmName: c.Farm != null ? c.Farm.Name : null,
            CycleName: c.CycleName,
            CropId: c.CropId,
            CropName: c.Crop != null ? c.Crop.CommonName : null,
            CropVarietyId: c.CropVarietyId,
            CropVarietyName: c.CropVariety != null ? c.CropVariety.VarietyName : null,
            CropScheduleId: c.CropScheduleId,
            CropScheduleName: c.CropSchedule != null ? c.CropSchedule.ScheduleName : null,
            StartYear: c.StartYear,
            Season: c.Season,
            PlannedPlantingDate: c.PlannedPlantingDate,
            PlannedHarvestDate: c.PlannedHarvestDate,
            PlannedArea: c.PlannedArea,
            Status: c.Status,
            StatusName: c.Status.ToDisplayName(),
            EstimatedCost: c.EstimatedCost,
            EstimatedRevenue: c.EstimatedRevenue,
            EstimatedProfit: c.EstimatedProfit,
            ExpectedYield: c.ExpectedYield,
            TargetMarket: c.TargetMarket,
            TargetSellingPrice: c.TargetSellingPrice,
            Notes: c.Notes,
            PlantingCount: c.Plantings.Count(),
            Created: c.Created
        ));
    }

    public static IQueryable<CropCycleSummaryDto> ToCropCycleSummaryDto(this IQueryable<CropCycle> query)
    {
        return query.Select(c => new CropCycleSummaryDto(
            Id: c.Id,
            CycleName: c.CycleName,
            CropName: c.Crop != null ? c.Crop.CommonName : null,
            StartYear: c.StartYear,
            Season: c.Season,
            PlannedArea: c.PlannedArea,
            Status: c.Status,
            StatusName: c.Status.ToDisplayName()
        ));
    }

    public static IQueryable<CropCycle> ApplySorting(this IQueryable<CropCycle> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderBy(x=>x.CycleName).OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "plannedarea" => ascending ? query.OrderBy(a => a.PlannedArea) : query.OrderByDescending(a => a.PlannedArea),
            "plannedharvestdate" => ascending ? query.OrderBy(a => a.PlannedHarvestDate) : query.OrderByDescending(a => a.PlannedHarvestDate),
            _ => query
        };
    }


    //========================================= Harvest Plan ======================================================

    public static IQueryable<HarvestPlanDto> ToHarvestPlanDto(this IQueryable<HarvestPlan> query)
    {
        return query.Select(h => new HarvestPlanDto(
            Id: h.Id,
            CropCycleId: h.CropCycleId,
            CropCycleName: h.CropCycle != null ? h.CropCycle.CycleName : null,
            PlanName: h.PlanName,
            ExpectedStartDate: h.ExpectedStartDate,
            ExpectedEndDate: h.ExpectedEndDate,
            HarvestMethod: h.HarvestMethod,
            ExpectedYield: h.ExpectedYield,
            YieldUnit: h.YieldUnit,
            LaborRequirement: h.LaborRequirement,
            EquipmentRequired: h.EquipmentRequired,
            PostHarvestProcessing: h.PostHarvestProcessing,
            StorageRequirement: h.StorageRequirement,
            StorageDuration: h.StorageDuration,
            TransportationPlan: h.TransportationPlan,
            ExpectedSaleDate: h.ExpectedSaleDate,
            TargetBuyer: h.TargetBuyer,
            ExpectedSellingPrice: h.ExpectedSellingPrice,
            Status: h.Status,
            StatusName: h.Status.ToDisplayName(),
            RiskAssessment: h.RiskAssessment,
            Notes: h.Notes,
            Created: h.Created
        ));
    }

    public static IQueryable<HarvestPlanSummaryDto> ToHarvestPlanSummaryDto(this IQueryable<HarvestPlan> query)
    {
        return query.Select(h => new HarvestPlanSummaryDto(
            Id: h.Id,
            PlanName: h.PlanName,
            CropCycleName: h.CropCycle != null ? h.CropCycle.CycleName : null,
            ExpectedStartDate: h.ExpectedStartDate,
            ExpectedYield: h.ExpectedYield,
            Status: h.Status,
            StatusName: h.Status.ToDisplayName()
        ));
    }



    //========================================= Planting Plan ======================================================

    public static IQueryable<PlantingPlanDto> ToPlantingPlanDto(this IQueryable<PlantingPlan> query)
    {
        return query.Select(p => new PlantingPlanDto(
            Id: p.Id,
            CropCycleId: p.CropCycleId,
            CropCycleName: p.CropCycle != null ? p.CropCycle.CycleName : null,
            PlanName: p.PlanName,
            FieldAllocation: p.FieldAllocation,
            PlantingMethod: p.PlantingMethod,
            SeedQuantityRequired: p.SeedQuantityRequired,
            SeedSource: p.SeedSource,
            SeedbedPreparation: p.SeedbedPreparation,
            ExpectedGerminationRate: p.ExpectedGerminationRate,
            IrrigationPlan: p.IrrigationPlan,
            FertilizationPlan: p.FertilizationPlan,
            LaborRequirement: p.LaborRequirement,
            EquipmentRequired: p.EquipmentRequired,
            Status: p.Status,
            StatusName: p.Status.ToDisplayName(),
            Notes: p.Notes,
            Created: p.Created
        ));
    }

    public static IQueryable<PlantingPlanSummaryDto> ToPlantingPlanSummaryDto(this IQueryable<PlantingPlan> query)
    {
        return query.Select(p => new PlantingPlanSummaryDto(
            Id: p.Id,
            PlanName: p.PlanName,
            CropCycleName: p.CropCycle != null ? p.CropCycle.CycleName : null,
            PlantingMethod: p.PlantingMethod,
            SeedQuantityRequired: p.SeedQuantityRequired,
            Status: p.Status,
            StatusName: p.Status.ToDisplayName()
        ));
    }
}
