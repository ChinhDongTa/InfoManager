namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trang thái của thiết bị trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum EquipmentStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Rảnh")]
    Idle = 2,
    [Display(Name = "Đang bảo trì")]
    UnderMaintenance = 3,
    [Display(Name = "Đã ngừng")]
    Retired = 4,
    [Display(Name = "Mất")]
    Lost = 5
}
