namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại tài nguyên được sử dụng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum ResourceType
{
    [Display(Name = "Hạt giống")]
    Seed = 1,

    [Display(Name = "Phân bón")]
    Fertilizer = 2,

    [Display(Name = "Thuốc trừ sâu")]
    Pesticide = 3,

    [Display(Name = "Thuốc diệt cỏ")]
    Herbicide = 4,

    [Display(Name = "Thuốc trừ nấm")]
    Fungicide = 5,

    [Display(Name = "Thuốc trừ côn trùng")]
    Insecticide = 6,

    [Display(Name = "Công cụ")]
    Tool = 7,

    [Display(Name = "Thiết bị")]
    Equipment = 8,

    [Display(Name = "Nhiên liệu")]
    Fuel = 9,

    [Display(Name = "Vật liệu phủ đất")]
    Mulch = 10,

    [Display(Name = "Đất")]
    Soil = 11,

    [Display(Name = "Dinh dưỡng")]
    Nutrient = 12,

    [Display(Name = "Khác")]
    Other = 13
}