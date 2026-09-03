using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateHREmployeeRequest(
    string? FamilyMemberId,
    string FarmId,
    string UserId,
    string? DepartmentId,
    string? EmployeeNumber,
    EmploymentStatus Status = EmploymentStatus.Active,
    DateTimeOffset? HireDate = null,
    decimal Salary = 0,
    SalaryType SalaryType = SalaryType.Monthly,
    string? BankAccount = null,
    string? EmergencyContactName = null,
    string? EmergencyContactPhone = null,
    string? Notes = null
);
