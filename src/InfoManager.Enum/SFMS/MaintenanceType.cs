namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại bảo trì thiết bị/máy móc trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum MaintenanceType
{
    [Display(Name = "Bảo trì định kỳ")]
    Routine = 1,

    [Display(Name = "Sửa chữa")]
    Repair = 2,

    [Display(Name = "Kiểm tra")]
    Inspection = 3,

    [Display(Name = "Bảo trì tổng thể")]
    Overhaul = 4,

    [Display(Name = "Khẩn cấp")]
    Emergency = 5,

    [Display(Name = "Thay đổi")]
    Modification = 6
}