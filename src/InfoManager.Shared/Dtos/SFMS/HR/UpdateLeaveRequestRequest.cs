namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateLeaveRequestRequest(
    string Id,
    string? LeaveType = null,
    DateOnly? FromDate = null,
    DateOnly? ToDate = null,
    string? Reason = null,
    string? Status = null,
    string? ApprovedBy = null
);