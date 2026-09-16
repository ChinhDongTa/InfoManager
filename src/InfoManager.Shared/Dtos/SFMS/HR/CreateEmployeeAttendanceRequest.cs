namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateEmployeeAttendanceRequest(
    string HREmployeeId,
    DateOnly AttendanceDate,
    TimeOnly? CheckInTime,
    TimeOnly? CheckOutTime,
    string? WorkShiftId,
    AttendanceStatus Status,
    string? Reason,
    decimal? HoursWorked,
    decimal? OvertimeHours,
    string? Notes
);