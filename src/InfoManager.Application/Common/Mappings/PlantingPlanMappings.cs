using InfoManager.Application.Features.SFMS.Planning.Commands;
using InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class PlantingPlanMappings
{
    public static CreatePlantingPlanCommand ToCreateCommand(CreatePlantingPlanRequest request)
    => new()
    {
        CropCycleId = request.CropCycleId,
        PlanName = request.PlanName,
        FieldAllocation = request.FieldAllocation,
        PlantingMethod = request.PlantingMethod,
        SeedQuantityRequired = request.SeedQuantityRequired,
        SeedSource = request.SeedSource,
        SeedbedPreparation = request.SeedbedPreparation,
        ExpectedGerminationRate = request.ExpectedGerminationRate,
        IrrigationPlan = request.IrrigationPlan,
        FertilizationPlan = request.FertilizationPlan,
        LaborRequirement = request.LaborRequirement,
        EquipmentRequired = request.EquipmentRequired,
        Status = request.Status,
        Notes = request.Notes
    };

    public static SearchPlantingPlansQuery ToSearchQuery(SearchPlantingPlansRequest request)
    => new(request.Term, request.Status, request.PageNumber, request.PageSize);

    public static UpdatePlantingPlanCommand ToUpdateCommand(UpdatePlantingPlanRequest request, string id)
        => new()
        {
            Id = id,
            CropCycleId = request.CropCycleId,
            PlanName = request.PlanName,
            FieldAllocation = request.FieldAllocation,
            PlantingMethod = request.PlantingMethod,
            SeedQuantityRequired = request.SeedQuantityRequired,
            SeedSource = request.SeedSource,
            SeedbedPreparation = request.SeedbedPreparation,
            ExpectedGerminationRate = request.ExpectedGerminationRate,
            IrrigationPlan = request.IrrigationPlan,
            FertilizationPlan = request.FertilizationPlan,
            LaborRequirement = request.LaborRequirement,
            EquipmentRequired = request.EquipmentRequired,
            Status = request.Status,
            Notes = request.Notes
        };
}