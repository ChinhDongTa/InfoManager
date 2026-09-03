namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái chấm công
/// </summary>
public enum AttendanceStatus
{
    [Display(Name = "Có mặt")]
    Present = 1,
    [Display(Name = "Vắng mặt")]
    Absent = 2,
    [Display(Name = "Đi muộn")]
    Late = 3,
    [Display(Name = "Nghỉ phép")]
    OnLeave = 4,
    [Display(Name = "Nửa ngày")]
    HalfDay = 5,
    [Display(Name = "Làm thêm giờ")]
    Overtime = 6
}
