using InfoManager.Application.Features.SFMS.Production.Commands;
using InfoManager.Application.Features.SFMS.Production.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class ProductionMappings
{
    public static CreateHarvestCommand ToCreateCommand(CreateHarvestRequest request)
        => new()
        {
            CropPlantingId = request.CropPlantingId,
            HarvestDate = request.HarvestDate,
            HarvestMethod = request.HarvestMethod,
            HarvestedArea = request.HarvestedArea,
            TotalQuantity = request.TotalQuantity,
            QuantityUnit = request.QuantityUnit,
            YieldPerHectare = request.YieldPerHectare,
            QualityGrade = request.QualityGrade,
            HarvesterName = request.HarvesterName,
            WeatherCondition = request.WeatherCondition,
            LossPercentage = request.LossPercentage,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        };

    public static UpdateHarvestCommand ToUpdateCommand(UpdateHarvestRequest request, string id)
        => new()
        {
            Id = id,
            CropPlantingId = request.CropPlantingId,
            HarvestDate = request.HarvestDate,
            HarvestMethod = request.HarvestMethod,
            HarvestedArea = request.HarvestedArea,
            TotalQuantity = request.TotalQuantity,
            QuantityUnit = request.QuantityUnit,
            YieldPerHectare = request.YieldPerHectare,
            QualityGrade = request.QualityGrade,
            HarvesterName = request.HarvesterName,
            WeatherCondition = request.WeatherCondition,
            LossPercentage = request.LossPercentage,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        };

    public static SearchHarvestsQuery ToSearchQuery(SearchHarvestsRequest request)
        => new(request.Term, request.CropPlantingId, request.QualityGrade, request.PageNumber, request.PageSize);

    public static CreateProductCommand ToCreateCommand(CreateProductRequest request)
        => new()
        {
            HarvestId = request.HarvestId,
            ProductName = request.ProductName,
            Description = request.Description,
            ProcessingType = request.ProcessingType,
            Quantity = request.Quantity,
            Unit = request.Unit,
            StorageLocation = request.StorageLocation,
            ExpiryDate = request.ExpiryDate,
            CostPerUnit = request.CostPerUnit,
            SellingPrice = request.SellingPrice,
            TotalValue = request.TotalValue,
            Status = request.Status,
            Certification = request.Certification,
            Notes = request.Notes
        };

    public static UpdateProductCommand ToUpdateCommand(UpdateProductRequest request, string id)
        => new()
        {
            Id = id,
            HarvestId = request.HarvestId,
            ProductName = request.ProductName,
            Description = request.Description,
            ProcessingType = request.ProcessingType,
            Quantity = request.Quantity,
            Unit = request.Unit,
            StorageLocation = request.StorageLocation,
            ExpiryDate = request.ExpiryDate,
            CostPerUnit = request.CostPerUnit,
            SellingPrice = request.SellingPrice,
            TotalValue = request.TotalValue,
            Status = request.Status,
            Certification = request.Certification,
            Notes = request.Notes
        };

    public static SearchProductsQuery ToSearchQuery(SearchProductsRequest request)
        => new(request.Term, request.HarvestId, request.Status, request.PageNumber, request.PageSize);

    public static CreateSaleCommand ToCreateCommand(CreateSaleRequest request)
        => new()
        {
            ProductId = request.ProductId,
            SaleDate = request.SaleDate,
            BuyerName = request.BuyerName,
            QuantitySold = request.QuantitySold,
            UnitPrice = request.UnitPrice,
            TotalAmount = request.TotalAmount,
            DiscountPercentage = request.DiscountPercentage,
            NetAmount = request.NetAmount,
            SaleChannel = request.SaleChannel,
            PaymentStatus = request.PaymentStatus,
            PaymentDate = request.PaymentDate,
            InvoiceNumber = request.InvoiceNumber,
            Notes = request.Notes
        };

    public static UpdateSaleCommand ToUpdateCommand(UpdateSaleRequest request, string id)
        => new()
        {
            Id = id,
            ProductId = request.ProductId,
            SaleDate = request.SaleDate,
            BuyerName = request.BuyerName,
            QuantitySold = request.QuantitySold,
            UnitPrice = request.UnitPrice,
            TotalAmount = request.TotalAmount,
            DiscountPercentage = request.DiscountPercentage,
            NetAmount = request.NetAmount,
            SaleChannel = request.SaleChannel,
            PaymentStatus = request.PaymentStatus,
            PaymentDate = request.PaymentDate,
            InvoiceNumber = request.InvoiceNumber,
            Notes = request.Notes
        };

    public static SearchSalesQuery ToSearchQuery(SearchSalesRequest request)
        => new(request.Term, request.ProductId, request.PaymentStatus, request.PageNumber, request.PageSize);

    public static CreateYieldCommand ToCreateCommand(CreateYieldRequest request)
        => new()
        {
            CropPlantingId = request.CropPlantingId,
            HarvestId = request.HarvestId,
            ActualYield = request.ActualYield,
            ExpectedYield = request.ExpectedYield,
            Unit = request.Unit,
            YieldPerHectare = request.YieldPerHectare,
            QualityRating = request.QualityRating,
            WastePercentage = request.WastePercentage,
            YieldVariance = request.YieldVariance,
            GrowthDays = request.GrowthDays,
            ProductionCost = request.ProductionCost,
            Revenue = request.Revenue,
            Profit = request.Profit,
            ROI = request.ROI,
            AffectingFactors = request.AffectingFactors,
            Analysis = request.Analysis,
            Recommendations = request.Recommendations
        };

    public static UpdateYieldCommand ToUpdateCommand(UpdateYieldRequest request, string id)
        => new()
        {
            Id = id,
            CropPlantingId = request.CropPlantingId,
            HarvestId = request.HarvestId,
            ActualYield = request.ActualYield,
            ExpectedYield = request.ExpectedYield,
            Unit = request.Unit,
            YieldPerHectare = request.YieldPerHectare,
            QualityRating = request.QualityRating,
            WastePercentage = request.WastePercentage,
            YieldVariance = request.YieldVariance,
            GrowthDays = request.GrowthDays,
            ProductionCost = request.ProductionCost,
            Revenue = request.Revenue,
            Profit = request.Profit,
            ROI = request.ROI,
            AffectingFactors = request.AffectingFactors,
            Analysis = request.Analysis,
            Recommendations = request.Recommendations
        };

    public static SearchYieldsQuery ToSearchQuery(SearchYieldsRequest request)
        => new(request.Term, request.CropPlantingId, request.HarvestId, request.PageNumber, request.PageSize);
}