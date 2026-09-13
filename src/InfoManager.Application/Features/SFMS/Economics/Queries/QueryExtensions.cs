using InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

namespace InfoManager.Application.Features.SFMS.Economics.Queries;

internal static class QueryExtensions
{
    //=================================== CostAnalysis ===================================================
    public static IQueryable<CostAnalysisDto> ToCostAnalysisDto(this IQueryable<CostAnalysis> query)
    {
        return query.Select(c => new CostAnalysisDto(
            Id: c.Id,
            FarmId: c.FarmId,
            FarmName: c.Farm != null ? c.Farm.Name : null,
            CropPlantingId: c.CropPlantingId,
            CropPlantingName: c.CropPlanting != null ? c.CropPlanting.PlantingCode : null,
            AnalysisDate: c.AnalysisDate,
            FromDate: c.FromDate,
            ToDate: c.ToDate,
            TotalCost: c.TotalCost,
            CostBreakdown: c.CostBreakdown,
            CostPerHectare: c.CostPerHectare,
            CostPerUnit: c.CostPerUnit,
            TotalRevenue: c.TotalRevenue,
            GrossProfit: c.GrossProfit,
            NetProfit: c.NetProfit,
            ProfitMargin: c.ProfitMargin,
            ROI: c.ROI,
            BreakEvenAnalysis: c.BreakEvenAnalysis,
            EfficiencyRating: c.EfficiencyRating,
            Recommendations: c.Recommendations,
            PreparedBy: c.PreparedBy,
            Created: c.Created
        ));
    }

    public static IQueryable<CostAnalysisSummaryDto> ToCostAnalysisSummaryDto(this IQueryable<CostAnalysis> query)
    {
        return query.Select(c => new CostAnalysisSummaryDto(
            Id: c.Id,
            FarmName: c.Farm != null ? c.Farm.Name : null,
            CropPlantingName: c.CropPlanting != null ? c.CropPlanting.PlantingCode : null,
            AnalysisDate: c.AnalysisDate,
            FromDate: c.FromDate,
            ToDate: c.ToDate,
            TotalCost: c.TotalCost,
            TotalRevenue: c.TotalRevenue,
            NetProfit: c.NetProfit,
            ProfitMargin: c.ProfitMargin,
            ROI: c.ROI
        ));
    }

