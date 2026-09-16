namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateJobPositionRequest(
    string Id,
    string? Title = null,
    string? Description = null,
    decimal? MinSalary = null,
    decimal? MaxSalary = null,
    string? DepartmentId = null,
    string? RequiredQualifications = null,
    bool? IsActive = null,
    int? NumberOfPositions = null,
    string? Notes = null
);