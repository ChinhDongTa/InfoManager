namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái nhiệm vụ trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum TaskStatus
{
    [Display(Name = "Chưa bắt đầu")]
    Pending = 1,

    [Display(Name = "Đang thực hiện")]
    InProgress = 2,

    [Display(Name = "Hoàn thành")]
    Completed = 3,

    [Display(Name = "Bị trì hoãn")]
    Delayed = 4,

    [Display(Name = "Đã hủy")]
    Cancelled = 5,

    [Display(Name = "Tạm hoãn")]
    OnHold = 6
}