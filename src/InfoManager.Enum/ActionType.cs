namespace InfoManager.Enum;

public enum ActionType
{
    [Display(Name = "tạo mới")]
    Create,

    [Display(Name = "cập nhật")]
    Update,

    [Display(Name = "xóa")]
    Delete,

    [Display(Name = "đọc")]
    Read,

    [Display(Name = "phê duyệt")]
    Approve,

    [Display(Name = "từ chối")]
    Reject,

    [Display(Name = "xuất file")]
    Export,

    [Display(Name = "import")]
    Import,
    [Display(Name = "khác")]
    None
}
