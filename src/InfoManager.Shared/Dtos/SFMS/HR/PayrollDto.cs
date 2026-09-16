namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== Payroll ========================
public record PayrollDto(
    string Id,
    string HREmployeeId,
    string? EmployeeName,
    string? EmployeeNumber,
    DateOnly PeriodStartDate,
    DateOnly PeriodEndDate,
    decimal BaseSalary,
    decimal DaysWorked,
    decimal? OvertimeHours,
    decimal? OvertimeAmount,
    decimal? BonusAmount,
    decimal? Deductions,
    string? DeductionDetails,
    decimal NetAmount,
    PayrollStatus PayrollStatus,
    string PaymentStatusName,
    DateTimeOffset? PaymentDate,
    string? PaymentMethod,
    string? ReferenceNumber,
    string? Notes,
    DateTimeOffset Created
);