namespace InfoManager.Enum.SFMS;

public enum FertilizationPlanStatus
{
    [Display(Name = "Dự kiến")]
    Planned = 1,
    [Display(Name = "Đã bón")]
    Applied = 2,
    [Display(Name = "Bỏ qua")]
    Skipped = 3,
    [Display(Name = "Hủy")]
    Cancelled = 4
}