using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdatePayrollRequest(
    string Id,
    decimal? BaseSalary = null,
    decimal? DaysWorked = null,
    decimal? OvertimeHours = null,
    decimal? OvertimeAmount = null,
    decimal? BonusAmount = null,
    decimal? Deductions = null,
    string? DeductionDetails = null,
    decimal? NetAmount = null,
    PayrollStatus? PaymentStatus = null,
    DateTimeOffset? PaymentDate = null,
    string? PaymentMethod = null,
    string? ReferenceNumber = null,
    string? Notes = null
);