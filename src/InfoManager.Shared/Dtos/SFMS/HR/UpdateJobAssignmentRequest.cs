using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateJobAssignmentRequest(
    string Id,
    DateTimeOffset? EndDate = null,
    AssignmentStatus? Status = null,
    decimal? AssignedSalary = null,
    string? AssignedFieldId = null,
    string? SupervisorId = null,
    string? PerformanceNotes = null,
    string? AssignmentReason = null
);
