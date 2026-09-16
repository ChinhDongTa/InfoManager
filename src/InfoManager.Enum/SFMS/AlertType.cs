namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại cảnh báo cho việc giám sát thiết bị
/// </summary>
public enum AlertType
{
    [Display(Name = "Pin yếu")]
    LowBattery = 1,

    [Display(Name = "Tín hiệu yếu")]
    LowSignal = 2,

    [Display(Name = "Không nhận được dữ liệu")]
    NoDataReceived = 3,

    [Display(Name = "Lỗi phần cứng")]
    HardwareFailure = 4,

    [Display(Name = "Lỗi kết nối")]
    CommunicationError = 5,

    [Display(Name = "Cấu hình sai")]
    ConfigurationError = 6,

    [Display(Name = "Lỗi cảm biến")]
    SensorFailure = 7,

    [Display(Name = "Bộ nhớ đầy")]
    StorageFull = 8,

    [Display(Name = "Truy cập không được phép")]
    UnauthorizedAccess = 9,

    [Display(Name = "Lỗi hệ thống")]
    SystemError = 10
}