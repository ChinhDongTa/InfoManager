using InfoManager.Application.Features.SFMS.Resources.Commands;
using InfoManager.Application.Features.SFMS.Resources.Queries.Gets;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Common.Mappings;

public static class ResourcesMappings
{
    public static CreateFertilizerCommand ToCreateCommand(CreateFertilizerRequest request)
        => new()
        {
            Name = request.Name,
            FertilizerType = request.FertilizerType,
            NitrogenPercent = request.NitrogenPercent,
            PhosphorusPercent = request.PhosphorusPercent,
            PotassiumPercent = request.PotassiumPercent,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            IsActive = request.IsActive,
            Notes = request.Notes
        };

    public static UpdateFertilizerCommand ToUpdateCommand(UpdateFertilizerRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            FertilizerType = request.FertilizerType,
            NitrogenPercent = request.NitrogenPercent,
            PhosphorusPercent = request.PhosphorusPercent,
            PotassiumPercent = request.PotassiumPercent,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            IsActive = request.IsActive,
            Notes = request.Notes
        };

    public static SearchFertilizersQuery ToSearchQuery(SearchFertilizersRequest request)
        => new(request.Term, request.FertilizerType, request.IsActive, request.PageNumber, request.PageSize);

    public static CreatePesticideCommand ToCreateCommand(CreatePesticideRequest request)
        => new()
        {
            Name = request.Name,
            ActiveIngredient = request.ActiveIngredient,
            PesticideType = request.PesticideType,
            ToxicityLevel = request.ToxicityLevel,
            PreHarvestIntervalDays = request.PreHarvestIntervalDays,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            RegistrationNumber = request.RegistrationNumber,
            IsActive = request.IsActive,
            Notes = request.Notes
        };

    public static UpdatePesticideCommand ToUpdateCommand(UpdatePesticideRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            ActiveIngredient = request.ActiveIngredient,
            PesticideType = request.PesticideType,
            ToxicityLevel = request.ToxicityLevel,
            PreHarvestIntervalDays = request.PreHarvestIntervalDays,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            RegistrationNumber = request.RegistrationNumber,
            IsActive = request.IsActive,
            Notes = request.Notes
        };

    public static SearchPesticidesQuery ToSearchQuery(SearchPesticidesRequest request)
        => new(request.Term, request.PesticideType, request.IsActive, request.PageNumber, request.PageSize);

    public static CreateFertilizationPlanCommand ToCreateCommand(CreateFertilizationPlanRequest request)
        => new()
        {
            FarmId = request.FarmId,
            FertilizerId = request.FertilizerId,
            PlanName = request.PlanName,
            PlannedDate = request.PlannedDate,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            DaysAfterPlanting = request.DaysAfterPlanting,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status,
            Notes = request.Notes
        };

    public static UpdateFertilizationPlanCommand ToUpdateCommand(UpdateFertilizationPlanRequest request, string id)
        => new()
        {
            Id = id,
            FertilizerId = request.FertilizerId,
            PlanName = request.PlanName,
            PlannedDate = request.PlannedDate,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            DaysAfterPlanting = request.DaysAfterPlanting,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status,
            Notes = request.Notes
        };

    public static SearchFertilizationPlansQuery ToSearchQuery(SearchFertilizationPlansRequest request)
        => new(request.Term, request.FarmId, request.FertilizerId, request.Status, request.PageNumber, request.PageSize);

    public static CreatePesticidePlanCommand ToCreateCommand(CreatePesticidePlanRequest request)
        => new()
        {
            FarmId = request.FarmId,
            PesticideId = request.PesticideId,
            PlanName = request.PlanName,
            PlannedDate = request.PlannedDate,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            Target = request.Target,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status,
            Notes = request.Notes
        };

    public static UpdatePesticidePlanCommand ToUpdateCommand(UpdatePesticidePlanRequest request, string id)
        => new()
        {
            Id = id,
            PesticideId = request.PesticideId,
            PlanName = request.PlanName,
            Target = request.Target,
            PlannedDate = request.PlannedDate,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status,
            Notes = request.Notes
        };

    public static SearchPesticidePlansQuery ToSearchQuery(SearchPesticidePlansRequest request)
        => new(request.Term, request.FarmId, request.PesticideId, request.Status, request.PageNumber, request.PageSize);

    public static CreateFertilizerApplicationCommand ToCreateCommand(CreateFertilizerApplicationRequest request)
        => new()
        {
            FarmId = request.FarmId,
            FertilizerId = request.FertilizerId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            FertilizationPlanId = request.FertilizationPlanId,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            Notes = request.Notes
        };

    public static UpdateFertilizerApplicationCommand ToUpdateCommand(UpdateFertilizerApplicationRequest request, string id)
        => new()
        {
            Id = id,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            FertilizationPlanId = request.FertilizationPlanId,
            FertilizerId = request.FertilizerId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            Notes = request.Notes
        };

    public static SearchFertilizerApplicationsQuery ToSearchQuery(SearchFertilizerApplicationsRequest request)
        => new(request.Term, request.FarmId, request.FertilizerId, request.CropPlantingId, request.PageNumber, request.PageSize);

    public static CreatePesticideApplicationCommand ToCreateCommand(CreatePesticideApplicationRequest request)
        => new()
        {
            FarmId = request.FarmId,
            PesticideId = request.PesticideId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            PesticidePlanId = request.PesticidePlanId,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            Notes = request.Notes
        };

    public static UpdatePesticideApplicationCommand ToUpdateCommand(UpdatePesticideApplicationRequest request, string id)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            PesticideId = request.PesticideId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            PesticidePlanId = request.PesticidePlanId,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            Notes = request.Notes
        };

    public static SearchPesticideApplicationsQuery ToSearchQuery(SearchPesticideApplicationsRequest request)
        => new(request.Term, request.FarmId, request.PesticideId, request.CropPlantingId, request.PageNumber, request.PageSize);
}