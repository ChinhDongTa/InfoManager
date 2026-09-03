namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trang thái của kế hoạch trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum PlanStatus
{
    [Display(Name = "Bản nháp")]
    Draft = 1,
    [Display(Name = "Đã phê duyệt")]    
    Approved = 2,
    [Display(Name = "Đang thực hiện")]
    InExecution = 3,
    [Display(Name = "Đã hoàn thành")]
    Completed = 4,
    [Display(Name = "Đã hủy")]
    Cancelled = 5,
    [Display(Name = "Đã chỉnh sửa")]
    Revised = 6
}