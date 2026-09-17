using InfoManager.Application.Features.SFMS.Resources.Queries.Gets;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries;

public static class QueryExtensions
{
    public static IQueryable<FertilizerDto> ToFertilizerDto(this IQueryable<Fertilizer> query)
        => query.Select(f => new FertilizerDto(
            f.Id, f.Name, f.FertilizerType, f.FertilizerType.ToDisplayName(),
            f.NitrogenPercent, f.PhosphorusPercent, f.PotassiumPercent,
            f.Unit, f.Manufacturer, f.IsActive, f.Notes, f.Created));

    public static IQueryable<FertilizerSummaryDto> ToFertilizerSummaryDto(this IQueryable<Fertilizer> query)
        => query.Select(f => new FertilizerSummaryDto(
            f.Id, f.Name, f.FertilizerType.ToDisplayName(), f.Unit, f.IsActive));

    public static IQueryable<Fertilizer> BuildSearchQuery(this IQueryable<Fertilizer> query, SearchFertilizersQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(f => EF.Functions.ILike(f.Name, term)
                || (f.Manufacturer != null && EF.Functions.ILike(f.Manufacturer, term))
                || (f.Notes != null && EF.Functions.ILike(f.Notes, term)));
        }
        if (search.FertilizerType.HasValue) query = query.Where(f => f.FertilizerType == search.FertilizerType.Value);
        if (search.IsActive.HasValue) query = query.Where(f => f.IsActive == search.IsActive.Value);
        return query;
    }

    public static IQueryable<Fertilizer> ApplySorting(this IQueryable<Fertilizer> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.Name);
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "fertilizertype" => ascending ? query.OrderBy(a => a.FertilizerType) : query.OrderByDescending(a => a.FertilizerType),
            "isactive" => ascending ? query.OrderBy(a => a.IsActive) : query.OrderByDescending(a => a.IsActive),
            _ => query
        };
    }

    public static IQueryable<PesticideDto> ToPesticideDto(this IQueryable<Pesticide> query)
        => query.Select(p => new PesticideDto(
            p.Id, p.Name, p.ActiveIngredient, p.PesticideType, p.PesticideType.ToDisplayName(),
            p.ToxicityLevel, p.ToxicityLevel.ToDisplayName(), p.PreHarvestIntervalDays,
            p.Unit, p.Manufacturer, p.RegistrationNumber, p.IsActive, p.Notes, p.Created));

    public static IQueryable<PesticideSummaryDto> ToPesticideSummaryDto(this IQueryable<Pesticide> query)
        => query.Select(p => new PesticideSummaryDto(
            p.Id, p.Name, p.PesticideType.ToDisplayName(), p.Unit, p.IsActive));

    public static IQueryable<Pesticide> BuildSearchQuery(this IQueryable<Pesticide> query, SearchPesticidesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.Name, term)
                || (p.ActiveIngredient != null && EF.Functions.ILike(p.ActiveIngredient, term))
                || (p.Manufacturer != null && EF.Functions.ILike(p.Manufacturer, term))
                || (p.RegistrationNumber != null && EF.Functions.ILike(p.RegistrationNumber, term)));
        }
        if (search.PesticideType.HasValue) query = query.Where(p => p.PesticideType == search.PesticideType.Value);
        if (search.IsActive.HasValue) query = query.Where(p => p.IsActive == search.IsActive.Value);
        return query;
    }

    public static IQueryable<Pesticide> ApplySorting(this IQueryable<Pesticide> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.Name);
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "pesticidetype" => ascending ? query.OrderBy(a => a.PesticideType) : query.OrderByDescending(a => a.PesticideType),
            "toxicitylevel" => ascending ? query.OrderBy(a => a.ToxicityLevel) : query.OrderByDescending(a => a.ToxicityLevel),
            "isactive" => ascending ? query.OrderBy(a => a.IsActive) : query.OrderByDescending(a => a.IsActive),
            _ => query
        };
    }

    public static IQueryable<FertilizationPlanDto> ToFertilizationPlanDto(this IQueryable<FertilizationPlan> query)
        => query.Select(p => new FertilizationPlanDto(
            p.Id, p.FarmId, p.Farm != null ? p.Farm.Name : null,
            p.CropPlantingId, p.CropPlanting != null ? p.CropPlanting.PlantingCode : null,
            p.GrowthStageId, p.GrowthStage != null ? p.GrowthStage.StageName : null,
            p.FertilizerId, p.Fertilizer != null ? p.Fertilizer.Name : null,
            p.PlanName, p.PlannedDate, p.DaysAfterPlanting, p.PlannedQuantity, p.Unit,
            p.ApplicationMethod, p.Status, p.Status.ToDisplayName(), p.Notes, p.Created));

    public static IQueryable<FertilizationPlanSummaryDto> ToFertilizationPlanSummaryDto(this IQueryable<FertilizationPlan> query)
        => query.Select(p => new FertilizationPlanSummaryDto(
            p.Id, p.PlanName,
            p.CropPlanting != null ? p.CropPlanting.PlantingCode : null,
            p.Fertilizer != null ? p.Fertilizer.Name : null,
            p.PlannedDate, p.PlannedQuantity, p.Status.ToDisplayName()));

    public static IQueryable<FertilizationPlan> BuildSearchQuery(this IQueryable<FertilizationPlan> query, SearchFertilizationPlansQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.PlanName, term)
                || (p.Notes != null && EF.Functions.ILike(p.Notes, term))
                || (p.Fertilizer != null && EF.Functions.ILike(p.Fertilizer.Name, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId)) query = query.Where(p => p.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.FertilizerId)) query = query.Where(p => p.FertilizerId == search.FertilizerId);
        if (search.Status.HasValue) query = query.Where(p => p.Status == search.Status.Value);
        return query;
    }

    public static IQueryable<FertilizationPlan> ApplySorting(this IQueryable<FertilizationPlan> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.PlannedDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "planname" => ascending ? query.OrderBy(a => a.PlanName) : query.OrderByDescending(a => a.PlanName),
            "planneddate" => ascending ? query.OrderBy(a => a.PlannedDate) : query.OrderByDescending(a => a.PlannedDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    public static IQueryable<PesticidePlanDto> ToPesticidePlanDto(this IQueryable<PesticidePlan> query)
        => query.Select(p => new PesticidePlanDto(
            p.Id, p.FarmId, p.Farm != null ? p.Farm.Name : null,
            p.CropPlantingId, p.CropPlanting != null ? p.CropPlanting.PlantingCode : null,
            p.PesticideId, p.Pesticide != null ? p.Pesticide.Name : null,
            p.PlanName, p.Target, p.PlannedDate, p.PlannedQuantity, p.Unit,
            p.ApplicationMethod, p.Status, p.Status.ToDisplayName(), p.Notes, p.Created));

    public static IQueryable<PesticidePlanSummaryDto> ToPesticidePlanSummaryDto(this IQueryable<PesticidePlan> query)
        => query.Select(p => new PesticidePlanSummaryDto(
            p.Id, p.PlanName,
            p.CropPlanting != null ? p.CropPlanting.PlantingCode : null,
            p.Pesticide != null ? p.Pesticide.Name : null,
            p.PlannedDate, p.PlannedQuantity, p.Status.ToDisplayName()));

    public static IQueryable<PesticidePlan> BuildSearchQuery(this IQueryable<PesticidePlan> query, SearchPesticidePlansQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.PlanName, term)
                || (p.Target != null && EF.Functions.ILike(p.Target, term))
                || (p.Notes != null && EF.Functions.ILike(p.Notes, term))
                || (p.Pesticide != null && EF.Functions.ILike(p.Pesticide.Name, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId)) query = query.Where(p => p.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.PesticideId)) query = query.Where(p => p.PesticideId == search.PesticideId);
        if (search.Status.HasValue) query = query.Where(p => p.Status == search.Status.Value);
        return query;
    }

    public static IQueryable<PesticidePlan> ApplySorting(this IQueryable<PesticidePlan> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.PlannedDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "planname" => ascending ? query.OrderBy(a => a.PlanName) : query.OrderByDescending(a => a.PlanName),
            "planneddate" => ascending ? query.OrderBy(a => a.PlannedDate) : query.OrderByDescending(a => a.PlannedDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    public static IQueryable<FertilizerApplicationDto> ToFertilizerApplicationDto(this IQueryable<FertilizerApplication> query)
        => query.Select(a => new FertilizerApplicationDto(
            a.Id, a.FarmId, a.Farm != null ? a.Farm.Name : null,
            a.FieldId, a.Field != null ? a.Field.Name : null,
            a.CropPlantingId, a.CropPlanting != null ? a.CropPlanting.PlantingCode : null,
            a.FertilizationPlanId, a.FertilizerId, a.Fertilizer != null ? a.Fertilizer.Name : null,
            a.AppliedDate, a.AppliedQuantity, a.Unit, a.ApplicationMethod, a.AppliedBy, a.Cost, a.Notes, a.Created));

    public static IQueryable<FertilizerApplicationSummaryDto> ToFertilizerApplicationSummaryDto(this IQueryable<FertilizerApplication> query)
        => query.Select(a => new FertilizerApplicationSummaryDto(
            a.Id,
            a.CropPlanting != null ? a.CropPlanting.PlantingCode : null,
            a.Fertilizer != null ? a.Fertilizer.Name : null,
            a.AppliedDate, a.AppliedQuantity, a.Unit));

    public static IQueryable<FertilizerApplication> BuildSearchQuery(this IQueryable<FertilizerApplication> query, SearchFertilizerApplicationsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(a =>
                (a.AppliedBy != null && EF.Functions.ILike(a.AppliedBy, term))
                || (a.Notes != null && EF.Functions.ILike(a.Notes, term))
                || (a.Fertilizer != null && EF.Functions.ILike(a.Fertilizer.Name, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId)) query = query.Where(a => a.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.FertilizerId)) query = query.Where(a => a.FertilizerId == search.FertilizerId);
        if (!string.IsNullOrEmpty(search.CropPlantingId)) query = query.Where(a => a.CropPlantingId == search.CropPlantingId);
        return query;
    }

    public static IQueryable<FertilizerApplication> ApplySorting(this IQueryable<FertilizerApplication> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.AppliedDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "applieddate" => ascending ? query.OrderBy(a => a.AppliedDate) : query.OrderByDescending(a => a.AppliedDate),
            "appliedquantity" => ascending ? query.OrderBy(a => a.AppliedQuantity) : query.OrderByDescending(a => a.AppliedQuantity),
            _ => query
        };
    }

    public static IQueryable<PesticideApplicationDto> ToPesticideApplicationDto(this IQueryable<PesticideApplication> query)
        => query.Select(a => new PesticideApplicationDto(
            a.Id, a.FarmId, a.Farm != null ? a.Farm.Name : null,
            a.FieldId, a.Field != null ? a.Field.Name : null,
            a.CropPlantingId, a.PesticidePlanId,
            a.CropPlanting != null ? a.CropPlanting.PlantingCode : null,
            a.PesticideId, a.Pesticide != null ? a.Pesticide.Name : null,
            a.AppliedDate, a.AppliedQuantity, a.Unit, a.ApplicationMethod, a.AppliedBy,
            a.Cost, a.SafeHarvestDate, a.Notes, a.Created));

    public static IQueryable<PesticideApplicationSummaryDto> ToPesticideApplicationSummaryDto(this IQueryable<PesticideApplication> query)
        => query.Select(a => new PesticideApplicationSummaryDto(
            a.Id,
            a.CropPlanting != null ? a.CropPlanting.PlantingCode : null,
            a.Pesticide != null ? a.Pesticide.Name : null,
            a.AppliedDate, a.AppliedQuantity, a.Unit));

    public static IQueryable<PesticideApplication> BuildSearchQuery(this IQueryable<PesticideApplication> query, SearchPesticideApplicationsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(a =>
                (a.AppliedBy != null && EF.Functions.ILike(a.AppliedBy, term))
                || (a.Notes != null && EF.Functions.ILike(a.Notes, term))
                || (a.Pesticide != null && EF.Functions.ILike(a.Pesticide.Name, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId)) query = query.Where(a => a.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.PesticideId)) query = query.Where(a => a.PesticideId == search.PesticideId);
        if (!string.IsNullOrEmpty(search.CropPlantingId)) query = query.Where(a => a.CropPlantingId == search.CropPlantingId);
        return query;
    }

    public static IQueryable<PesticideApplication> ApplySorting(this IQueryable<PesticideApplication> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.AppliedDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "applieddate" => ascending ? query.OrderBy(a => a.AppliedDate) : query.OrderByDescending(a => a.AppliedDate),
            "safeharvestdate" => ascending ? query.OrderBy(a => a.SafeHarvestDate) : query.OrderByDescending(a => a.SafeHarvestDate),
            _ => query
        };
    }
}