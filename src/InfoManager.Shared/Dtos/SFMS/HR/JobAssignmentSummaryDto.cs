namespace InfoManager.Shared.Dtos.SFMS.HR;

public record JobAssignmentSummaryDto(
    string Id,
    string? EmployeeName,
    string? JobPositionTitle,
    string? FieldName,
    string StatusName,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate
);