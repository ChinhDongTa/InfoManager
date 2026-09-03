namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateLeaveRequestRequest(
    string HREmployeeId,
    string LeaveType,
    DateOnly FromDate,
    DateOnly ToDate,
    string? Reason
);
