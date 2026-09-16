namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== HREmployee ========================
public record HREmployeeDto(
    string Id,
    string? FamilyMemberId,
    string? FamilyMemberName,
    string FarmId,
    string? FarmName,
    string UserId,
    string? UserName,
    string? FullName,
    string? Email,
    string? Phone,
    string? DepartmentId,
    string? DepartmentName,
    string? EmployeeNumber,
    EmploymentStatus Status,
    string StatusName,
    DateTimeOffset? HireDate,
    DateTimeOffset? TerminationDate,
    string? TerminationReason,
    decimal Salary,
    SalaryType SalaryType,
    string SalaryTypeName,
    string? BankAccount,
    string? EmergencyContactName,
    string? EmergencyContactPhone,
    string? Notes,
    string? CurrentJobAssignmentId,
    string? CurrentJobPositionTitle,
    DateTimeOffset Created
);