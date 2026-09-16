using InfoManager.Application.Features.SFMS.Issues.Commands;
using InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class IssuesMappings
{
    public static CreateDiseaseCommand ToCreateCommand(CreateDiseaseRequest request)
        => new()
        {
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            DiseaseType = request.DiseaseType,
            CausativeOrganism = request.CausativeOrganism,
            AffectedCrops = request.AffectedCrops,
            Symptoms = request.Symptoms,
            FavorableConditions = request.FavorableConditions,
            TransmissionMethod = request.TransmissionMethod,
            PreventionMethods = request.PreventionMethods,
            RecommendedTreatments = request.RecommendedTreatments,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        };

    public static UpdateDiseaseCommand ToUpdateCommand(UpdateDiseaseRequest request, string id)
        => new()
        {
            Id = id,
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            DiseaseType = request.DiseaseType,
            CausativeOrganism = request.CausativeOrganism,
            AffectedCrops = request.AffectedCrops,
            Symptoms = request.Symptoms,
            FavorableConditions = request.FavorableConditions,
            TransmissionMethod = request.TransmissionMethod,
            PreventionMethods = request.PreventionMethods,
            RecommendedTreatments = request.RecommendedTreatments,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        };

    public static SearchDiseasesQuery ToSearchQuery(SearchDiseasesRequest request)
        => new(request.Term, request.DiseaseType, request.SeverityLevel, request.PageNumber, request.PageSize);

    public static CreatePestCommand ToCreateCommand(CreatePestRequest request)
        => new()
        {
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            PestType = request.PestType,
            Description = request.Description,
            AffectedCrops = request.AffectedCrops,
            DamageSymptoms = request.DamageSymptoms,
            LifeCycle = request.LifeCycle,
            PreventionMethods = request.PreventionMethods,
            RecommendedPesticides = request.RecommendedPesticides,
            BiologicalControl = request.BiologicalControl,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        };

    public static UpdatePestCommand ToUpdateCommand(UpdatePestRequest request, string id)
        => new()
        {
            Id = id,
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            PestType = request.PestType,
            Description = request.Description,
            AffectedCrops = request.AffectedCrops,
            DamageSymptoms = request.DamageSymptoms,
            LifeCycle = request.LifeCycle,
            PreventionMethods = request.PreventionMethods,
            RecommendedPesticides = request.RecommendedPesticides,
            BiologicalControl = request.BiologicalControl,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        };

    public static SearchPestsQuery ToSearchQuery(SearchPestsRequest request)
        => new(request.Term, request.PestType, request.SeverityLevel, request.PageNumber, request.PageSize);

    public static CreateInfestationCommand ToCreateCommand(CreateInfestationRequest request)
        => new()
        {
            CropPlantingId = request.CropPlantingId,
            InfestationType = request.InfestationType,
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            DetectionDate = request.DetectionDate,
            AffectedArea = request.AffectedArea,
            AffectedPercentage = request.AffectedPercentage,
            SeverityLevel = request.SeverityLevel,
            Status = request.Status,
            TreatmentApplied = request.TreatmentApplied,
            TreatmentDate = request.TreatmentDate,
            ProductUsed = request.ProductUsed,
            TreatmentCost = request.TreatmentCost,
            EffectivenessRating = request.EffectivenessRating,
            ControlledDate = request.ControlledDate,
            YieldLossPercentage = request.YieldLossPercentage,
            EconomicLoss = request.EconomicLoss,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        };

    public static UpdateInfestationCommand ToUpdateCommand(UpdateInfestationRequest request, string id)
        => new()
        {
            Id = id,
            CropPlantingId = request.CropPlantingId,
            InfestationType = request.InfestationType,
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            DetectionDate = request.DetectionDate,
            AffectedArea = request.AffectedArea,
            AffectedPercentage = request.AffectedPercentage,
            SeverityLevel = request.SeverityLevel,
            Status = request.Status,
            TreatmentApplied = request.TreatmentApplied,
            TreatmentDate = request.TreatmentDate,
            ProductUsed = request.ProductUsed,
            TreatmentCost = request.TreatmentCost,
            EffectivenessRating = request.EffectivenessRating,
            ControlledDate = request.ControlledDate,
            YieldLossPercentage = request.YieldLossPercentage,
            EconomicLoss = request.EconomicLoss,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        };

    public static SearchInfestationsQuery ToSearchQuery(SearchInfestationsRequest request)
        => new(request.Term, request.CropPlantingId, request.InfestationType, request.Status, request.SeverityLevel, request.PageNumber, request.PageSize);

    public static CreatePestDiseaseLinkCommand ToCreateCommand(CreatePestDiseaseLinkRequest request)
        => new()
        {
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            RelationshipDescription = request.RelationshipDescription
        };

    public static UpdatePestDiseaseLinkCommand ToUpdateCommand(UpdatePestDiseaseLinkRequest request, string id)
        => new()
        {
            Id = id,
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            RelationshipDescription = request.RelationshipDescription
        };

    public static SearchPestDiseaseLinksQuery ToSearchQuery(SearchPestDiseaseLinksRequest request)
        => new(request.Term, request.PestId, request.DiseaseId, request.PageNumber, request.PageSize);
}