

namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trang thái sức khỏe của cây trồng hoặc vật nuôi trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum HealthStatus
{
    [Display(Name = "Xuất sắc")]
    Excellent = 1,
    [Display(Name = "Tốt")]
    Good = 2,
    [Display(Name = "Trung bình")]
    Fair = 3,
    [Display(Name = "Kém")]
    Poor = 4,
    [Display(Name = "Nguy hiểm")]
    Critical = 5,
    [Display(Name = "Chết")]
    Dead = 6
}
