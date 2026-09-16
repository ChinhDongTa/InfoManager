namespace InfoManager.Shared.Dtos.SFMS.Weather;

/// <summary>
/// Thông tin chi tiết dự báo thời tiết
/// </summary>
public record WeatherForecastDto(
    /// <summary>Khóa chính (UUID) của bản ghi dự báo</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm dự báo</summary>
    DateTimeOffset ForecastTime,

    /// <summary>Nhiệt độ dự báo (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu dự báo (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa dự báo (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm dự báo (%)</summary>
    decimal? Humidity,

    /// <summary>Xác suất có mưa (%)</summary>
    decimal? PrecipitationProbability,

    /// <summary>Lượng mưa dự kiến (mm)</summary>
    decimal? ExpectedRainfall,

    /// <summary>Tốc độ gió dự báo (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió dự báo (độ)</summary>
    decimal? WindDirection,

    /// <summary>Độ che phủ mây dự kiến (%)</summary>
    decimal? CloudCover,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời dự báo (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV dự báo</summary>
    decimal? UVIndex,

    /// <summary>Dự báo điều kiện thời tiết (mưa, nắng, mây, ...)</summary>
    string? ForecastedCondition,

    /// <summary>Mức độ tin cậy của dự báo (0-100%)</summary>
    decimal? Confidence,

    /// <summary>Nguồn dự báo (Weather API, Weather Station, ...)</summary>
    string? ForecastSource,

    /// <summary>Ngày giờ phát hành dự báo</summary>
    DateTimeOffset? ForecastIssuedDate,

    /// <summary>Cảnh báo / thông báo liên quan (nếu có)</summary>
    string? Alerts,

    /// <summary>Đánh giá độ chính xác của dự báo (sau khi có dữ liệu thực tế)</summary>
    decimal? AccuracyRating,

    /// <summary>Ngày tạo bản ghi</summary>
    DateTimeOffset? Created
);

/// <summary>
/// Thông tin tóm tắt dự báo thời tiết (dùng cho danh sách)
/// </summary>
public record WeatherForecastSummaryDto(
    /// <summary>Khóa chính (UUID) của bản ghi dự báo</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm dự báo</summary>
    DateTimeOffset ForecastTime,

    /// <summary>Nhiệt độ dự báo (°C)</summary>
    decimal? Temperature,

    /// <summary>Xác suất có mưa (%)</summary>
    decimal? PrecipitationProbability,

    /// <summary>Lượng mưa dự kiến (mm)</summary>
    decimal? ExpectedRainfall,

    /// <summary>Tốc độ gió dự báo (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Dự báo điều kiện thời tiết (tóm tắt)</summary>
    string? ForecastedCondition,

    /// <summary>Nguồn dự báo</summary>
    string? ForecastSource
);

/// <summary>
/// Yêu cầu tạo bản ghi dự báo thời tiết mới
/// </summary>
public record CreateWeatherForecastRequest(
    /// <summary>Khóa chính (UUID) của bản ghi (có thể do client sinh hoặc server ghi đè)</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string FarmId,

    /// <summary>Thời điểm dự báo</summary>
    DateTimeOffset ForecastTime,

    /// <summary>Nhiệt độ dự báo (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu dự báo (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa dự báo (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm dự báo (%)</summary>
    decimal? Humidity,

    /// <summary>Xác suất có mưa (%)</summary>
    decimal? PrecipitationProbability,

    /// <summary>Lượng mưa dự kiến (mm)</summary>
    decimal? ExpectedRainfall,

    /// <summary>Tốc độ gió dự báo (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió dự báo (độ)</summary>
    decimal? WindDirection,

    /// <summary>Độ che phủ mây dự kiến (%)</summary>
    decimal? CloudCover,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời dự báo (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV dự báo</summary>
    decimal? UVIndex,

    /// <summary>Dự báo điều kiện thời tiết</summary>
    string? ForecastedCondition,

    /// <summary>Mức độ tin cậy của dự báo (0-100%)</summary>
    decimal? Confidence,

    /// <summary>Nguồn dự báo</summary>
    string? ForecastSource,

    /// <summary>Ngày giờ phát hành dự báo</summary>
    DateTimeOffset? ForecastIssuedDate,

    /// <summary>Cảnh báo / thông báo liên quan</summary>
    string? Alerts,

    /// <summary>Đánh giá độ chính xác của dự báo</summary>
    decimal? AccuracyRating
);

/// <summary>
/// Yêu cầu cập nhật bản ghi dự báo thời tiết
/// </summary>
public record UpdateWeatherForecastRequest(
    /// <summary>Khóa chính (UUID) của bản ghi cần cập nhật</summary>
    string Id,

    /// <summary>ID nông trại liên quan</summary>
    string? FarmId,

    /// <summary>Thời điểm dự báo</summary>
    DateTimeOffset? ForecastTime,

    /// <summary>Nhiệt độ dự báo (°C)</summary>
    decimal? Temperature,

    /// <summary>Nhiệt độ tối thiểu dự báo (°C)</summary>
    decimal? MinTemperature,

    /// <summary>Nhiệt độ tối đa dự báo (°C)</summary>
    decimal? MaxTemperature,

    /// <summary>Độ ẩm dự báo (%)</summary>
    decimal? Humidity,

    /// <summary>Xác suất có mưa (%)</summary>
    decimal? PrecipitationProbability,

    /// <summary>Lượng mưa dự kiến (mm)</summary>
    decimal? ExpectedRainfall,

    /// <summary>Tốc độ gió dự báo (km/h)</summary>
    decimal? WindSpeed,

    /// <summary>Hướng gió dự báo (độ)</summary>
    decimal? WindDirection,

    /// <summary>Độ che phủ mây dự kiến (%)</summary>
    decimal? CloudCover,

    /// <summary>Áp suất khí quyển (hPa)</summary>
    decimal? Pressure,

    /// <summary>Bức xạ mặt trời dự báo (W/m²)</summary>
    decimal? SolarRadiation,

    /// <summary>Chỉ số UV dự báo</summary>
    decimal? UVIndex,

    /// <summary>Dự báo điều kiện thời tiết</summary>
    string? ForecastedCondition,

    /// <summary>Mức độ tin cậy của dự báo (0-100%)</summary>
    decimal? Confidence,

    /// <summary>Nguồn dự báo</summary>
    string? ForecastSource,

    /// <summary>Ngày giờ phát hành dự báo</summary>
    DateTimeOffset? ForecastIssuedDate,

    /// <summary>Cảnh báo / thông báo liên quan</summary>
    string? Alerts,

    /// <summary>Đánh giá độ chính xác của dự báo</summary>
    decimal? AccuracyRating
);