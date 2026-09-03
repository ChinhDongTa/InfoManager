namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại nhiệm vụ trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum TaskType
{
    [Display(Name = "Trồng trọt")]
    Planting = 1,
    [Display(Name = "Tưới nước")]
    Watering = 2,
    [Display(Name = "Trồng cây")]
    Weeding = 3,
    [Display(Name = "Phun thuốc")]
    Spraying = 4,
    [Display(Name = "Bón phân")]
    Fertilizing = 5,
    [Display(Name = "Cắt tỉa")]
    Pruning = 6,
    [Display(Name = "Thu hoạch")]
    Harvesting = 7,
    [Display(Name = "Xử lý sau thu hoạch")]
    PostHarvestProcessing = 8,
    [Display(Name = "Bảo trì")]
    Maintenance = 9,
    [Display(Name = "Kiểm tra")]
    Inspection = 10,
    [Display(Name = "Chuẩn bị cánh đồng")]
    FieldPreparation = 11,
    [Display(Name = "Chống sâu bệnh")]
    Pest = 12,
    [Display(Name = "Chống dịch bệnh")]
    DiseaseControl = 13,
    [Display(Name = "Khác")]
    Other = 14
}
