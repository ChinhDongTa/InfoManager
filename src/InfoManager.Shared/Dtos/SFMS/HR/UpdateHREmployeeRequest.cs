using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateHREmployeeRequest(
    string Id,
    string? FamilyMemberId = null,
    string? DepartmentId = null,
    string? EmployeeNumber = null,
    EmploymentStatus? Status = null,
    DateTimeOffset? HireDate = null,
    DateTimeOffset? TerminationDate = null,
    string? TerminationReason = null,
    decimal? Salary = null,
    SalaryType? SalaryType = null,
    string? BankAccount = null,
    string? EmergencyContactName = null,
    string? EmergencyContactPhone = null,
    string? Notes = null
);
