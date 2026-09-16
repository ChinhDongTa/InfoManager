using InfoManager.Application.Features.SFMS.Production.Queries.Gets;

namespace InfoManager.Application.Features.SFMS.Production.Queries;

public static class QueryExtensions
{
    //========================================= Harvest ======================================================
    public static IQueryable<HarvestDto> ToHarvestDto(this IQueryable<Harvest> query)
        => query.Select(h => new HarvestDto(
            Id: h.Id,
            CropPlantingId: h.CropPlantingId,
            PlantingCode: h.CropPlanting != null ? h.CropPlanting.PlantingCode : null,
            CropName: h.CropPlanting != null && h.CropPlanting.Crop != null ? h.CropPlanting.Crop.CommonName : null,
            FieldName: h.CropPlanting != null && h.CropPlanting.Field != null ? h.CropPlanting.Field.Name : null,
            HarvestDate: h.HarvestDate,
            HarvestMethod: h.HarvestMethod,
            HarvestedArea: h.HarvestedArea,
            TotalQuantity: h.TotalQuantity,
            QuantityUnit: h.QuantityUnit,
            YieldPerHectare: h.YieldPerHectare,
            QualityGrade: h.QualityGrade,
            HarvesterName: h.HarvesterName,
            WeatherCondition: h.WeatherCondition,
            LossPercentage: h.LossPercentage,
            Notes: h.Notes,
            PhotoUrl: h.PhotoUrl,
            ProductCount: h.Products.Count(),
            Created: h.Created
        ));

    public static IQueryable<HarvestSummaryDto> ToHarvestSummaryDto(this IQueryable<Harvest> query)
        => query.Select(h => new HarvestSummaryDto(
            Id: h.Id,
            PlantingCode: h.CropPlanting != null ? h.CropPlanting.PlantingCode : null,
            CropName: h.CropPlanting != null && h.CropPlanting.Crop != null ? h.CropPlanting.Crop.CommonName : null,
            HarvestDate: h.HarvestDate,
            TotalQuantity: h.TotalQuantity,
            QuantityUnit: h.QuantityUnit,
            YieldPerHectare: h.YieldPerHectare,
            QualityGrade: h.QualityGrade
        ));

