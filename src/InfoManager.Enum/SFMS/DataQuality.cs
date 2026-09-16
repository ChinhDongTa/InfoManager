namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các mức độ chất lượng dữ liệu được sử dụng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum DataQuality
{
    [Display(Name = "Tốt")]
    Good = 1,

    [Display(Name = "Cảnh báo")]
    Warning = 2,

    [Display(Name = "Lỗi")]
    Error = 3,

    [Display(Name = "Thiếu")]
    Missing = 4
}