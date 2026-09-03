namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreatePayrollRequest(
    string HREmployeeId,
    DateOnly PeriodStartDate,
    DateOnly PeriodEndDate,
    decimal BaseSalary,
    decimal DaysWorked,
    decimal? OvertimeHours ,
    decimal? OvertimeAmount ,
    decimal? BonusAmount ,
    decimal? Deductions ,
    string? DeductionDetails ,
    decimal NetAmount ,
    string? PaymentMethod ,
    string? Notes 
);