    public static IQueryable<Harvest> BuildSearchQuery(this IQueryable<Harvest> query, SearchHarvestsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(h =>
                (h.HarvestMethod != null && EF.Functions.ILike(h.HarvestMethod, term))
                || (h.QualityGrade != null && EF.Functions.ILike(h.QualityGrade, term))
                || (h.HarvesterName != null && EF.Functions.ILike(h.HarvesterName, term))
                || (h.Notes != null && EF.Functions.ILike(h.Notes, term))
                || (h.CropPlanting != null && EF.Functions.ILike(h.CropPlanting.PlantingCode, term)));
        }
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(h => h.CropPlantingId == search.CropPlantingId);
        if (!string.IsNullOrEmpty(search.QualityGrade))
            query = query.Where(h => h.QualityGrade == search.QualityGrade);
        return query;
    }

    public static IQueryable<Harvest> ApplySorting(this IQueryable<Harvest> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.HarvestDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "harvestdate" => ascending ? query.OrderBy(a => a.HarvestDate) : query.OrderByDescending(a => a.HarvestDate),
            "totalquantity" => ascending ? query.OrderBy(a => a.TotalQuantity) : query.OrderByDescending(a => a.TotalQuantity),
            "qualitygrade" => ascending ? query.OrderBy(a => a.QualityGrade) : query.OrderByDescending(a => a.QualityGrade),
            _ => query
        };
    }

    //========================================= Product ======================================================
    public static IQueryable<ProductDto> ToProductDto(this IQueryable<Product> query)
        => query.Select(p => new ProductDto(
            Id: p.Id,
            HarvestId: p.HarvestId,
            HarvestDate: p.Harvest != null ? p.Harvest.HarvestDate : null,
            PlantingCode: p.Harvest != null && p.Harvest.CropPlanting != null ? p.Harvest.CropPlanting.PlantingCode : null,
            ProductName: p.ProductName,
            Description: p.Description,
            ProcessingType: p.ProcessingType,
            Quantity: p.Quantity,
            Unit: p.Unit,
            StorageLocation: p.StorageLocation,
            ExpiryDate: p.ExpiryDate,
            CostPerUnit: p.CostPerUnit,
            SellingPrice: p.SellingPrice,
            TotalValue: p.TotalValue,
            Status: p.Status,
            StatusName: p.Status.ToDisplayName(),
            Certification: p.Certification,
            Notes: p.Notes,
            Created: p.Created
        ));

    public static IQueryable<ProductSummaryDto> ToProductSummaryDto(this IQueryable<Product> query)
        => query.Select(p => new ProductSummaryDto(
            Id: p.Id,
            ProductName: p.ProductName,
            PlantingCode: p.Harvest != null && p.Harvest.CropPlanting != null ? p.Harvest.CropPlanting.PlantingCode : null,
            Quantity: p.Quantity,
            Unit: p.Unit,
            SellingPrice: p.SellingPrice,
            Status: p.Status,
            StatusName: p.Status.ToDisplayName(),
            ExpiryDate: p.ExpiryDate
        ));

    public static IQueryable<Product> BuildSearchQuery(this IQueryable<Product> query, SearchProductsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.ProductName, term)
                || (p.Description != null && EF.Functions.ILike(p.Description, term))
                || (p.StorageLocation != null && EF.Functions.ILike(p.StorageLocation, term))
                || (p.Certification != null && EF.Functions.ILike(p.Certification, term)));
        }
        if (search.Status.HasValue)
            query = query.Where(p => p.Status == search.Status.Value);
        return query;
    }

    public static IQueryable<Product> ApplySorting(this IQueryable<Product> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.ProductName);
        return sortBy.ToLower() switch
        {
            "productname" => ascending ? query.OrderBy(a => a.ProductName) : query.OrderByDescending(a => a.ProductName),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "expirydate" => ascending ? query.OrderBy(a => a.ExpiryDate) : query.OrderByDescending(a => a.ExpiryDate),
            _ => query
        };
    }

    //========================================= Sale ======================================================
    public static IQueryable<SaleDto> ToSaleDto(this IQueryable<Sale> query)
        => query.Select(s => new SaleDto(
            Id: s.Id,
            ProductId: s.ProductId,
            ProductName: s.Product != null ? s.Product.ProductName : null,
            ProductUnit: s.Product != null ? s.Product.Unit : null,
            SaleDate: s.SaleDate,
            BuyerName: s.BuyerName,
            QuantitySold: s.QuantitySold,
            UnitPrice: s.UnitPrice,
            TotalAmount: s.TotalAmount,
            DiscountPercentage: s.DiscountPercentage,
            NetAmount: s.NetAmount,
            SaleChannel: s.SaleChannel,
            PaymentStatus: s.PaymentStatus,
            PaymentStatusName: s.PaymentStatus.ToDisplayName(),
            PaymentDate: s.PaymentDate,
            InvoiceNumber: s.InvoiceNumber,
            Notes: s.Notes,
            Created: s.Created
        ));

    public static IQueryable<SaleSummaryDto> ToSaleSummaryDto(this IQueryable<Sale> query)
        => query.Select(s => new SaleSummaryDto(
            Id: s.Id,
            ProductName: s.Product != null ? s.Product.ProductName : null,
            SaleDate: s.SaleDate,
            BuyerName: s.BuyerName,
            QuantitySold: s.QuantitySold,
            NetAmount: s.NetAmount,
            PaymentStatus: s.PaymentStatus,
            PaymentStatusName: s.PaymentStatus.ToDisplayName()
        ));

    public static IQueryable<Sale> BuildSearchQuery(this IQueryable<Sale> query, SearchSalesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(s => EF.Functions.ILike(s.BuyerName, term)
                || (s.InvoiceNumber != null && EF.Functions.ILike(s.InvoiceNumber, term))
                || (s.SaleChannel != null && EF.Functions.ILike(s.SaleChannel, term))
                || (s.Product != null && EF.Functions.ILike(s.Product.ProductName, term)));
        }
        if (!string.IsNullOrEmpty(search.ProductId))
            query = query.Where(s => s.ProductId == search.ProductId);
        if (search.PaymentStatus.HasValue)
            query = query.Where(s => s.PaymentStatus == search.PaymentStatus.Value);
        return query;
    }

    public static IQueryable<Sale> ApplySorting(this IQueryable<Sale> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.SaleDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "saledate" => ascending ? query.OrderBy(a => a.SaleDate) : query.OrderByDescending(a => a.SaleDate),
            "netamount" => ascending ? query.OrderBy(a => a.NetAmount) : query.OrderByDescending(a => a.NetAmount),
            "paymentstatus" => ascending ? query.OrderBy(a => a.PaymentStatus) : query.OrderByDescending(a => a.PaymentStatus),
            "buyername" => ascending ? query.OrderBy(a => a.BuyerName) : query.OrderByDescending(a => a.BuyerName),
            _ => query
        };
    }

    //========================================= Yield ======================================================
    public static IQueryable<YieldDto> ToYieldDto(this IQueryable<Yield> query)
        => query.Select(y => new YieldDto(
            Id: y.Id,
            CropPlantingId: y.CropPlantingId,
            PlantingCode: y.CropPlanting != null ? y.CropPlanting.PlantingCode : null,
            CropName: y.CropPlanting != null && y.CropPlanting.Crop != null ? y.CropPlanting.Crop.CommonName : null,
            HarvestId: y.HarvestId,
            HarvestDate: y.Harvest != null ? y.Harvest.HarvestDate : null,
            ActualYield: y.ActualYield,
            ExpectedYield: y.ExpectedYield,
            Unit: y.Unit,
            YieldPerHectare: y.YieldPerHectare,
            QualityRating: y.QualityRating,
            WastePercentage: y.WastePercentage,
            YieldVariance: y.YieldVariance,
            GrowthDays: y.GrowthDays,
            ProductionCost: y.ProductionCost,
            Revenue: y.Revenue,
            Profit: y.Profit,
            ROI: y.ROI,
            AffectingFactors: y.AffectingFactors,
            Analysis: y.Analysis,
            Recommendations: y.Recommendations,
            Created: y.Created
        ));

    public static IQueryable<YieldSummaryDto> ToYieldSummaryDto(this IQueryable<Yield> query)
        => query.Select(y => new YieldSummaryDto(
            Id: y.Id,
            PlantingCode: y.CropPlanting != null ? y.CropPlanting.PlantingCode : null,
            CropName: y.CropPlanting != null && y.CropPlanting.Crop != null ? y.CropPlanting.Crop.CommonName : null,
            ActualYield: y.ActualYield,
            ExpectedYield: y.ExpectedYield,
            Unit: y.Unit,
            YieldPerHectare: y.YieldPerHectare,
            YieldVariance: y.YieldVariance,
            Profit: y.Profit
        ));

    public static IQueryable<Yield> BuildSearchQuery(this IQueryable<Yield> query, SearchYieldsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(y =>
                (y.Analysis != null && EF.Functions.ILike(y.Analysis, term))
                || (y.Recommendations != null && EF.Functions.ILike(y.Recommendations, term))
                || (y.AffectingFactors != null && EF.Functions.ILike(y.AffectingFactors, term))
                || (y.CropPlanting != null && EF.Functions.ILike(y.CropPlanting.PlantingCode, term)));
        }
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(y => y.CropPlantingId == search.CropPlantingId);
        return query;
    }

    public static IQueryable<Yield> ApplySorting(this IQueryable<Yield> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "actualyield" => ascending ? query.OrderBy(a => a.ActualYield) : query.OrderByDescending(a => a.ActualYield),
            "yieldperhectare" => ascending ? query.OrderBy(a => a.YieldPerHectare) : query.OrderByDescending(a => a.YieldPerHectare),
            "profit" => ascending ? query.OrderBy(a => a.Profit) : query.OrderByDescending(a => a.Profit),
            _ => query
        };
    }
}