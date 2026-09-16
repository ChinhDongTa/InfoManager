namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Đại diện cho cảm biến IoT được lắp đặt trên thửa ruộng.
/// Cảm biến thu thập dữ liệu môi trường như nhiệt độ, độ ẩm, độ ẩm đất...
/// </summary>
public class Sensor : BaseAuditableEntity
{
    /// <summary>
    /// Tên / mã định danh cảm biến
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Loại cảm biến (Nhiệt độ, Độ ẩm, Độ ẩm đất, pH đất, NPK...)
    /// </summary>
    public SensorType SensorType { get; set; }

    /// <summary>
    /// Model / thương hiệu cảm biến
    /// </summary>
    [MaxLength(100)]
    public string? Model { get; set; }

    /// <summary>
    /// Số serial của cảm biến
    /// </summary>
    [MaxLength(100)]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// ID thửa ruộng liên quan
    /// </summary>
    public string FieldId { get; set; }

    /// <summary>
    /// ID thiết bị / gateway thu thập dữ liệu từ cảm biến này
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// Tọa độ vĩ độ của cảm biến
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Tọa độ kinh độ của cảm biến
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Độ sâu lắp đặt (đối với cảm biến đất, đơn vị cm)
    /// </summary>
    public decimal? Depth { get; set; }

    /// <summary>
    /// Trạng thái cảm biến (Hoạt động, Không hoạt động, Lỗi, Bảo trì)
    /// </summary>
    public DeviceStatus Status { get; set; } = DeviceStatus.Active;

    /// <summary>
    /// Thời điểm đọc dữ liệu gần nhất
    /// </summary>
    public DateTimeOffset? LastReadingTime { get; set; }

    /// <summary>
    /// Mức pin (0-100) nếu có
    /// </summary>
    public decimal? BatteryLevel { get; set; }

    /// <summary>
    /// Cường độ tín hiệu (0-100) nếu là cảm biến không dây
    /// </summary>
    public decimal? SignalStrength { get; set; }

    /// <summary>
    /// Ngày lắp đặt
    /// </summary>
    public DateTimeOffset InstallationDate { get; set; }

    /// <summary>
    /// Ngày hiệu chuẩn tiếp theo
    /// </summary>
    public DateTimeOffset? NextCalibrationDate { get; set; }

    // Navigation properties
    public virtual Field? Field { get; set; }

    public virtual Device? Device { get; set; }
    public virtual ICollection<EnvironmentalReading> Readings { get; set; } = [];
}