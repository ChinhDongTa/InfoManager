namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại cảm biến được sử dụng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum SensorType
{
    [Display(Name = "Nhiệt độ")]
    Temperature = 1,
    [Display(Name = "Độ ẩm")]
    Humidity = 2,
    [Display(Name = "Độ ẩm đất")]
    SoilMoisture = 3,
    [Display(Name = "pH đất")]
    SoilPH = 4,
    [Display(Name = "NPK")]
    NPK = 5,              // Nitrogen, Phosphorus, Potassium
    [Display(Name = "Độ dẫn điện")]
    Conductivity = 6,
    [Display(Name = "Cường độ ánh sáng")]
    LightIntensity = 7,
    [Display(Name = "Cảm biến mưa")]
    RainGauge = 8,
    [Display(Name = "Tốc độ gió")]
    WindSpeed = 9,
    [Display(Name = "Áp suất không khí")]
    AirPressure = 10,
    [Display(Name = "CO2")]
    CO2 = 11,
    [Display(Name = "Độ mặn")]
    Salinity = 12,
    [Display(Name = "Tùy chỉnh")]
    Custom = 13
}
/// <summary>
/// Trạng thái việc làm
/// </summary>
public enum EmploymentStatus
{
    [Display(Name = "Hoạt động")]
    Active = 1,
    [Display(Name = "Không hoạt động")]
    Inactive = 2,
    [Display(Name = "Nghỉ phép")]
    OnLeave = 3,
    [Display(Name = "Tạm đình chỉ")]
    Suspended = 4,
    [Display(Name = "Đã chấm dứt")]
    Terminated = 5,
    [Display(Name = "Đã nghỉ hưu")]
    Retired = 6
}

/// <summary>
/// Loại thanh toán lương
/// </summary>
public enum SalaryType
{
    [Display(Name = "Theo giờ")]
    Hourly = 1,
    [Display(Name = "Theo ngày")]
    Daily = 2,
    [Display(Name = "Theo tuần")]
    Weekly = 3,
    [Display(Name = "Hai tuần một lần")]
    Biweekly = 4,
    [Display(Name = "Theo tháng")]
    Monthly = 5,
    [Display(Name = "Theo năm")]
    Annual = 6
}
