using InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

namespace InfoManager.Application.Features.SFMS.Issues.Queries;

public static class QueryExtensions
{
    public static IQueryable<DiseaseDto> ToDiseaseDto(this IQueryable<Disease> query)
        => query.Select(d => new DiseaseDto(
            Id: d.Id,
            CommonName: d.CommonName,
            ScientificName: d.ScientificName,
            DiseaseType: d.DiseaseType,
            CausativeOrganism: d.CausativeOrganism,
            AffectedCrops: d.AffectedCrops,
            Symptoms: d.Symptoms,
            FavorableConditions: d.FavorableConditions,
            TransmissionMethod: d.TransmissionMethod,
            PreventionMethods: d.PreventionMethods,
            RecommendedTreatments: d.RecommendedTreatments,
            SeverityLevel: d.SeverityLevel,
            SeverityLevelName: d.SeverityLevel != null ? d.SeverityLevel.Value.ToDisplayName() : null,
            ImageUrl: d.ImageUrl,
            InfestationCount: d.Infestations.Count(),
            Created: d.Created
        ));

    public static IQueryable<DiseaseSummaryDto> ToDiseaseSummaryDto(this IQueryable<Disease> query)
        => query.Select(d => new DiseaseSummaryDto(
            Id: d.Id,
            CommonName: d.CommonName,
            ScientificName: d.ScientificName,
            DiseaseType: d.DiseaseType,
            SeverityLevel: d.SeverityLevel,
            SeverityLevelName: d.SeverityLevel != null ? d.SeverityLevel.Value.ToDisplayName() : null
        ));

