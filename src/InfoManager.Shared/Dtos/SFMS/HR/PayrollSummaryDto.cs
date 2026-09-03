namespace InfoManager.Shared.Dtos.SFMS.HR;

public record PayrollSummaryDto(
    string Id,
    string? EmployeeName,
    DateOnly PeriodStartDate,
    DateOnly PeriodEndDate,
    decimal NetAmount,
    string PaymentStatusName,
    DateTimeOffset? PaymentDate
);