namespace InfoManager.Shared.Dtos.SFMS.HR;

public record DepartmentSummaryDto(
    string Id,
    string Name,
    string? ParentName,
    int EmployeeCount,
    int JobPositionCount
);
