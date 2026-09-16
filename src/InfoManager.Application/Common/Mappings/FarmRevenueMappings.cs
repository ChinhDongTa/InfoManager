using InfoManager.Application.Features.SFMS.Economics.Commands;
using InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

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

    public static SearchFarmRevenuesQuery ToSearchQuery(SearchFarmRevenuesRequest request) => new(request.Term,
                                                                                                 request.FarmId,
                                                                                                 request.CropPlantingId,
                                                                                                 request.HarvestId,
                                                                                                 request.SaleId,
                                                                                                 request.PaymentStatus,
                                                                                                 request.StartRevenueDate,
                                                                                                 request.EndRevenueDate,
                                                                                                 request.PageNumber,
                                                                                                 request.PageSize);

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