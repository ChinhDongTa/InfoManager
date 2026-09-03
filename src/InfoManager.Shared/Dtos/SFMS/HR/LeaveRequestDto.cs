namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== LeaveRequest ========================
public record LeaveRequestDto(
    string Id,
    string HREmployeeId,
    string? EmployeeName,
    string? EmployeeNumber,
    string LeaveType,
    DateOnly FromDate,
    DateOnly ToDate,
    string? Reason,
    string Status,
    string? ApprovedBy,
    DateTimeOffset? ApprovedAt,
    DateTimeOffset Created
);