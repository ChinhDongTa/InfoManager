using InfoManager.Application.Features.SFMS.Planning.Queries.Gets;
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

    public static IQueryable<CropCycle> BuildSearchQuery(this IQueryable<CropCycle> query, SearchCropCyclesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(c => EF.Functions.ILike(c.CycleName, term)
                || (c.Season != null && EF.Functions.ILike(c.Season, term))
                || (c.TargetMarket != null && EF.Functions.ILike(c.TargetMarket, term))
                || (c.Notes != null && EF.Functions.ILike(c.Notes, term))
                || (c.Crop != null && EF.Functions.ILike(c.Crop.CommonName, term))
                || (c.CropVariety != null && EF.Functions.ILike(c.CropVariety.VarietyName, term))
            );
        }
        if (search.StartYear.HasValue)
            query = query.Where(c => c.StartYear == search.StartYear.Value);
        if (search.Status.HasValue)
            query = query.Where(c => c.Status == search.Status.Value);
        return query;
    }

    /// <summary>
    /// sortBy: cyclename, status, startyear, plannedarea, plannedharvestdate
    /// </summary>
    public static IQueryable<CropCycle> ApplySorting(this IQueryable<CropCycle> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.CycleName);
        }
        return sortBy.ToLower() switch
        {
            "cyclename" => ascending ? query.OrderBy(a => a.CycleName) : query.OrderByDescending(a => a.CycleName),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "startyear" => ascending ? query.OrderBy(a => a.StartYear) : query.OrderByDescending(a => a.StartYear),
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

    public static IQueryable<HarvestPlan> BuildSearchQuery(this IQueryable<HarvestPlan> query, SearchHarvestPlansQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(h => EF.Functions.ILike(h.PlanName, term)
                || (h.HarvestMethod != null && EF.Functions.ILike(h.HarvestMethod, term))
                || (h.TargetBuyer != null && EF.Functions.ILike(h.TargetBuyer, term))
                || (h.EquipmentRequired != null && EF.Functions.ILike(h.EquipmentRequired, term))
                || (h.Notes != null && EF.Functions.ILike(h.Notes, term))
                || (h.CropCycle != null && EF.Functions.ILike(h.CropCycle.CycleName, term))
            );
        }
        if (search.Status.HasValue)
            query = query.Where(h => h.Status == search.Status.Value);
        if (search.ExpectedDate.HasValue)
        {
            var expectedDate = search.ExpectedDate.Value;
            query = query.Where(h => h.ExpectedStartDate <= expectedDate
                && (h.ExpectedEndDate == null || h.ExpectedEndDate >= expectedDate));
        }
        return query;
    }

    /// <summary>
    /// sortBy: planname, status, expectedstartdate, expectedyield
    /// </summary>
    public static IQueryable<HarvestPlan> ApplySorting(this IQueryable<HarvestPlan> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.ExpectedStartDate)
                .ThenByDescending(a => a.Created)
                .ThenBy(a => a.PlanName);
        }
        return sortBy.ToLower() switch
        {
            "planname" => ascending ? query.OrderBy(a => a.PlanName) : query.OrderByDescending(a => a.PlanName),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "expectedstartdate" => ascending ? query.OrderBy(a => a.ExpectedStartDate) : query.OrderByDescending(a => a.ExpectedStartDate),
            "expectedyield" => ascending ? query.OrderBy(a => a.ExpectedYield) : query.OrderByDescending(a => a.ExpectedYield),
            _ => query
        };
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

    public static IQueryable<PlantingPlan> BuildSearchQuery(this IQueryable<PlantingPlan> query, SearchPlantingPlansQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.PlanName, term)
                || (p.PlantingMethod != null && EF.Functions.ILike(p.PlantingMethod, term))
                || (p.SeedSource != null && EF.Functions.ILike(p.SeedSource, term))
                || (p.FieldAllocation != null && EF.Functions.ILike(p.FieldAllocation, term))
                || (p.Notes != null && EF.Functions.ILike(p.Notes, term))
                || (p.CropCycle != null && EF.Functions.ILike(p.CropCycle.CycleName, term))
            );
        }
        if (search.Status.HasValue)
            query = query.Where(p => p.Status == search.Status.Value);
        return query;
    }

    /// <summary>
    /// sortBy: planname, status, plantingmethod, seedquantityrequired
    /// </summary>
    public static IQueryable<PlantingPlan> ApplySorting(this IQueryable<PlantingPlan> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.PlanName);
        }
        return sortBy.ToLower() switch
        {
            "planname" => ascending ? query.OrderBy(a => a.PlanName) : query.OrderByDescending(a => a.PlanName),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "plantingmethod" => ascending ? query.OrderBy(a => a.PlantingMethod) : query.OrderByDescending(a => a.PlantingMethod),
            "seedquantityrequired" => ascending ? query.OrderBy(a => a.SeedQuantityRequired) : query.OrderByDescending(a => a.SeedQuantityRequired),
            _ => query
        };
    }
}