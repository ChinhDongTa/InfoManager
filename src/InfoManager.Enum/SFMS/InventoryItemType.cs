namespace InfoManager.Enum.SFMS;

public enum InventoryItemType
{
    [Display(Name = "Phân bón")]
    Fertilizer = 1,
    [Display(Name = "Thuốc BVTV")]
    Pesticide = 2,
    [Display(Name = "Hạt giống")]
    Seed = 3,
    [Display(Name = "Nhiên liệu")]
    Fuel = 4,
    [Display(Name = "Vật tư khác")]
    Other = 5
}
