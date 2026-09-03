namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Đại diện cho thiết bị IoT / gateway thu thập và truyền dữ liệu cảm biến.
/// Một thiết bị có thể quản lý nhiều cảm biến.
/// </summary>
public class Device : BaseAuditableEntity
{
    /// <summary>
    /// Tên / mã định danh thiết bị
    /// </summary>
    [MaxLength(100)]
    public required string Name { get; set; }

    /// <summary>
    /// Loại thiết bị (Gateway, DataLogger, WeatherStation...)
    /// </summary>
    public required DeviceType DeviceType { get; set; }

    /// <summary>
    /// Model / thương hiệu thiết bị
    /// </summary>
    [MaxLength(100)]
    public string? Model { get; set; }

    /// <summary>
    /// Địa chỉ MAC hoặc mã định danh duy nhất
    /// </summary>
    [MaxLength(50)]
    public string? MacAddress { get; set; }

    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Trạng thái thiết bị
    /// </summary>
    public DeviceStatus Status { get; set; } = DeviceStatus.Active;

    /// <summary>
    /// Địa chỉ IP (nếu có)
    /// </summary>
    [MaxLength(50)]
    public string? IpAddress { get; set; }

    /// <summary>
    /// Giao thức truyền thông (WiFi, LoRaWAN, Cellular, Bluetooth...)
    /// </summary>
    [MaxLength(50)]
    public string? CommunicationProtocol { get; set; }

    /// <summary>
    /// Thời điểm truyền dữ liệu gần nhất
    /// </summary>
    public DateTimeOffset? LastDataSyncTime { get; set; }

    /// <summary>
    /// Phiên bản firmware
    /// </summary>
    [MaxLength(50)]
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Mức pin (0-100) nếu có
    /// </summary>
    public decimal? BatteryLevel { get; set; }

    /// <summary>
    /// Dung lượng lưu trữ (MB)
    /// </summary>
    public decimal? StorageCapacity { get; set; }

    /// <summary>
    /// Dung lượng đã sử dụng (MB)
    /// </summary>
    public decimal? StorageUsed { get; set; }

    /// <summary>
    /// Ngày lắp đặt
    /// </summary>
    public DateTimeOffset InstallationDate { get; set; }

    /// <summary>
    /// Ngày bảo trì gần nhất
    /// </summary>
    public DateTimeOffset? LastMaintenanceDate { get; set; }

    /// <summary>
    /// Ghi chú về thiết bị
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }
    public virtual ICollection<Sensor> Sensors { get; set; } = [];
    public virtual ICollection<DeviceAlert> Alerts { get; set; } = [];
}
