namespace InfoManager.Enum.SFMS;

/// <summary>
/// Loại thiết bị trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum DeviceType
{
    [Display(Name = "Gateway")]
    Gateway = 1,

    [Display(Name = "Bộ ghi dữ liệu")]
    DataLogger = 2,

    [Display(Name = "Trạm thời tiết")]
    WeatherStation = 3,

    [Display(Name = "Thiết bị điều khiển")]
    ControlDevice = 4,

    [Display(Name = "Bộ điều khiển tưới tiêu")]
    IrrigationController = 5,

    [Display(Name = "Cổng kết nối di động")]
    CellularGateway = 6,

    [Display(Name = "Máy tính biên")]
    EdgeComputer = 7,

    [Display(Name = "Tùy chỉnh")]
    Custom = 8
}