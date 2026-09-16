namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== EmployeeContract ========================
public record EmployeeContractDto(
    string Id,
    string HREmployeeId,
    string? EmployeeName,
    string? EmployeeNumber,
    string ContractNumber,
    string ContractType,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    SalaryType SalaryType,
    string SalaryTypeName,
    decimal BaseSalary,
    bool IsActive,
    DateTimeOffset Created
);