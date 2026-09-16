namespace InfoManager.Shared.Dtos.SFMS.Monitoring;

/// <summary>
/// Chi tiết một lần đo môi trường
/// </summary>
public record EnvironmentalReadingDto(
    string Id,

    /// <summary>ID cảm biến</summary>
    string SensorId,

    /// <summary>Tên cảm biến</summary>
    string? SensorName,

    /// <summary>ID thửa ruộng</summary>
    string? FieldId,

    /// <summary>Tên thửa ruộng</summary>
    string? FieldName,

    /// <summary>Thời điểm đo</summary>
    DateTimeOffset ReadingTime,

    /// <summary>Loại cảm biến</summary>
    SensorType SensorType,

    /// <summary>Tên loại cảm biến</summary>
    string? SensorTypeName,

    /// <summary>Giá trị đo</summary>
    decimal Value,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Chất lượng dữ liệu</summary>
    DataQuality Quality,

    /// <summary>Tên chất lượng dữ liệu</summary>
    string? QualityName,

    /// <summary>Giá trị thô</summary>
    decimal? RawValue,

    /// <summary>Có trong khoảng kỳ vọng</summary>
    bool IsWithinRange,

    /// <summary>Giá trị tối thiểu kỳ vọng</summary>
    decimal? MinExpectedValue,

    /// <summary>Giá trị tối đa kỳ vọng</summary>
    decimal? MaxExpectedValue,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Số liệu đo dùng cho danh sách / biểu đồ
/// </summary>
public record EnvironmentalReadingSummaryDto(
    string Id,

    /// <summary>Tên cảm biến</summary>
    string? SensorName,

    /// <summary>Thời điểm đo</summary>
    DateTimeOffset ReadingTime,

    /// <summary>Loại cảm biến</summary>
    SensorType SensorType,

    /// <summary>Giá trị đo</summary>
    decimal Value,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Chất lượng dữ liệu</summary>
    DataQuality Quality,

    /// <summary>Có trong khoảng kỳ vọng</summary>
    bool IsWithinRange
);

/// <summary>
/// Request ghi nhận số liệu từ cảm biến
/// </summary>
public record CreateEnvironmentalReadingRequest(
    /// <summary>ID cảm biến. Bắt buộc.</summary>
    string SensorId,

    /// <summary>Thời điểm đo. Bắt buộc.</summary>
    DateTimeOffset ReadingTime,

    /// <summary>Loại cảm biến. Bắt buộc. Nên lấy từ Sensor nếu client không gửi.</summary>
    SensorType SensorType,

    /// <summary>Giá trị đo. Bắt buộc.</summary>
    decimal Value,

    /// <summary>Đơn vị. Bắt buộc, tối đa 50 ký tự.</summary>
    string Unit,

    /// <summary>Chất lượng dữ liệu. Mặc định Good.</summary>
    DataQuality Quality,

    /// <summary>Giá trị thô trước xử lý.</summary>
    decimal? RawValue,

    /// <summary>Giá trị tối thiểu kỳ vọng.</summary>
    decimal? MinExpectedValue,

    /// <summary>Giá trị tối đa kỳ vọng.</summary>
    decimal? MaxExpectedValue,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);

/// <summary>
/// Request ghi nhận hàng loạt số liệu
/// </summary>
public record CreateEnvironmentalReadingBatchRequest(
    /// <summary>Danh sách lần đo. Bắt buộc, ít nhất 1.</summary>
    IReadOnlyList<CreateEnvironmentalReadingRequest> Readings
);

/// <summary>
/// Request sửa metadata lần đo. Field null = không đổi. Không nên sửa Value trừ hiệu chuẩn.
/// </summary>
public record UpdateEnvironmentalReadingRequest(
    /// <summary>ID lần đo. Bắt buộc.</summary>
    string Id,

    /// <summary>Chất lượng dữ liệu.</summary>
    DataQuality? Quality,

    /// <summary>Có trong khoảng kỳ vọng.</summary>
    bool? IsWithinRange,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);

/// <summary>
/// Bộ lọc truy vấn time-series
/// </summary>
public record SearchEnvironmentalReadingRequest(
    /// <summary>ID cảm biến.</summary>
    string? SensorId,

    /// <summary>ID thửa ruộng.</summary>
    string? FieldId,

    /// <summary>Loại cảm biến.</summary>
    SensorType? SensorType,

    /// <summary>Từ thời điểm.</summary>
    DateTimeOffset? FromTime,

    /// <summary>Đến thời điểm.</summary>
    DateTimeOffset? ToTime,

    /// <summary>Chất lượng dữ liệu.</summary>
    DataQuality? Quality,

    int PageNumber = 1,
    int PageSize = 100
);