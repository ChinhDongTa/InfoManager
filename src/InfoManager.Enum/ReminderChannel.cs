namespace InfoManager.Enum;

public enum ReminderChannel
{
    [Display(Name = "Thông báo đẩy trên app")]
    Push = 1,       // Thông báo đẩy trên app
    [Display(Name = "Email")]
    Email = 2,
    [Display(Name = "Thông báo trong ứng dụng")]
    InApp = 3,      // Thông báo trong ứng dụng
    [Display(Name = "SMS")]
    SMS = 4         // Nếu sau này tích hợp
}