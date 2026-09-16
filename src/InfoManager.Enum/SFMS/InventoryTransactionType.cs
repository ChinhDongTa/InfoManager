namespace InfoManager.Enum.SFMS;

public enum InventoryTransactionType
{
    [Display(Name = "Nhập kho")]
    Receipt = 1,

    [Display(Name = "Xuất kho")]
    Issue = 2,

    [Display(Name = "Điều chỉnh")]
    Adjustment = 3
}