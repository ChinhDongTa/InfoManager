namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái của chu kỳ trồng trọt trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum CropCycleStatus
{
    [Display(Name = "Đang lên kế hoạch")]
    Planned = 1,

    [Display(Name = "Đang thực hiện")]
    InProgress = 2,

    [Display(Name = "Hoàn thành")]
    Completed = 3,

    [Display(Name = "Bị hủy")]
    Abandoned = 4,

    [Display(Name = "Tạm ngưng")]
    OnHold = 5
}