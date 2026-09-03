namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái thanh toán lương
/// </summary>
public enum PayrollStatus
{
    [Display(Name = "Đang chờ")]
    Pending = 1,
    [Display(Name = "Đã xử lý")]
    Processed = 2,
    [Display(Name = "Đã thanh toán")]
    Paid = 3,
    [Display(Name = "Thất bại")]
    Failed = 4,
    [Display(Name = "Tạm giữ")]
    OnHold = 5
}