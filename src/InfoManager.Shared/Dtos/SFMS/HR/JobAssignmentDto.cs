namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== JobAssignment ========================
public record JobAssignmentDto(
    string Id,
    string HREmployeeId,
    string? EmployeeName,
    string? EmployeeNumber,
    string JobPositionId,
    string? JobPositionTitle,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    string StatusName,
    decimal? AssignedSalary,
    string? AssignedFieldId,
    string? AssignedFieldName,
    string? SupervisorId,
    string? SupervisorName,
    string? PerformanceNotes,
    string? AssignmentReason,
    DateTimeOffset Created
);