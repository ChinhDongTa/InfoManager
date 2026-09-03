namespace InfoManager.Shared.Dtos.SFMS.HR;

public record HREmployeeSummaryDto(
    string Id,
    string? EmployeeNumber,
    string? FullName,
    string? DepartmentName,
    string? JobPositionTitle,
    string StatusName,
    decimal Salary,
    string SalaryTypeName
);