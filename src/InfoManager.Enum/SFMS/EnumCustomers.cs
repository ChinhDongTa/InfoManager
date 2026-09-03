namespace InfoManager.Enum.SFMS;

public enum CustomerType
{
    [Display(Name = "Cá nhân")]
    Individual = 1,
    [Display(Name = "Doanh nghiệp")]
    Company = 2,
    [Display(Name ="Khác")]
    Other
}

public enum CustomerStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Không hoạt động")]
    Inactive = 2,
    [Display(Name = "Bị khóa")]
    Blocked = 3
}

public enum CustomerCareType
{
    [Display(Name = "Gọi điện")]
    Call = 1,
    [Display(Name = "Ghé thăm")]
    Visit = 2,
    [Display(Name = "Khiếu nại")]
    Complaint = 3,
    [Display(Name = "Theo dõi")]
    FollowUp = 4,
    [Display(Name = "Hỗ trợ")]
    Support = 5
}

public enum CustomerCareStatus
{
    [Display(Name = "Đang mở")]
    Open = 1,
    [Display(Name = "Đang xử lý")]
    InProgress = 2,
    [Display(Name = "Đã xử lý")]
    Resolved = 3,
    [Display(Name = "Đã đóng")]
    Closed = 4
}