namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== EmployeeAttendance ========================
/// <summary>
/// Chấm công nhân viên
/// </summary>
public class EmployeeAttendance : BaseAuditableEntity
{
    /// <summary>ID nhân viên</summary>
    public required string HREmployeeId { get; set; }

    /// <summary>Ngày chấm công</summary>
    public DateOnly AttendanceDate { get; set; }

    /// <summary>Giờ vào</summary>
    public TimeOnly? CheckInTime { get; set; }

    /// <summary>Giờ ra</summary>
    public TimeOnly? CheckOutTime { get; set; }

    /// <summary>ID ca làm việc</summary>
    public string? WorkShiftId { get; set; }

    /// <summary>Trạng thái chấm công</summary>
    public AttendanceStatus Status { get; set; }

    /// <summary>Lý do vắng/nghỉ</summary>
    [MaxLength(500)]
    public string? Reason { get; set; }

    /// <summary>Số giờ làm việc</summary>
    public decimal? HoursWorked { get; set; }

    /// <summary>Số giờ làm thêm</summary>
    public decimal? OvertimeHours { get; set; }

    /// <summary>Ghi chú</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    public virtual HREmployee? HREmployee { get; set; }
    public virtual WorkShift? WorkShift { get; set; }
}
