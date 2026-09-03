namespace InfoManager.Enum.SFMS;

/// <summary>
/// Thứ tự ưu tiên của nhiệm vụ trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum TaskPriority
{
    [Display(Name = "Thấp")]
    Low = 1,
    [Display(Name = "Trung bình")]
    Normal = 2,
    [Display(Name = "Cao")]
    High = 3,
    [Display(Name = "Khẩn cấp")]
    Critical = 4
}
