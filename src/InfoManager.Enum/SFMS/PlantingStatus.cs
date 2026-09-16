namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trang thái trồng trọt của cây trồng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum PlantingStatus
{
    [Display(Name = "Đã lên kế hoạch")]
    Planned = 1,

    [Display(Name = "Đã trồng")]
    Planted = 2,

    [Display(Name = "Đang phát triển")]
    Growing = 3,

    [Display(Name = "Đã trưởng thành")]
    Mature = 4,

    [Display(Name = "Đang thu hoạch")]
    Harvesting = 5,

    [Display(Name = "Đã thu hoạch")]
    Harvested = 6,

    [Display(Name = "Bị bỏ hoang")]
    Abandoned = 7
}