namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái tài khoản
/// </summary>
public enum AccountStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Không hoạt động")]
    Inactive = 2,
    [Display(Name = "Bị khóa")]
    Locked = 3,
    [Display(Name = "Vô hiệu hóa")]
    Disabled = 4,
    [Display(Name = "Đang chờ")]
    Pending = 5
}
