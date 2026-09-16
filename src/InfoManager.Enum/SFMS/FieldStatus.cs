namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái của một mảnh đất trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum FieldStatus
{
    [Display(Name = "Trống")]
    Vacant = 1,

    [Display(Name = "Chuẩn bị")]
    Preparation = 2,

    [Display(Name = "Canh tác")]
    Cultivated = 3,

    [Display(Name = "Nghỉ ngơi")]
    Fallow = 4,

    [Display(Name = "Cải tạo")]
    Maintenance = 5
}