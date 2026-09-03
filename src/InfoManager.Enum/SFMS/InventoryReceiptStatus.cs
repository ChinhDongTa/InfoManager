
namespace InfoManager.Enum.SFMS;

public enum InventoryReceiptStatus
{
    [Display(Name = "Nháp")]
    Draft = 1,
    [Display(Name = "Đã ghi sổ")]
    Posted = 2,
    [Display(Name = "Hủy")]
    Cancelled = 3
}