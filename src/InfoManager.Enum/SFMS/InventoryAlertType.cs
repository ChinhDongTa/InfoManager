namespace InfoManager.Enum.SFMS;

public enum InventoryAlertType
{
    [Display(Name = "Sắp hết")]
    LowStock = 1,
    [Display(Name = "Hết hàng")]
    OutOfStock = 2,
    [Display(Name = "Sắp hết hạn")]
    ExpiringSoon = 3,
    [Display(Name = "Đã hết hạn")]
    Expired = 4
}