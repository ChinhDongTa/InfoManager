using InfoManager.Application.Features.SFMS.Planning.Commands;
using InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class HarvestPlanMappings
{
    public static CreateHarvestPlanCommand ToCreateCommand(CreateHarvestPlanRequest request)
    => new()
    {
        CropCycleId = request.CropCycleId,
        PlanName = request.PlanName,
        ExpectedStartDate = request.ExpectedStartDate,
        ExpectedEndDate = request.ExpectedEndDate,
        HarvestMethod = request.HarvestMethod,
        ExpectedYield = request.ExpectedYield,
        YieldUnit = request.YieldUnit,
        LaborRequirement = request.LaborRequirement,
        EquipmentRequired = request.EquipmentRequired,
        PostHarvestProcessing = request.PostHarvestProcessing,
        StorageRequirement = request.StorageRequirement,
        StorageDuration = request.StorageDuration,
        TransportationPlan = request.TransportationPlan,
        ExpectedSaleDate = request.ExpectedSaleDate,
        TargetBuyer = request.TargetBuyer,
        ExpectedSellingPrice = request.ExpectedSellingPrice,
        Status = request.Status,
        RiskAssessment = request.RiskAssessment,
        Notes = request.Notes
    };

    public static SearchHarvestPlansQuery ToSearchQuery(SearchHarvestPlansRequest request)
    => new(request.Term, request.ExpectedDate, request.Status, request.PageNumber, request.PageSize);

    public static UpdateHarvestPlanCommand ToUpdateCommand(UpdateHarvestPlanRequest request, string id)
        => new()
        {
            Id = id,
            CropCycleId = request.CropCycleId,
            PlanName = request.PlanName,
            ExpectedStartDate = request.ExpectedStartDate,
            ExpectedEndDate = request.ExpectedEndDate,
            HarvestMethod = request.HarvestMethod,
            ExpectedYield = request.ExpectedYield,
            YieldUnit = request.YieldUnit,
            LaborRequirement = request.LaborRequirement,
            EquipmentRequired = request.EquipmentRequired,
            PostHarvestProcessing = request.PostHarvestProcessing,
            StorageRequirement = request.StorageRequirement,
            StorageDuration = request.StorageDuration,
            TransportationPlan = request.TransportationPlan,
            ExpectedSaleDate = request.ExpectedSaleDate,
            TargetBuyer = request.TargetBuyer,
            ExpectedSellingPrice = request.ExpectedSellingPrice,
            Status = request.Status,
            RiskAssessment = request.RiskAssessment,
            Notes = request.Notes
        };
}