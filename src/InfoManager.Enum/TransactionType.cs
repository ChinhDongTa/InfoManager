namespace InfoManager.Enum;
public enum TransactionType
{
    [Display(Name ="Chi tiêu")]
    Expense = 0,
    [Display(Name = "Thu nhập")]
    Income = 1,
    [Display(Name = "Khác")]
    Other = 2
}