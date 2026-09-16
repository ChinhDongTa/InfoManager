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
    string? Model,
    string? SerialNumber,
    string FieldId,
    string? DeviceId,
    decimal? Latitude,
    decimal? Longitude,
    decimal? Depth,
    DeviceStatus Status,
    DateTimeOffset InstallationDate,
    DateTimeOffset? NextCalibrationDate
);

public record UpdateSensorRequest(
    string Id,
    string? Name,
    SensorType? SensorType,
    string? Model,
    string? SerialNumber,
    string? FieldId,
    string? DeviceId,
    decimal? Latitude,
    decimal? Longitude,
    decimal? Depth,
    DeviceStatus? Status,
    DateTimeOffset? LastReadingTime,
    decimal? BatteryLevel,
    decimal? SignalStrength,
    DateTimeOffset? NextCalibrationDate
);