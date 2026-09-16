namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái thanh toán của một giao dịch hoặc đơn hàng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum PaymentStatus
{
    [Display(Name = "Chưa thanh toán")]
    Pending = 1,

    [Display(Name = "Đã thanh toán")]
    Paid = 2,

    [Display(Name = "Thanh toán một phần")]
    PartiallyPaid = 3,

    [Display(Name = "Thanh toán thất bại")]
    Failed = 4,

    [Display(Name = "Đã hoàn tiền")]
    Refunded = 5
}