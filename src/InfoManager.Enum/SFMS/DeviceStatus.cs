namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái của thiết bị trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum DeviceStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Không hoạt động")]
    Inactive = 2,
    [Display(Name = "Lỗi")]
    Faulty = 3,
    [Display(Name = "Bảo trì")]
    Maintenance = 4,
    [Display(Name = "Ngắt kết nối")]
    Disconnected = 5,
    [Display(Name = "Đã gỡ bỏ")]
    Offboarded = 6
}