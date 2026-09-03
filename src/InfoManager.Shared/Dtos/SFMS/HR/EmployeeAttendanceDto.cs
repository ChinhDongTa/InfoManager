namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== EmployeeAttendance ========================
public record EmployeeAttendanceDto(
    string Id,
    string HREmployeeId,
    string? EmployeeName,
    string? EmployeeNumber,
    DateOnly AttendanceDate,
    TimeOnly? CheckInTime,
    TimeOnly? CheckOutTime,
    string? WorkShiftId,
    string? WorkShiftName,
    string StatusName,
    string? Reason,
    decimal? HoursWorked,
    decimal? OvertimeHours,
    string? Notes,
    DateTimeOffset Created
);