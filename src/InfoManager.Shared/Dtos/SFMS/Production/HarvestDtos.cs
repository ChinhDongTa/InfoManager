namespace InfoManager.Shared.Dtos.SFMS.Production;

/// <summary>
/// Chi tiết thu hoạch
/// </summary>
public record HarvestDto(
    string Id,

    /// <summary>ID lần trồng</summary>
    string CropPlantingId,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Tên thửa ruộng</summary>
    string? FieldName,

    /// <summary>Ngày thu hoạch</summary>
    DateTimeOffset HarvestDate,

    /// <summary>Phương pháp thu hoạch</summary>
    string? HarvestMethod,

    /// <summary>Diện tích đã thu (hecta)</summary>
    decimal HarvestedArea,

    /// <summary>Tổng sản lượng</summary>
    decimal TotalQuantity,

    /// <summary>Đơn vị sản lượng</summary>
    string QuantityUnit,

    /// <summary>Năng suất / hecta</summary>
    decimal? YieldPerHectare,

    /// <summary>Phân loại chất lượng</summary>
    string? QualityGrade,

    /// <summary>Người / tổ thu hoạch</summary>
    string? HarvesterName,

    /// <summary>Điều kiện thời tiết</summary>
    string? WeatherCondition,

    /// <summary>Tỷ lệ thất thoát (%)</summary>
    decimal? LossPercentage,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh</summary>
    string? PhotoUrl,

    /// <summary>Số sản phẩm tạo từ đợt thu</summary>
    int ProductCount,

    DateTimeOffset Created
);

/// <summary>
/// Thu hoạch dùng cho danh sách
/// </summary>
public record HarvestSummaryDto(
    string Id,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Ngày thu hoạch</summary>
    DateTimeOffset HarvestDate,

    /// <summary>Tổng sản lượng</summary>
    decimal TotalQuantity,

    /// <summary>Đơn vị</summary>
    string QuantityUnit,

    /// <summary>Năng suất / hecta</summary>
    decimal? YieldPerHectare,

    /// <summary>Phân loại chất lượng</summary>
    string? QualityGrade
);

/// <summary>
/// Request tạo đợt thu hoạch
/// </summary>
public record CreateHarvestRequest(
    /// <summary>ID lần trồng. Bắt buộc.</summary>
    string CropPlantingId,

    /// <summary>Ngày thu hoạch. Bắt buộc.</summary>
    DateTimeOffset HarvestDate,

    /// <summary>Phương pháp thu hoạch. Tối đa 50 ký tự.</summary>
    string? HarvestMethod,

    /// <summary>Diện tích đã thu (hecta). Bắt buộc, > 0.</summary>
    decimal HarvestedArea,

    /// <summary>Tổng sản lượng. Bắt buộc, > 0.</summary>
    decimal TotalQuantity,

    /// <summary>Đơn vị sản lượng. Bắt buộc, tối đa 50 ký tự.</summary>
    string QuantityUnit,

    /// <summary>Năng suất / hecta. Không âm. Để trống thì server tự tính = TotalQuantity / HarvestedArea.</summary>
    decimal? YieldPerHectare,

    /// <summary>Phân loại chất lượng. Tối đa 10 ký tự.</summary>
    string? QualityGrade,

    /// <summary>Người / tổ thu hoạch. Tối đa 200 ký tự.</summary>
    string? HarvesterName,

    /// <summary>Điều kiện thời tiết. Tối đa 200 ký tự.</summary>
    string? WeatherCondition,

    /// <summary>Tỷ lệ thất thoát (%). 0–100.</summary>
    decimal? LossPercentage,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);

/// <summary>
/// Request cập nhật đợt thu hoạch. Field null = không đổi.
/// </summary>
public record UpdateHarvestRequest(
    /// <summary>ID thu hoạch. Bắt buộc.</summary>
    string Id,

    /// <summary>ID lần trồng.</summary>
    string? CropPlantingId,

    /// <summary>Ngày thu hoạch.</summary>
    DateTimeOffset? HarvestDate,

    /// <summary>Phương pháp thu hoạch. Tối đa 50 ký tự.</summary>
    string? HarvestMethod,

    /// <summary>Diện tích đã thu. > 0.</summary>
    decimal? HarvestedArea,

    /// <summary>Tổng sản lượng. > 0.</summary>
    decimal? TotalQuantity,

    /// <summary>Đơn vị sản lượng. Tối đa 50 ký tự.</summary>
    string? QuantityUnit,

    /// <summary>Năng suất / hecta. Không âm.</summary>
    decimal? YieldPerHectare,

    /// <summary>Phân loại chất lượng. Tối đa 10 ký tự.</summary>
    string? QualityGrade,

    /// <summary>Người / tổ thu hoạch. Tối đa 200 ký tự.</summary>
    string? HarvesterName,

    /// <summary>Điều kiện thời tiết. Tối đa 200 ký tự.</summary>
    string? WeatherCondition,

    /// <summary>Tỷ lệ thất thoát (%). 0–100.</summary>
    decimal? LossPercentage,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);