    public static IQueryable<Disease> BuildSearchQuery(this IQueryable<Disease> query, SearchDiseasesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(d => EF.Functions.ILike(d.CommonName, term)
                || (d.ScientificName != null && EF.Functions.ILike(d.ScientificName, term))
                || (d.DiseaseType != null && EF.Functions.ILike(d.DiseaseType, term))
                || (d.Symptoms != null && EF.Functions.ILike(d.Symptoms, term)));
        }
        if (!string.IsNullOrEmpty(search.DiseaseType))
            query = query.Where(d => d.DiseaseType == search.DiseaseType);
        if (search.SeverityLevel.HasValue)
            query = query.Where(d => d.SeverityLevel == search.SeverityLevel.Value);
        return query;
    }

    public static IQueryable<Disease> ApplySorting(this IQueryable<Disease> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.CommonName);
        return sortBy.ToLower() switch
        {
            "commonname" => ascending ? query.OrderBy(a => a.CommonName) : query.OrderByDescending(a => a.CommonName),
            "diseasetype" => ascending ? query.OrderBy(a => a.DiseaseType) : query.OrderByDescending(a => a.DiseaseType),
            "severitylevel" => ascending ? query.OrderBy(a => a.SeverityLevel) : query.OrderByDescending(a => a.SeverityLevel),
            _ => query
        };
    }

    public static IQueryable<PestDto> ToPestDto(this IQueryable<Pest> query)
        => query.Select(p => new PestDto(
            Id: p.Id,
            CommonName: p.CommonName,
            ScientificName: p.ScientificName,
            PestType: p.PestType,
            Description: p.Description,
            AffectedCrops: p.AffectedCrops,
            DamageSymptoms: p.DamageSymptoms,
            LifeCycle: p.LifeCycle,
            PreventionMethods: p.PreventionMethods,
            RecommendedPesticides: p.RecommendedPesticides,
            BiologicalControl: p.BiologicalControl,
            SeverityLevel: p.SeverityLevel,
            SeverityLevelName: p.SeverityLevel != null ? p.SeverityLevel.Value.ToDisplayName() : null,
            ImageUrl: p.ImageUrl,
            InfestationCount: p.Infestations.Count(),
            Created: p.Created
        ));

    public static IQueryable<PestSummaryDto> ToPestSummaryDto(this IQueryable<Pest> query)
        => query.Select(p => new PestSummaryDto(
            Id: p.Id,
            CommonName: p.CommonName,
            ScientificName: p.ScientificName,
            PestType: p.PestType,
            SeverityLevel: p.SeverityLevel,
            SeverityLevelName: p.SeverityLevel != null ? p.SeverityLevel.Value.ToDisplayName() : null
        ));

    public static IQueryable<Pest> BuildSearchQuery(this IQueryable<Pest> query, SearchPestsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.CommonName, term)
                || (p.ScientificName != null && EF.Functions.ILike(p.ScientificName, term))
                || (p.PestType != null && EF.Functions.ILike(p.PestType, term))
                || (p.Description != null && EF.Functions.ILike(p.Description, term)));
        }
        if (!string.IsNullOrEmpty(search.PestType))
            query = query.Where(p => p.PestType == search.PestType);
        if (search.SeverityLevel.HasValue)
            query = query.Where(p => p.SeverityLevel == search.SeverityLevel.Value);
        return query;
    }

    public static IQueryable<Pest> ApplySorting(this IQueryable<Pest> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.CommonName);
        return sortBy.ToLower() switch
        {
            "commonname" => ascending ? query.OrderBy(a => a.CommonName) : query.OrderByDescending(a => a.CommonName),
            "pesttype" => ascending ? query.OrderBy(a => a.PestType) : query.OrderByDescending(a => a.PestType),
            "severitylevel" => ascending ? query.OrderBy(a => a.SeverityLevel) : query.OrderByDescending(a => a.SeverityLevel),
            _ => query
        };
    }

    public static IQueryable<InfestationDto> ToInfestationDto(this IQueryable<Infestation> query)
        => query.Select(i => new InfestationDto(
            Id: i.Id,
            CropPlantingId: i.CropPlantingId,
            PlantingCode: i.CropPlanting != null ? i.CropPlanting.PlantingCode : null,
            CropName: i.CropPlanting != null && i.CropPlanting.Crop != null ? i.CropPlanting.Crop.CommonName : null,
            PestId: i.PestId,
            PestName: i.Pest != null ? i.Pest.CommonName : null,
            DiseaseId: i.DiseaseId,
            DiseaseName: i.Disease != null ? i.Disease.CommonName : null,
            InfestationType: i.InfestationType,
            InfestationTypeName: i.InfestationType.ToDisplayName(),
            DetectionDate: i.DetectionDate,
            AffectedArea: i.AffectedArea,
            AffectedPercentage: i.AffectedPercentage,
            SeverityLevel: i.SeverityLevel,
            SeverityLevelName: i.SeverityLevel.ToDisplayName(),
            Status: i.Status,
            StatusName: i.Status.ToDisplayName(),
            TreatmentApplied: i.TreatmentApplied,
            TreatmentDate: i.TreatmentDate,
            ProductUsed: i.ProductUsed,
            TreatmentCost: i.TreatmentCost,
            EffectivenessRating: i.EffectivenessRating,
            ControlledDate: i.ControlledDate,
            YieldLossPercentage: i.YieldLossPercentage,
            EconomicLoss: i.EconomicLoss,
            Notes: i.Notes,
            PhotoUrl: i.PhotoUrl,
            Created: i.Created
        ));

    public static IQueryable<InfestationSummaryDto> ToInfestationSummaryDto(this IQueryable<Infestation> query)
        => query.Select(i => new InfestationSummaryDto(
            Id: i.Id,
            PlantingCode: i.CropPlanting != null ? i.CropPlanting.PlantingCode : null,
            IssueName: i.Pest != null ? i.Pest.CommonName : (i.Disease != null ? i.Disease.CommonName : null),
            InfestationType: i.InfestationType,
            DetectionDate: i.DetectionDate,
            SeverityLevel: i.SeverityLevel,
            Status: i.Status,
            StatusName: i.Status.ToDisplayName()
        ));

    public static IQueryable<Infestation> BuildSearchQuery(this IQueryable<Infestation> query, SearchInfestationsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(i =>
                (i.Notes != null && EF.Functions.ILike(i.Notes, term))
                || (i.TreatmentApplied != null && EF.Functions.ILike(i.TreatmentApplied, term))
                || (i.ProductUsed != null && EF.Functions.ILike(i.ProductUsed, term))
                || (i.Pest != null && EF.Functions.ILike(i.Pest.CommonName, term))
                || (i.Disease != null && EF.Functions.ILike(i.Disease.CommonName, term))
                || (i.CropPlanting != null && EF.Functions.ILike(i.CropPlanting.PlantingCode, term)));
        }
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(i => i.CropPlantingId == search.CropPlantingId);
        if (search.InfestationType.HasValue)
            query = query.Where(i => i.InfestationType == search.InfestationType.Value);
        if (search.Status.HasValue)
            query = query.Where(i => i.Status == search.Status.Value);
        if (search.SeverityLevel.HasValue)
            query = query.Where(i => i.SeverityLevel == search.SeverityLevel.Value);
        return query;
    }

    public static IQueryable<Infestation> ApplySorting(this IQueryable<Infestation> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.DetectionDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "detectiondate" => ascending ? query.OrderBy(a => a.DetectionDate) : query.OrderByDescending(a => a.DetectionDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "severitylevel" => ascending ? query.OrderBy(a => a.SeverityLevel) : query.OrderByDescending(a => a.SeverityLevel),
            "infestationtype" => ascending ? query.OrderBy(a => a.InfestationType) : query.OrderByDescending(a => a.InfestationType),
            _ => query
        };
    }

    public static IQueryable<PestDiseaseLinkDto> ToPestDiseaseLinkDto(this IQueryable<PestDiseaseLink> query)
        => query.Select(l => new PestDiseaseLinkDto(
            Id: l.Id,
            PestId: l.PestId,
            PestName: l.Pest != null ? l.Pest.CommonName : null,
            DiseaseId: l.DiseaseId,
            DiseaseName: l.Disease != null ? l.Disease.CommonName : null,
            RelationshipDescription: l.RelationshipDescription,
            Created: l.Created
        ));

    public static IQueryable<PestDiseaseLinkSummaryDto> ToPestDiseaseLinkSummaryDto(this IQueryable<PestDiseaseLink> query)
        => query.Select(l => new PestDiseaseLinkSummaryDto(
            Id: l.Id,
            PestName: l.Pest != null ? l.Pest.CommonName : null,
            DiseaseName: l.Disease != null ? l.Disease.CommonName : null,
            RelationshipDescription: l.RelationshipDescription
        ));

    public static IQueryable<PestDiseaseLink> BuildSearchQuery(this IQueryable<PestDiseaseLink> query, SearchPestDiseaseLinksQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(l =>
                (l.RelationshipDescription != null && EF.Functions.ILike(l.RelationshipDescription, term))
                || (l.Pest != null && EF.Functions.ILike(l.Pest.CommonName, term))
                || (l.Disease != null && EF.Functions.ILike(l.Disease.CommonName, term)));
        }
        if (!string.IsNullOrEmpty(search.PestId))
            query = query.Where(l => l.PestId == search.PestId);
        if (!string.IsNullOrEmpty(search.DiseaseId))
            query = query.Where(l => l.DiseaseId == search.DiseaseId);
        return query;
    }

    public static IQueryable<PestDiseaseLink> ApplySorting(this IQueryable<PestDiseaseLink> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "pestname" => ascending
                ? query.OrderBy(a => a.Pest != null ? a.Pest.CommonName : null)
                : query.OrderByDescending(a => a.Pest != null ? a.Pest.CommonName : null),
            "diseasename" => ascending
                ? query.OrderBy(a => a.Disease != null ? a.Disease.CommonName : null)
                : query.OrderByDescending(a => a.Disease != null ? a.Disease.CommonName : null),
            _ => query
        };
    }
}