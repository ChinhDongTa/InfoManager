namespace InfoManager.Enum.SFMS;

/// <summary>
/// Mức độ chất lượng đất
/// </summary>
public enum SoilCondition
{
    [Display(Name = "Kém")]
    Poor = 1,

    [Display(Name = "Trung bình")]
    Fair = 2,

    [Display(Name = "Tốt")]
    Good = 3,

    [Display(Name = "Xuất sắc")]
    Excellent = 4
}