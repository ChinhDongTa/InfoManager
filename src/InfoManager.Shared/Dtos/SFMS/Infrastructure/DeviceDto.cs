namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

// ======================== Device ========================

public record DeviceDto(
    string Id,
    string Name,
    string DeviceTypeName,
    string? Model,
    string? MacAddress,
    string FarmId,
    string? FarmName,
    string StatusName,
    string? IpAddress,
    string? CommunicationProtocol,
    DateTimeOffset? LastDataSyncTime,
    string? FirmwareVersion,
    decimal? BatteryLevel,
    decimal? StorageCapacity,
    decimal? StorageUsed,
    DateTimeOffset InstallationDate,
    DateTimeOffset? LastMaintenanceDate,
    string? Notes,
    DateTimeOffset Created
);

public record DeviceSummaryDto(
    string Id,
    string Name,
    string DeviceTypeName,
    string? Model,
    string? FarmName,
    string StatusName,
    decimal? BatteryLevel,
    DateTimeOffset? LastDataSyncTime
);

public record SearchDevicesRequest(
    string? Term ,
    DeviceType? DeviceType ,
    DeviceStatus? DeviceStatus ,
    DateTimeOffset? StartInstallationDate,
    DateTimeOffset? EndInstallationDate,
    DateTimeOffset? StartLastMaintenanceDate,
    DateTimeOffset? EndLastMaintenanceDate,
    int PageNumber,
    int PageSize 
);

public record CreateDeviceRequest(string Name,
                                  DeviceType DeviceType,
                                  string? Model,
                                  string? MacAddress,
                                  string FarmId,
                                  DeviceStatus Status,
                                  string? IpAddress,
                                  string? CommunicationProtocol,
                                  string? FirmwareVersion,
                                  decimal? BatteryLevel,
                                  decimal? StorageCapacity,
                                  decimal? StorageUsed,
                                  DateTimeOffset InstallationDate,
                                  string? Notes);

public record UpdateDeviceRequest(
    string Id,
    string? Name ,
    DeviceType? DeviceType ,
    string? Model ,
    string? MacAddress ,
    string? FarmId ,
    DeviceStatus? Status ,
    string? IpAddress ,
    string? CommunicationProtocol ,
    DateTimeOffset? LastDataSyncTime ,
    string? FirmwareVersion ,
    decimal? BatteryLevel ,
    decimal? StorageCapacity ,
    decimal? StorageUsed ,
    DateTimeOffset? LastMaintenanceDate ,
    string? Notes 
);