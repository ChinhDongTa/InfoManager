namespace InfoManager.Shared.Dtos.Transactions;

public record FinancialSummaryReportDto
{
    public decimal TotalIncomeMonth { get; init; }
    public decimal TotalExpenseMonth { get; init; }
    public decimal BalanceMonth => TotalIncomeMonth - TotalExpenseMonth;
    public decimal TotalIncomeQuarter { get; init; }
    public decimal TotalExpenseQuarter { get; init; }
    public decimal BalanceQuarter => TotalIncomeQuarter - TotalExpenseQuarter;
    public decimal TotalIncomeYear { get; init; }
    public decimal TotalExpenseYear { get; init; }
    public decimal BalanceYear => TotalIncomeYear - TotalExpenseYear;
}