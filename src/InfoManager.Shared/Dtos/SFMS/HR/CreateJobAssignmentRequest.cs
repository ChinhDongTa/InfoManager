namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateJobAssignmentRequest(
    string HREmployeeId,
    string JobPositionId,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    AssignmentStatus Status,
    decimal? AssignedSalary,
    string? AssignedFieldId,
    string? SupervisorId,
    string? PerformanceNotes,
    string? AssignmentReason
);