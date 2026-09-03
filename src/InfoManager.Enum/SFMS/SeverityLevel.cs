namespace InfoManager.Enum.SFMS;

/// <summary>
/// Mức độ nghiêm trọng của cảnh báo hoặc sự kiện trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum SeverityLevel
{
    [Display(Name = "Thấp")]
    Low = 1,
    [Display(Name = "Trung bình")]
    Medium = 2,
    [Display(Name = "Cao")]
    High = 3,
    [Display(Name = "Nghiêm trọng")]
    Critical = 4
}
