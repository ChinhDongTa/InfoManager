namespace InfoManager.Enum;

public enum TokenStatus
{
    [Display(Name = "Đang bị chặn")]
    Blacklisted = 0,     // Đang bị chặn

    [Display(Name = "Đã mở khóa")]
    Unlocked = 1,        // Đã mở khóa (user xác thực lại thành công)

    [Display(Name = "Khóa vĩnh viễn")]
    Permanent = 2        // Khóa vĩnh viễn
}