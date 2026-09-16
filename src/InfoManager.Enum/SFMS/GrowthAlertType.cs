namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại cảnh báo về sự phát triển của cây trồng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum GrowthAlertType
{
    [Display(Name = "Giai đoạn phát triển bị trì hoãn")]
    StageDelayed = 1,

    [Display(Name = "Giai đoạn phát triển tiến quá nhanh")]
    StageAdvanced = 2,

    [Display(Name = "Điều kiện tối ưu đạt được")]
    OptimalConditionsAchieved = 3,

    [Display(Name = "Nhiệt độ không tối ưu")]
    SuboptimalTemperature = 4,

    [Display(Name = "Độ ẩm không tối ưu")]
    SuboptimalHumidity = 5,

    [Display(Name = "Cây trồng bị thiếu nước")]
    WaterStress = 6,

    [Display(Name = "Thiếu dinh dưỡng")]
    NutrientDeficiency = 7,

    [Display(Name = "Cảnh báo sâu bệnh")]
    PestWarning = 8,

    [Display(Name = "Cảnh báo dịch bệnh")]
    DiseaseWarning = 9,

    [Display(Name = "Sẵn sàng cho giai đoạn tiếp theo")]
    ReadyForNextStage = 10,

    [Display(Name = "Giai đoạn thất bại")]
    StageFailed = 11
}