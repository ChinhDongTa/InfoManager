namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái phân công
/// </summary>
public enum AssignmentStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Tạm dừng")]
    OnHold = 2,
    [Display(Name = "Đã hoàn thành")]
    Completed = 3,
    [Display(Name = "Đã chuyển giao")]
    Transferred = 4,
    [Display(Name = "Tạm đình chỉ")]
    Suspended = 5
}
