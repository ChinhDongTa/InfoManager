using InfoManager.Application.Features.SFMS.Economics.Commands;

namespace InfoManager.Application.Common.Mappings;

public static class FarmRevenueMappings
{
    public static CreateFarmRevenueCommand ToCreateCommand(CreateFarmRevenueRequest request)
    => new()
    {
        FarmId = request.FarmId,
        CropPlantingId = request.CropPlantingId,
        HarvestId = request.HarvestId,
        SaleId = request.SaleId,
        Source = request.Source,
        Amount = request.Amount,
        Currency = request.Currency,
        RevenueDate = request.RevenueDate,
        BuyerName = request.BuyerName,
        PaymentStatus = request.PaymentStatus,
        PaymentReceivedDate = request.PaymentReceivedDate,
        Notes = request.Notes
    };

    public static UpdateFarmRevenueCommand ToUpdateCommand(UpdateFarmRevenueRequest request, string id)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            HarvestId = request.HarvestId,
            SaleId = request.SaleId,
            Source = request.Source,
            Amount = request.Amount,
            Currency = request.Currency,
            RevenueDate = request.RevenueDate,
            BuyerName = request.BuyerName,
            PaymentStatus = request.PaymentStatus,
            PaymentReceivedDate = request.PaymentReceivedDate,
            Notes = request.Notes
        };
}