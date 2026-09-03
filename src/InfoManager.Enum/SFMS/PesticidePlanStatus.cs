namespace InfoManager.Enum.SFMS;

public enum PesticidePlanStatus
{
    [Display(Name = "Dự kiến")]
    Planned = 1,
    [Display(Name = "Đã phun")]
    Applied = 2,
    [Display(Name = "Bỏ qua")]
    Skipped = 3,
    [Display(Name = "Hủy")]
    Cancelled = 4
}
