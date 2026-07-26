namespace InfoManager.Enum;

/// <summary>
/// Lý do thu hồi token
/// </summary>
public enum ReasonRevoke
{
    [Display(Name = "Người dùng chủ động logout")]
    Logout = 0,          // Người dùng chủ động logout
    [Display(Name = "Token bị nghi ngờ lộ/chiếm quyền")]
    Compromised = 1,     // Token bị nghi ngờ lộ/chiếm quyền
    [Display(Name = "Admin khóa token")]
    AdminRevoke = 2,     // Admin khóa token
    [Display(Name = "Token hết hạn nhưng vẫn lưu để audit")]
    Expired = 3,         // Token hết hạn nhưng vẫn lưu để audit
    [Display(Name = "Khóa tất cả")]
    LogoutAll = 4, //Thu hồi tất cả để bảo trì hệ thống
    [Display(Name = "Lý do khác")]
    Other = 99           // Lý do khác
}