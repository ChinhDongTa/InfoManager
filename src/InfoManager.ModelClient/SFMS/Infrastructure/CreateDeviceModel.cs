using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class CreateDeviceModel
{
    /// <summary>
    /// Tên thiết bị
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Loại thiết bị
    /// </summary>
    [Required]
    public DeviceType DeviceType { get; set; }

    /// <summary>
    /// Model thiết bị
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Địa chỉ MAC
    /// </summary>
    public string? MacAddress { get; set; }

    /// <summary>
    /// Nông trại sở hữu thiết bị
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Trạng thái thiết bị
    /// </summary>
    public DeviceStatus Status { get; set; } = DeviceStatus.Active;

    /// <summary>
    /// Địa chỉ IP
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Giao thức truyền thông
    /// </summary>
    public string? CommunicationProtocol { get; set; }

    /// <summary>
    /// Phiên bản firmware
    /// </summary>
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Mức pin
    /// </summary>
    public decimal? BatteryLevel { get; set; }

    /// <summary>
    /// Dung lượng lưu trữ
    /// </summary>
    public decimal? StorageCapacity { get; set; }

    /// <summary>
    /// Dung lượng đã dùng
    /// </summary>
    public decimal? StorageUsed { get; set; }

    /// <summary>
    /// Ngày lắp đặt
    /// </summary>
    public DateTimeOffset InstallationDate { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateDeviceRequest CreateRequest()
    {
        return new CreateDeviceRequest
        (
            Name: this.Name,
            DeviceType: this.DeviceType,
            Model: this.Model,
            MacAddress: this.MacAddress,
            FarmId: this.FarmId,
            Status: this.Status,
            IpAddress: this.IpAddress,
            CommunicationProtocol: this.CommunicationProtocol,
            FirmwareVersion: this.FirmwareVersion,
            BatteryLevel: this.BatteryLevel,
            StorageCapacity: this.StorageCapacity,
            StorageUsed: this.StorageUsed,
            InstallationDate: this.InstallationDate,
            Notes: this.Notes
        );
    }
}
