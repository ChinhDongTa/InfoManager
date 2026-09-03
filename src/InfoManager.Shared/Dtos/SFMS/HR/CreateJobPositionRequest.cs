namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateJobPositionRequest(
    string Title,
    string? Description,
    decimal? MinSalary,
    decimal? MaxSalary,
    string? DepartmentId,
    string? RequiredQualifications,
    bool IsActive,
    int? NumberOfPositions ,
    string? Notes
);
