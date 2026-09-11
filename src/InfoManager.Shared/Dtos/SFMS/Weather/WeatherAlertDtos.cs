namespace InfoManager.Shared.Dtos.SFMS.Weather;

/// <summary>
/// Thông tin chi tiết cảnh báo thời tiết
/// </summary>
public record WeatherAlertDto(
    /// <summary>Khóa chính (UUID) của cảnh báo</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Loại cảnh báo (mã)</summary>
    WeatherAlertType AlertType,

    /// <summary>Loại cảnh báo (mã)</summary>
    string AlertTypeName,

    /// <summary>Mô tả cảnh báo</summary>
    string Description,

    /// <summary>Mức độ nghiêm trọng (mã)</summary>
    AlertSeverity Severity,

    /// <summary>Mức độ nghiêm trọng (mã)</summary>
    string SeverityName,

    /// <summary>Thời gian bắt đầu dự kiến</summary>
    DateTimeOffset? ExpectedStartTime,

    /// <summary>Thời gian kết thúc dự kiến</summary>
    DateTimeOffset? ExpectedEndTime,

    /// <summary>Thời điểm phát cảnh báo</summary>
    DateTimeOffset AlertIssuedTime,

    /// <summary>Trạng thái cảnh báo (mã)</summary>
    WeatherAlertStatus? Status,

    /// <summary>Trạng thái cảnh báo (mã)</summary>
    string StatusName,

    /// <summary>Tác động tới nông nghiệp</summary>
    string? FarmingImpact,

    /// <summary>Hành động khuyến nghị</summary>
    string? RecommendedActions,

    /// <summary>Nguồn phát cảnh báo</summary>
    string? Source,

    /// <summary>Ngày tạo bản ghi</summary>
    DateTimeOffset? Created
);

/// <summary>
/// Thông tin tóm tắt cảnh báo thời tiết (dùng cho danh sách)
/// </summary>
public record WeatherAlertSummaryDto(
    /// <summary>Khóa chính (UUID) của cảnh báo</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Loại cảnh báo (mã)</summary>
    string AlertTypeName,

    /// <summary>Mức độ nghiêm trọng (mã)</summary>
    string SeverityName,

    /// <summary>Thời điểm phát cảnh báo</summary>
    DateTimeOffset AlertIssuedTime,

    /// <summary>Trạng thái cảnh báo (mã)</summary>
    string StatusName,

    /// <summary>Tóm tắt mô tả ngắn</summary>
    string Description
);

/// <summary>
/// Yêu cầu tạo cảnh báo thời tiết mới
/// </summary>
public record CreateWeatherAlertRequest(
    /// <summary>Khóa chính (UUID) của cảnh báo (có thể do client sinh hoặc server ghi đè)</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Loại cảnh báo (mã)</summary>
    WeatherAlertType AlertType,

    /// <summary>Mô tả cảnh báo</summary>
    string Description,

    /// <summary>Mức độ nghiêm trọng (mã)</summary>
    AlertSeverity Severity,

    /// <summary>Thời gian bắt đầu dự kiến</summary>
    DateTimeOffset? ExpectedStartTime,

    /// <summary>Thời gian kết thúc dự kiến</summary>
    DateTimeOffset? ExpectedEndTime,

    /// <summary>Thời điểm phát cảnh báo</summary>
    DateTimeOffset AlertIssuedTime,

    /// <summary>Trạng thái cảnh báo (mã)</summary>
    WeatherAlertStatus? Status,

    /// <summary>Tác động tới nông nghiệp</summary>
    string? FarmingImpact,

    /// <summary>Hành động khuyến nghị</summary>
    string? RecommendedActions,

    /// <summary>Nguồn phát cảnh báo</summary>
    string? Source
);

/// <summary>
/// Yêu cầu cập nhật cảnh báo thời tiết
/// </summary>
public record UpdateWeatherAlertRequest(
    /// <summary>Khóa chính (UUID) của cảnh báo cần cập nhật</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string? FarmId,

    /// <summary>Loại cảnh báo (mã)</summary>
    WeatherAlertType? AlertType,

    /// <summary>Mô tả cảnh báo</summary>
    string? Description,

    /// <summary>Mức độ nghiêm trọng (mã)</summary>
    AlertSeverity? Severity,

    /// <summary>Thời gian bắt đầu dự kiến</summary>
    DateTimeOffset? ExpectedStartTime,

    /// <summary>Thời gian kết thúc dự kiến</summary>
    DateTimeOffset? ExpectedEndTime,

    /// <summary>Thời điểm phát cảnh báo</summary>
    DateTimeOffset? AlertIssuedTime,

    /// <summary>Trạng thái cảnh báo (mã)</summary>
    WeatherAlertStatus? Status,

    /// <summary>Tác động tới nông nghiệp</summary>
    string? FarmingImpact,

    /// <summary>Hành động khuyến nghị</summary>
    string? RecommendedActions,

    /// <summary>Nguồn phát cảnh báo</summary>
    string? Source
);