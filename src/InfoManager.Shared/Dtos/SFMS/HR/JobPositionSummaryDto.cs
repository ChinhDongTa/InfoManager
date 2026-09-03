namespace InfoManager.Shared.Dtos.SFMS.HR;

public record JobPositionSummaryDto(
    string Id,
    string Title,
    string? DepartmentName,
    decimal? MinSalary,
    decimal? MaxSalary,
    bool IsActive,
    int? NumberOfPositions
);
