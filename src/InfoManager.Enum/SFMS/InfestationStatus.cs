namespace InfoManager.Enum.SFMS;

/// <summary>
/// Trạng thái của sự phát sinh sâu bệnh
/// </summary>
public enum InfestationStatus
{
    [Display(Name = "Đã phát hiện")]
    Detected = 1,

    [Display(Name = "Đã xác nhận")]
    Confirmed = 2,

    [Display(Name = "Đang điều trị")]
    UnderTreatment = 3,

    [Display(Name = "Đã kiểm soát")]
    Controlled = 4,

    [Display(Name = "Đã loại bỏ")]
    Eradicated = 5,

    [Display(Name = "Xảy ra trở lại")]
    Recurring = 6
}