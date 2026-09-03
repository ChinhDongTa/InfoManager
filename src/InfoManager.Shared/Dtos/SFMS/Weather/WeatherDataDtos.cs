namespace InfoManager.Shared.Dtos.SFMS.Weather;

/// <summary>
/// Thông tin chi tiết bản ghi dữ liệu thời tiết
/// </summary>
public record WeatherDataDto(
    /// <summary>Khóa chính (UUID) của bản ghi dữ liệu</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm ghi nhận dữ liệu</summary>
    DateTimeOffset RecordingTime,

    /// <summary>Nhiệt độ (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm (%)</summary>
    decimal? Humidity,

    /// <summary>Điểm sương (°C)</summary>
    decimal? DewPoint,

    /// <summary>Lượng mưa (mm)</summary>
    decimal? Rainfall,

    /// <summary>Tốc độ gió (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió (độ)</summary>
    decimal? WindDirection,

    /// <summary>Tốc độ gió giật (km/h)</summary>
    decimal? WindGustSpeed,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV</summary>
    decimal? UVIndex,

    /// <summary>Độ che phủ mây (%)</summary>
    decimal? CloudCover,

    /// <summary>Tầm nhìn (km)</summary>
    decimal? Visibility,

    /// <summary>Mô tả điều kiện thời tiết</summary>
    string? WeatherCondition,

    /// <summary>Nguồn dữ liệu</summary>
    string? DataSource,

    /// <summary>Đánh giá chất lượng dữ liệu</summary>
    DataQuality Quality,

    /// <summary>Ngày tạo bản ghi</summary>
    DateTimeOffset? Created
);

/// <summary>
/// Thông tin tóm tắt bản ghi dữ liệu thời tiết (dùng cho danh sách)
/// </summary>
public record WeatherDataSummaryDto(
    /// <summary>Khóa chính (UUID) của bản ghi dữ liệu</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm ghi nhận</summary>
    DateTimeOffset RecordingTime,

    /// <summary>Nhiệt độ (°C)</summary>
    decimal? Temperature,

    /// <summary>Độ ẩm (%)</summary>
    decimal? Humidity,

    /// <summary>Lượng mưa (mm)</summary>
    decimal? Rainfall,

    /// <summary>Tốc độ gió (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Mô tả điều kiện thời tiết (tóm tắt)</summary>
    string? WeatherCondition,

    /// <summary>Nguồn dữ liệu</summary>
    string? DataSource
);

/// <summary>
/// Yêu cầu tạo bản ghi dữ liệu thời tiết mới
/// </summary>
public record CreateWeatherDataRequest(
    /// <summary>Khóa chính (UUID) của bản ghi (có thể do client sinh hoặc server ghi đè)</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm ghi nhận dữ liệu</summary>
    DateTimeOffset RecordingTime,

    /// <summary>Nhiệt độ (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm (%)</summary>
    decimal? Humidity,

    /// <summary>Điểm sương (°C)</summary>
    decimal? DewPoint,

    /// <summary>Lượng mưa (mm)</summary>
    decimal? Rainfall,

    /// <summary>Tốc độ gió (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió (độ)</summary>
    decimal? WindDirection,

    /// <summary>Tốc độ gió giật (km/h)</summary>
    decimal? WindGustSpeed,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV</summary>
    decimal? UVIndex,

    /// <summary>Độ che phủ mây (%)</summary>
    decimal? CloudCover,

    /// <summary>Tầm nhìn (km)</summary>
    decimal? Visibility,

    /// <summary>Mô tả điều kiện thời tiết</summary>
    string? WeatherCondition,

    /// <summary>Nguồn dữ liệu</summary>
    string? DataSource,

    /// <summary>Đánh giá chất lượng dữ liệu</summary>
    DataQuality? Quality
);

/// <summary>
/// Yêu cầu cập nhật bản ghi dữ liệu thời tiết
/// </summary>
public record UpdateWeatherDataRequest(
    /// <summary>Khóa chính (UUID) của bản ghi cần cập nhật</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string? FarmId,

    /// <summary>Thời điểm ghi nhận dữ liệu</summary>
    DateTimeOffset? RecordingTime,

    /// <summary>Nhiệt độ (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm (%)</summary>
    decimal? Humidity,

    /// <summary>Điểm sương (°C)</summary>
    decimal? DewPoint,

    /// <summary>Lượng mưa (mm)</summary>
    decimal? Rainfall,

    /// <summary>Tốc độ gió (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió (độ)</summary>
    decimal? WindDirection,

    /// <summary>Tốc độ gió giật (km/h)</summary>
    decimal? WindGustSpeed,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV</summary>
    decimal? UVIndex,

    /// <summary>Độ che phủ mây (%)</summary>
    decimal? CloudCover,

    /// <summary>Tầm nhìn (km)</summary>
    decimal? Visibility,

    /// <summary>Mô tả điều kiện thời tiết</summary>
    string? WeatherCondition,

    /// <summary>Nguồn dữ liệu</summary>
    string? DataSource,

    /// <summary>Đánh giá chất lượng dữ liệu</summary>
    DataQuality? Quality
);
