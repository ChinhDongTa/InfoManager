using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateDeviceModel
{
    /// <summary>ID thiết bị. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thiết bị.</summary>
    public string? Name { get; set; }

    /// <summary>Loại thiết bị.</summary>
    public DeviceType? DeviceType { get; set; }

    /// <summary>Model thiết bị.</summary>
    public string? Model { get; set; }

    /// <summary>Địa chỉ MAC.</summary>
    public string? MacAddress { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>Trạng thái thiết bị.</summary>
    public DeviceStatus? Status { get; set; }

    /// <summary>Địa chỉ IP.</summary>
    public string? IpAddress { get; set; }

    /// <summary>Giao thức truyền thông.</summary>
    public string? CommunicationProtocol { get; set; }

    /// <summary>Thời điểm đồng bộ dữ liệu gần nhất.</summary>
    public DateTimeOffset? LastDataSyncTime { get; set; }

    /// <summary>Phiên bản firmware.</summary>
    public string? FirmwareVersion { get; set; }

    /// <summary>Mức pin.</summary>
    public decimal? BatteryLevel { get; set; }

    /// <summary>Dung lượng lưu trữ.</summary>
    public decimal? StorageCapacity { get; set; }

    /// <summary>Dung lượng đã dùng.</summary>
    public decimal? StorageUsed { get; set; }

    /// <summary>Ngày bảo trì gần nhất.</summary>
    public DateTimeOffset? LastMaintenanceDate { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateDeviceModel(string id, DeviceDto dto)
    {
        Id = id;
        Name = dto.Name;
        DeviceType = dto.DeviceType;
        Model = dto.Model;
        MacAddress = dto.MacAddress;
        FarmId = dto.FarmId;
        Status = dto.Status;
        IpAddress = dto.IpAddress;
        CommunicationProtocol = dto.CommunicationProtocol;
        LastDataSyncTime = dto.LastDataSyncTime;
        FirmwareVersion = dto.FirmwareVersion;
        BatteryLevel = dto.BatteryLevel;
        StorageCapacity = dto.StorageCapacity;
        StorageUsed = dto.StorageUsed;
        LastMaintenanceDate = dto.LastMaintenanceDate;
        Notes = dto.Notes;
    }

    public UpdateDeviceRequest CreateRequest()
    {
        return new UpdateDeviceRequest
        (
            Id: this.Id,
            Name: this.Name,
            DeviceType: this.DeviceType,
            Model: this.Model,
            MacAddress: this.MacAddress,
            FarmId: this.FarmId,
            Status: this.Status,
            IpAddress: this.IpAddress,
            CommunicationProtocol: this.CommunicationProtocol,
            LastDataSyncTime: this.LastDataSyncTime,
            FirmwareVersion: this.FirmwareVersion,
            BatteryLevel: this.BatteryLevel,
            StorageCapacity: this.StorageCapacity,
            StorageUsed: this.StorageUsed,
            LastMaintenanceDate: this.LastMaintenanceDate,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateDeviceModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}