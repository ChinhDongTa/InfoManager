namespace InfoManager.Enum.SFMS;

/// <summary>
/// Farm operational status
/// </summary>
public enum FarmStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Không hoạt động")]
    Inactive = 2,
    [Display(Name = "Bảo trì")]
    Maintenance = 3,
    [Display(Name = "Đóng")]
    Closed = 4
}
