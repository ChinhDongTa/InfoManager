namespace InfoManager.Enum.SFMS;

/// <summary>
/// Mức độ nghiêm trọng của cảnh báo trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum AlertSeverity
{
    [Display(Name = "Thông tin")]
    Info = 1,

    [Display(Name = "Cảnh báo")]
    Warning = 2,

    [Display(Name = "Lỗi")]
    Error = 3,

    [Display(Name = "Nguy cấp")]
    Critical = 4
}