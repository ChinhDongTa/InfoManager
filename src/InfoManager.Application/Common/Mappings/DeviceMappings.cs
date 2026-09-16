using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của Device.
/// </summary>
public static class DeviceMappings
{
    public static CreateDeviceCommand ToCreateCommand(CreateDeviceRequest request)
        => new()
        {
            Name = request.Name,
            DeviceType = request.DeviceType,
            Model = request.Model,
            MacAddress = request.MacAddress,
            FarmId = request.FarmId,
            Status = request.Status,
            IpAddress = request.IpAddress,
            CommunicationProtocol = request.CommunicationProtocol,
            FirmwareVersion = request.FirmwareVersion,
            BatteryLevel = request.BatteryLevel,
            StorageCapacity = request.StorageCapacity,
            StorageUsed = request.StorageUsed,
            InstallationDate = request.InstallationDate,
            Notes = request.Notes
        };

    /// <summary>
    /// Map Update request sang command. <paramref name="id"/> lấy từ client (thường là route).
    /// </summary>
    public static UpdateDeviceCommand ToUpdateCommand(UpdateDeviceRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            DeviceType = request.DeviceType,
            Model = request.Model,
            MacAddress = request.MacAddress,
            FarmId = request.FarmId,
            Status = request.Status,
            IpAddress = request.IpAddress,
            CommunicationProtocol = request.CommunicationProtocol,
            LastDataSyncTime = request.LastDataSyncTime,
            FirmwareVersion = request.FirmwareVersion,
            BatteryLevel = request.BatteryLevel,
            StorageCapacity = request.StorageCapacity,
            StorageUsed = request.StorageUsed,
            LastMaintenanceDate = request.LastMaintenanceDate,
            Notes = request.Notes
        };

    public static SearchDevicesQuery ToSearchQuery(SearchDevicesRequest request)
        => new(

            Term: request.Term,
            DeviceType: request.DeviceType,
            DeviceStatus: request.DeviceStatus,
            StartInstallationDate: request.StartInstallationDate,
            EndInstallationDate: request.EndInstallationDate,
            StartLastMaintenanceDate: request.StartLastMaintenanceDate,
            EndLastMaintenanceDate: request.EndLastMaintenanceDate,
            PageNumber: request.PageNumber,
            PageSize: request.PageSize
        );
}