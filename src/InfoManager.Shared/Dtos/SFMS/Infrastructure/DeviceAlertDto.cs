// ======================== DeviceAlert ========================

public record DeviceAlertDto(
    string Id,
    string DeviceId,
    string? DeviceName,
     AlertType AlertType,
    string AlertTypeName,
    string Message,
     AlertSeverity Severity,
    string SeverityName,
    DateTimeOffset AlertTime,
    DateTimeOffset? ResolvedTime,
    bool IsResolved,
    string? ResolutionNotes,
    DateTimeOffset Created
);

public record DeviceAlertSummaryDto(
    string Id,
    string? DeviceName,
    string AlertTypeName,
    string Message,
    string SeverityName,
    DateTimeOffset AlertTime,
    bool IsResolved
);

public record SearchDeviceAlertsRequest(
    string? Term,
    AlertType? AlertType,
    AlertSeverity? Severity,
    bool? IsResolved,
    DateTimeOffset? StartAlertTime,
    DateTimeOffset? EndAlertTime,
    int PageNumber,
    int PageSize
);

public record CreateDeviceAlertRequest(
    string DeviceId,
    AlertType AlertType,
    string Message,
    AlertSeverity Severity,
    DateTimeOffset AlertTime,
    bool IsResolved,
    string? ResolutionNotes
);

public record UpdateDeviceAlertRequest(
    string Id,
    AlertType? AlertType,
    string? Message,
    AlertSeverity? Severity,
    DateTimeOffset? ResolvedTime,
    bool? IsResolved,
    string? ResolutionNotes
);