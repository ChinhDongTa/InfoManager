namespace InfoManager.Enum.SFMS;

public enum PesticideType
{
    [Display(Name = "Thuốc trừ sâu")]
    Insecticide = 1,
    [Display(Name = "Thuốc trừ bệnh")]
    Fungicide = 2,
    [Display(Name = "Thuốc trừ cỏ")]
    Herbicide = 3,
    [Display(Name = "Thuốc trừ nhện")]
    Acaricide = 4,
    [Display(Name = "Thuốc trừ ốc")]
    Molluscicide = 5,
    [Display(Name = "Khác")]
    Other = 6
}
