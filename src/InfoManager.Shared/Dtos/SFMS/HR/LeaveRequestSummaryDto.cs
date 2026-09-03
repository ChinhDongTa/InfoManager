namespace InfoManager.Shared.Dtos.SFMS.HR;

public record LeaveRequestSummaryDto(
    string Id,
    string? EmployeeName,
    string LeaveType,
    DateOnly FromDate,
    DateOnly ToDate,
    string Status
);