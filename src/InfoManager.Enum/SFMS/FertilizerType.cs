namespace InfoManager.Enum.SFMS;

public enum FertilizerType
{
    [Display(Name = "Hữu cơ")]
    Organic = 1,
    [Display(Name = "NPK")]
    NPK = 2,
    [Display(Name = "Đạm")]
    Nitrogen = 3,
    [Display(Name = "Lân")]
    Phosphorus = 4,
    [Display(Name = "Kali")]
    Potassium = 5,
    [Display(Name = "Vi lượng")]
    Micronutrient = 6,
    [Display(Name = "Khác")]
    Other = 7
}