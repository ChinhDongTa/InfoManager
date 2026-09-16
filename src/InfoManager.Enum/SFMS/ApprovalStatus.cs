namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái phê duyệt cho các khoản chi phí
/// </summary>
public enum ApprovalStatus
{
    [Display(Name = "Đang chờ duyệt")]
    Pending = 1,

    [Display(Name = "Đã duyệt")]
    Approved = 2,

    [Display(Name = "Bị từ chối")]
    Rejected = 3,

    [Display(Name = "Tạm ngưng")]
    OnHold = 4
}