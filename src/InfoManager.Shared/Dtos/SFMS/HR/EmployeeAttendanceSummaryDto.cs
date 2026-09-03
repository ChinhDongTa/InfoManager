namespace InfoManager.Shared.Dtos.SFMS.HR;

public record EmployeeAttendanceSummaryDto(
    string Id,
    string? EmployeeName,
    DateOnly AttendanceDate,
    TimeOnly? CheckInTime,
    TimeOnly? CheckOutTime,
    string StatusName,
    decimal? HoursWorked,
    decimal? OvertimeHours
);