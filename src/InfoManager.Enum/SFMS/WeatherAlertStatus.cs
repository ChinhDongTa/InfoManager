namespace InfoManager.Enum.SFMS;

/// <summary>
/// Weather alert status
/// </summary>
public enum WeatherAlertStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,

    [Display(Name = "Hết hạn")]
    Expired = 2,

    [Display(Name = "Đã hủy")]
    Cancelled = 3,

    [Display(Name = "Đã gia hạn")]
    Extended = 4
}