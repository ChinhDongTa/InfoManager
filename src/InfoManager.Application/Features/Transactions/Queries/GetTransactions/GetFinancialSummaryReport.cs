using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.Application.Features.Transactions.Queries.GetTransactions;

public record GetFinancialSummaryReport(int Month, int Year) : IRequest<Result<FinancialSummaryReportDto>>;

public class GetFinancialSummaryReportHandler(IApplicationDbContext context) : IRequestHandler<GetFinancialSummaryReport, Result<FinancialSummaryReportDto>>
{
    public async Task<Result<FinancialSummaryReportDto>> Handle(GetFinancialSummaryReport request, CancellationToken ct)
    {
        (int startMonth, int endMonth) = GetStartMonthAndEndMonthOfQuarter(request.Month);
        var dto = await context.Transactions
                .AsNoTracking()
                .GroupBy(_ => 1)
                .Select(g => new FinancialSummaryReportDto
                {
                    TotalIncomeMonth = g.Where(t => t.Created.Year == request.Year && t.Created.Month == request.Month)
                        .Sum(t => t.TransactionType == TransactionType.Income ? t.Amount : 0m),
                    TotalExpenseMonth = g.Where(t => t.Created.Year == request.Year && t.Created.Month == request.Month)
                        .Sum(t => t.TransactionType == TransactionType.Expense ? t.Amount : 0m),
                    TotalIncomeQuarter = g.Where(t => t.Created.Year == request.Year && t.Created.Month >= startMonth && t.Created.Month <= endMonth)
                        .Sum(t => t.TransactionType == TransactionType.Income ? t.Amount : 0m),
                    TotalExpenseQuarter = g.Where(t => t.Created.Year == request.Year && t.Created.Month >= startMonth && t.Created.Month <= endMonth)
                        .Sum(t => t.TransactionType == TransactionType.Expense ? t.Amount : 0m),
                    TotalIncomeYear = g.Where(t => t.Created.Year == request.Year)
                        .Sum(t => t.TransactionType == TransactionType.Income ? t.Amount : 0m),
                    TotalExpenseYear = g.Where(t => t.Created.Year == request.Year)
                        .Sum(t => t.TransactionType == TransactionType.Expense ? t.Amount : 0m),
                })
                .FirstOrDefaultAsync(ct);

        var report = dto ?? new FinancialSummaryReportDto();
        return Result<FinancialSummaryReportDto>.Success(report);
    }

    public static byte GetQuarter(int month) => (byte)((month - 1) / 3 + 1);

    public static (int, int) GetStartMonthAndEndMonthOfQuarter(int month)
    {
        var quarter = GetQuarter(month);
        var startMonth = (quarter - 1) * 3 + 1;
        var endMonth = startMonth + 2;
        return (startMonth, endMonth);
    }
}