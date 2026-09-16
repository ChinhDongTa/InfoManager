using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class CreateSensorModel
{
    /// <summary>
    /// Tên cảm biến
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Loại cảm biến
    /// </summary>
    [Required]
    public SensorType SensorType { get; set; }

    /// <summary>
    /// Model cảm biến
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Số serial
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Thửa đất gắn cảm biến
    /// </summary>
    [Required]
    public string FieldId { get; set; } = string.Empty;

    /// <summary>
    /// Thiết bị gắn cảm biến
    /// </summary>
    public string? DeviceId { get; set; }

    /// <summary>
    /// Vĩ độ
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Kinh độ
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Độ sâu lắp đặt
    /// </summary>
    public decimal? Depth { get; set; }

    /// <summary>
    /// Trạng thái thiết bị
    /// </summary>
    public DeviceStatus Status { get; set; } = DeviceStatus.Active;

    /// <summary>
    /// Ngày lắp đặt
    /// </summary>
    public DateTimeOffset InstallationDate { get; set; }

    /// <summary>
    /// Ngày hiệu chuẩn tiếp theo
    /// </summary>
    public DateTimeOffset? NextCalibrationDate { get; set; }

    public CreateSensorRequest CreateRequest()
    {
        return new CreateSensorRequest
        (
            Name: this.Name,
            SensorType: this.SensorType,
            Model: this.Model,
            SerialNumber: this.SerialNumber,
            FieldId: this.FieldId,
            DeviceId: this.DeviceId,
            Latitude: this.Latitude,
            Longitude: this.Longitude,
            Depth: this.Depth,
            Status: this.Status,
            InstallationDate: this.InstallationDate,
            NextCalibrationDate: this.NextCalibrationDate
        );
    }
}