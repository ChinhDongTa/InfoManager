namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái bảo trì thiết bị/máy móc trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum MaintenanceStatus
{
    [Display(Name = "Đang lên kế hoạch")]
    Planned = 1,

    [Display(Name = "Đang thực hiện")]
    InProgress = 2,

    [Display(Name = "Hoàn thành")]
    Completed = 3,

    [Display(Name = "Tạm hoãn")]
    Postponed = 4,

    [Display(Name = "Đã hủy")]
    Cancelled = 5
}