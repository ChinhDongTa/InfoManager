namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== JobPosition ========================
public record JobPositionDto(
    string Id,
    string Title,
    string? Description,
    decimal? MinSalary,
    decimal? MaxSalary,
    string? DepartmentId,
    string? DepartmentName,
    string? RequiredQualifications,
    bool IsActive,
    int? NumberOfPositions,
    string? Notes,
    DateTimeOffset Created
);