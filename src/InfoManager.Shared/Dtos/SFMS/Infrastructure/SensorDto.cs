namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

// ======================== Sensor ========================

public record SensorDto(
    string Id,
    string Name,
    SensorType SensorType,
    string SensorTypeName,
    string? Model,
    string? SerialNumber,
    string FieldId,
    string? FieldName,
    string? DeviceId,
    string? DeviceName,
    decimal? Latitude,
    decimal? Longitude,
    decimal? Depth,
    DeviceStatus Status,
    string StatusName,
    DateTimeOffset? LastReadingTime,
    decimal? BatteryLevel,
    decimal? SignalStrength,
    DateTimeOffset InstallationDate,
    DateTimeOffset? NextCalibrationDate,
    int ReadingCount,
    DateTimeOffset Created
);

public record SensorSummaryDto(
    string Id,
    string Name,
    string SensorTypeName,
    string? FieldName,
    string? DeviceName,
    string StatusName,
    decimal? BatteryLevel,
    decimal? SignalStrength,
    DateTimeOffset? LastReadingTime
);

public record SearchSensorsRequest(
    string? Term,
    string? FieldId,
    string? DeviceId,
    SensorType? SensorType,
    DeviceStatus? Status,
    DateTimeOffset? StartInstallationDate,
    DateTimeOffset? EndInstallationDate,
    int PageNumber,
    int PageSize
);

public record CreateSensorRequest(
    string Name,
    SensorType SensorType,
    string? Model = null,
    string? SerialNumber = null,
    string FieldId = "",
    string? DeviceId = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    decimal? Depth = null,
    DeviceStatus Status = DeviceStatus.Active,
    DateTimeOffset InstallationDate = default,
    DateTimeOffset? NextCalibrationDate = null
);

public record UpdateSensorRequest(
    string Id,
    string? Name = null,
    SensorType? SensorType = null,
    string? Model = null,
    string? SerialNumber = null,
    string? FieldId = null,
    string? DeviceId = null,
    decimal? Latitude = null,
    decimal? Longitude = null,
    decimal? Depth = null,
    DeviceStatus? Status = null,
    DateTimeOffset? LastReadingTime = null,
    decimal? BatteryLevel = null,
    decimal? SignalStrength = null,
    DateTimeOffset? NextCalibrationDate = null
);