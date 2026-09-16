namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trang thái của sản phẩm trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
public enum ProductStatus
{
    [Display(Name = "Có sẵn")]
    Available = 1,

    [Display(Name = "Đã bán")]
    Sold = 2,

    [Display(Name = "Bán một phần")]
    PartiallySold = 3,

    [Display(Name = "Hỏng")]
    Damaged = 4,

    [Display(Name = "Bị loại bỏ")]
    Discarded = 5,

    [Display(Name = "Đang xử lý")]
    InProcessing = 6
}