    public static IQueryable<CostAnalysis> BuildSearchQuery(this IQueryable<CostAnalysis> query, SearchCostAnalysesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(c =>
                (c.CostBreakdown != null && EF.Functions.ILike(c.CostBreakdown, term))
                || (c.BreakEvenAnalysis != null && EF.Functions.ILike(c.BreakEvenAnalysis, term))
                || (c.Recommendations != null && EF.Functions.ILike(c.Recommendations, term))
                || (c.PreparedBy != null && EF.Functions.ILike(c.PreparedBy, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(c => c.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(c => c.CropPlantingId == search.CropPlantingId);
        if (search.StartAnalysisDate.HasValue)
            query = query.Where(c => c.AnalysisDate >= search.StartAnalysisDate.Value);
        if (search.EndAnalysisDate.HasValue)
            query = query.Where(c => c.AnalysisDate <= search.EndAnalysisDate.Value);
        if (search.StartFromDate.HasValue)
            query = query.Where(c => c.FromDate >= search.StartFromDate.Value);
        if (search.EndToDate.HasValue)
            query = query.Where(c => c.ToDate <= search.EndToDate.Value);
        return query;
    }

    /// <summary>
    /// sortBy: analysisdate, totalcost, totalrevenue, netprofit, roi
    /// </summary>
    public static IQueryable<CostAnalysis> ApplySorting(this IQueryable<CostAnalysis> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.AnalysisDate)
                .ThenByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "analysisdate" => ascending ? query.OrderBy(a => a.AnalysisDate) : query.OrderByDescending(a => a.AnalysisDate),
            "totalcost" => ascending ? query.OrderBy(a => a.TotalCost) : query.OrderByDescending(a => a.TotalCost),
            "totalrevenue" => ascending ? query.OrderBy(a => a.TotalRevenue) : query.OrderByDescending(a => a.TotalRevenue),
            "netprofit" => ascending ? query.OrderBy(a => a.NetProfit) : query.OrderByDescending(a => a.NetProfit),
            "roi" => ascending ? query.OrderBy(a => a.ROI) : query.OrderByDescending(a => a.ROI),
            _ => query
        };
    }

    //=================================== FarmExpense ====================================================
    public static IQueryable<FarmExpenseDto> ToFarmExpenseDto(this IQueryable<FarmExpense> query)
    {
        return query.Select(e => new FarmExpenseDto(
            Id: e.Id,
            FarmId: e.FarmId,
            FarmName: e.Farm != null ? e.Farm.Name : null,
            CropPlantingId: e.CropPlantingId,
            CropPlantingName: e.CropPlanting != null ? e.CropPlanting.PlantingCode : null,
            ExpenseType: e.ExpenseType,
            ExpenseTypeName: e.ExpenseType.ToDisplayName(),
            Description: e.Description,
            Amount: e.Amount,
            Category: e.Category,
            ExpenseDate: e.ExpenseDate,
            Vendor: e.Vendor,
            InvoiceNumber: e.InvoiceNumber,
            PaymentMethod: e.PaymentMethod,
            PaymentStatus: e.PaymentStatus,
            PaymentStatusName: e.PaymentStatus.ToDisplayName(),
            ApprovalStatus: e.ApprovalStatus,
            ApprovalStatusName: e.ApprovalStatus.ToDisplayName(),
            ApprovedBy: e.ApprovedBy,
            AttachmentUrl: e.AttachmentUrl,
            Notes: e.Notes,
            Created: e.Created
        ));
    }

    public static IQueryable<FarmExpenseSummaryDto> ToFarmExpenseSummaryDto(this IQueryable<FarmExpense> query)
    {
        return query.Select(e => new FarmExpenseSummaryDto(
            Id: e.Id,
            FarmName: e.Farm != null ? e.Farm.Name : null,
            CropPlantingName: e.CropPlanting != null ? e.CropPlanting.PlantingCode : null,
            ExpenseTypeName: e.ExpenseType.ToDisplayName(),
            Description: e.Description,
            Amount: e.Amount,
            ExpenseDate: e.ExpenseDate,
            PaymentStatusName: e.PaymentStatus.ToDisplayName(),
            ApprovalStatusName: e.ApprovalStatus.ToDisplayName()
        ));
    }

    public static IQueryable<FarmExpense> BuildSearchQuery(this IQueryable<FarmExpense> query, SearchFarmExpensesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(e => EF.Functions.ILike(e.Description, term)
                || (e.Category != null && EF.Functions.ILike(e.Category, term))
                || (e.Vendor != null && EF.Functions.ILike(e.Vendor, term))
                || (e.InvoiceNumber != null && EF.Functions.ILike(e.InvoiceNumber, term))
                || (e.PaymentMethod != null && EF.Functions.ILike(e.PaymentMethod, term))
                || (e.ApprovedBy != null && EF.Functions.ILike(e.ApprovedBy, term))
                || (e.Notes != null && EF.Functions.ILike(e.Notes, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(e => e.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(e => e.CropPlantingId == search.CropPlantingId);
        if (search.ExpenseType.HasValue)
            query = query.Where(e => e.ExpenseType == search.ExpenseType.Value);
        if (search.PaymentStatus.HasValue)
            query = query.Where(e => e.PaymentStatus == search.PaymentStatus.Value);
        if (search.ApprovalStatus.HasValue)
            query = query.Where(e => e.ApprovalStatus == search.ApprovalStatus.Value);
        if (search.StartExpenseDate.HasValue)
            query = query.Where(e => e.ExpenseDate >= search.StartExpenseDate.Value);
        if (search.EndExpenseDate.HasValue)
            query = query.Where(e => e.ExpenseDate <= search.EndExpenseDate.Value);
        return query;
    }

    /// <summary>
    /// sortBy: expensedate, amount, expensetype, paymentstatus
    /// </summary>
    public static IQueryable<FarmExpense> ApplySorting(this IQueryable<FarmExpense> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.ExpenseDate)
                .ThenByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "expensedate" => ascending ? query.OrderBy(a => a.ExpenseDate) : query.OrderByDescending(a => a.ExpenseDate),
            "amount" => ascending ? query.OrderBy(a => a.Amount) : query.OrderByDescending(a => a.Amount),
            "expensetype" => ascending ? query.OrderBy(a => a.ExpenseType) : query.OrderByDescending(a => a.ExpenseType),
            "paymentstatus" => ascending ? query.OrderBy(a => a.PaymentStatus) : query.OrderByDescending(a => a.PaymentStatus),
            _ => query
        };
    }

    //=================================== FarmFinancialSummary ===========================================
    public static IQueryable<FarmFinancialSummaryDto> ToFarmFinancialSummaryDto(this IQueryable<FarmFinancialSummary> query)
    {
        return query.Select(s => new FarmFinancialSummaryDto(
            Id: s.Id,
            FarmId: s.FarmId,
            FarmName: s.Farm != null ? s.Farm.Name : null,
            Year: s.Year,
            Month: s.Month,
            TotalExpenses: s.TotalExpenses,
            TotalRevenue: s.TotalRevenue,
            Profit: s.Profit,
            CropCycleCount: s.CropCycleCount,
            TotalAreaCultivated: s.TotalAreaCultivated,
            AverageYieldPerHectare: s.AverageYieldPerHectare,
            AverageCostPerHectare: s.AverageCostPerHectare,
            AverageRevenuePerHectare: s.AverageRevenuePerHectare,
            HealthScore: s.HealthScore,
            KPIs: s.KPIs,
            Notes: s.Notes,
            Created: s.Created
        ));
    }

    public static IQueryable<FarmFinancialSummarySummaryDto> ToFarmFinancialSummarySummaryDto(this IQueryable<FarmFinancialSummary> query)
    {
        return query.Select(s => new FarmFinancialSummarySummaryDto(
            Id: s.Id,
            FarmName: s.Farm != null ? s.Farm.Name : null,
            Year: s.Year,
            Month: s.Month,
            TotalExpenses: s.TotalExpenses,
            TotalRevenue: s.TotalRevenue,
            Profit: s.Profit,
            HealthScore: s.HealthScore
        ));
    }

    public static IQueryable<FarmFinancialSummary> BuildSearchQuery(this IQueryable<FarmFinancialSummary> query, SearchFarmFinancialSummariesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(s =>
                (s.KPIs != null && EF.Functions.ILike(s.KPIs, term))
                || (s.Notes != null && EF.Functions.ILike(s.Notes, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(s => s.FarmId == search.FarmId);
        if (search.Year.HasValue)
            query = query.Where(s => s.Year == search.Year.Value);
        if (search.Month.HasValue)
            query = query.Where(s => s.Month == search.Month.Value);
        return query;
    }

    /// <summary>
    /// sortBy: year, month, profit, healthscore
    /// </summary>
    public static IQueryable<FarmFinancialSummary> ApplySorting(this IQueryable<FarmFinancialSummary> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Year)
                .ThenByDescending(a => a.Month)
                .ThenByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "year" => ascending ? query.OrderBy(a => a.Year) : query.OrderByDescending(a => a.Year),
            "month" => ascending ? query.OrderBy(a => a.Month) : query.OrderByDescending(a => a.Month),
            "profit" => ascending ? query.OrderBy(a => a.Profit) : query.OrderByDescending(a => a.Profit),
            "healthscore" => ascending ? query.OrderBy(a => a.HealthScore) : query.OrderByDescending(a => a.HealthScore),
            _ => query
        };
    }

    //=================================== FarmRevenue ====================================================
    public static IQueryable<FarmRevenueDto> ToFarmRevenueDto(this IQueryable<FarmRevenue> query)
    {
        return query.Select(r => new FarmRevenueDto(
            Id: r.Id,
            FarmId: r.FarmId,
            FarmName: r.Farm != null ? r.Farm.Name : null,
            CropPlantingId: r.CropPlantingId,
            CropPlantingName: r.CropPlanting != null ? r.CropPlanting.PlantingCode : null,
            HarvestId: r.HarvestId,
            HarvestName: r.Harvest != null ? r.Harvest.HarvestMethod : null,
            SaleId: r.SaleId,
            SaleName: r.Sale != null ? (r.Sale.InvoiceNumber ?? r.Sale.BuyerName) : null,
            Source: r.Source,
            Amount: r.Amount,
            Currency: r.Currency,
            RevenueDate: r.RevenueDate,
            BuyerName: r.BuyerName,
            PaymentStatus: r.PaymentStatus,
            PaymentStatusName: r.PaymentStatus.ToDisplayName(),
            PaymentReceivedDate: r.PaymentReceivedDate,
            Notes: r.Notes,
            Created: r.Created
        ));
    }

    public static IQueryable<FarmRevenueSummaryDto> ToFarmRevenueSummaryDto(this IQueryable<FarmRevenue> query)
    {
        return query.Select(r => new FarmRevenueSummaryDto(
            Id: r.Id,
            FarmName: r.Farm != null ? r.Farm.Name : null,
            Source: r.Source,
            Amount: r.Amount,
            Currency: r.Currency,
            RevenueDate: r.RevenueDate,
            BuyerName: r.BuyerName,
            PaymentStatusName: r.PaymentStatus.ToDisplayName()
        ));
    }

    public static IQueryable<FarmRevenue> BuildSearchQuery(this IQueryable<FarmRevenue> query, SearchFarmRevenuesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(r => EF.Functions.ILike(r.Source, term)
                || (r.BuyerName != null && EF.Functions.ILike(r.BuyerName, term))
                || (r.Currency != null && EF.Functions.ILike(r.Currency, term))
                || (r.Notes != null && EF.Functions.ILike(r.Notes, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(r => r.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.CropPlantingId))
            query = query.Where(r => r.CropPlantingId == search.CropPlantingId);
        if (!string.IsNullOrEmpty(search.HarvestId))
            query = query.Where(r => r.HarvestId == search.HarvestId);
        if (!string.IsNullOrEmpty(search.SaleId))
            query = query.Where(r => r.SaleId == search.SaleId);
        if (search.PaymentStatus.HasValue)
            query = query.Where(r => r.PaymentStatus == search.PaymentStatus.Value);
        if (search.StartRevenueDate.HasValue)
            query = query.Where(r => r.RevenueDate >= search.StartRevenueDate.Value);
        if (search.EndRevenueDate.HasValue)
            query = query.Where(r => r.RevenueDate <= search.EndRevenueDate.Value);
        return query;
    }

    /// <summary>
    /// sortBy: revenuedate, amount, paymentstatus, source
    /// </summary>
    public static IQueryable<FarmRevenue> ApplySorting(this IQueryable<FarmRevenue> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.RevenueDate)
                .ThenByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "revenuedate" => ascending ? query.OrderBy(a => a.RevenueDate) : query.OrderByDescending(a => a.RevenueDate),
            "amount" => ascending ? query.OrderBy(a => a.Amount) : query.OrderByDescending(a => a.Amount),
            "paymentstatus" => ascending ? query.OrderBy(a => a.PaymentStatus) : query.OrderByDescending(a => a.PaymentStatus),
            "source" => ascending ? query.OrderBy(a => a.Source) : query.OrderByDescending(a => a.Source),
            _ => query
        };
    }
}