namespace InfoManager.Enum;

/// <summary>
/// Ưu tiên
/// </summary>
public enum Priority
{
    [Display(Name = "Rất cao")]
    VeryHigh = 1,

    [Display(Name = "Cao")]
    High = 2,

    [Display(Name = "Trung bình")]
    Medium = 3,

    [Display(Name = "Thấp")]
    Low = 4,

    [Display(Name = "Rất thấp")]
    VeryLow = 5
}