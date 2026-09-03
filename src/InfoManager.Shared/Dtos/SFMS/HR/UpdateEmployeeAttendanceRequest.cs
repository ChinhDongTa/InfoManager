using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateEmployeeAttendanceRequest(
    string Id,
    TimeOnly? CheckInTime = null,
    TimeOnly? CheckOutTime = null,
    string? WorkShiftId = null,
    AttendanceStatus? Status = null,
    string? Reason = null,
    decimal? HoursWorked = null,
    decimal? OvertimeHours = null,
    string? Notes = null
);
