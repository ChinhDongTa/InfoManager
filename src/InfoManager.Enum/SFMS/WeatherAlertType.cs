namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại cảnh báo thời tiết được sử dụng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum WeatherAlertType
{
    [Display(Name = " Băng giá")]
    Frost = 1,
    [Display(Name = "Mưa đá")]  
    Hail = 2,
    [Display(Name = "Mưa lớn")]
    HeavyRain = 3,
    [Display(Name = "Hạn hán")]
    Drought = 4,
    [Display(Name = "Gió mạnh")]
    StrongWind = 5,
    [Display(Name = "Nhiệt độ cao")]
    HighTemperature = 6,
    [Display(Name = "Nhiệt độ thấp")]
    LowTemperature = 7,
    [Display(Name = "Lũ lụt")]
    Flood = 8,
    [Display(Name = "Lốc xoáy")]
    Tornado = 9,
    [Display(Name = "Sét đánh")]
    LightningStrike = 10,
    [Display(Name = "Sương mù")]
    Fog = 11,
    [Display(Name = "Bão tuyết")]
    Snowstorm = 12,
    [Display(Name = "Bão cát")]
    Sandstorm = 13,
    [Display(Name = "Hệ thống áp suất cao")]
    HighCompressureSystem = 14,
    [Display(Name = "Hệ thống áp suất thấp")]
    LowCompressureSystem = 15
}
