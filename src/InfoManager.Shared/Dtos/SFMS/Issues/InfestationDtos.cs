namespace InfoManager.Shared.Dtos.SFMS.Issues;

/// <summary>
/// Chi tiết vụ sâu bệnh
/// </summary>
public record InfestationDto(
    string Id,

    /// <summary>ID lần trồng</summary>
    string CropPlantingId,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>ID sâu hại</summary>
    string? PestId,

    /// <summary>Tên sâu hại</summary>
    string? PestName,

    /// <summary>ID bệnh</summary>
    string? DiseaseId,

    /// <summary>Tên bệnh</summary>
    string? DiseaseName,

    /// <summary>Loại sự cố</summary>
    InfestationType InfestationType,

    /// <summary>Tên loại sự cố</summary>
    string? InfestationTypeName,

    /// <summary>Ngày phát hiện</summary>
    DateTimeOffset DetectionDate,

    /// <summary>Diện tích bị ảnh hưởng (hecta)</summary>
    decimal AffectedArea,

    /// <summary>Tỷ lệ cây bị ảnh hưởng (%)</summary>
    decimal AffectedPercentage,

    /// <summary>Mức độ nghiêm trọng</summary>
    SeverityLevel SeverityLevel,

    /// <summary>Tên mức độ nghiêm trọng</summary>
    string? SeverityLevelName,

    /// <summary>Trạng thái</summary>
    InfestationStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Biện pháp đã áp dụng</summary>
    string? TreatmentApplied,

    /// <summary>Ngày xử lý</summary>
    DateTimeOffset? TreatmentDate,

    /// <summary>Thuốc / chế phẩm đã dùng</summary>
    string? ProductUsed,

    /// <summary>Chi phí xử lý</summary>
    decimal? TreatmentCost,

    /// <summary>Hiệu quả xử lý (%)</summary>
    decimal? EffectivenessRating,

    /// <summary>Ngày kiểm soát được</summary>
    DateTimeOffset? ControlledDate,

    /// <summary>Tỷ lệ giảm năng suất (%)</summary>
    decimal? YieldLossPercentage,

    /// <summary>Thiệt hại kinh tế</summary>
    decimal? EconomicLoss,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh</summary>
    string? PhotoUrl,

    DateTimeOffset Created
);

/// <summary>
/// Sâu bệnh dùng cho danh sách
/// </summary>
public record InfestationSummaryDto(
    string Id,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên sâu / bệnh</summary>
    string? IssueName,

    /// <summary>Loại sự cố</summary>
    InfestationType InfestationType,

    /// <summary>Ngày phát hiện</summary>
    DateTimeOffset DetectionDate,

    /// <summary>Mức độ nghiêm trọng</summary>
    SeverityLevel SeverityLevel,

    /// <summary>Trạng thái</summary>
    InfestationStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName
);

/// <summary>
/// Request ghi nhận vụ sâu bệnh
/// </summary>
public record CreateInfestationRequest(
    /// <summary>ID lần trồng. Bắt buộc.</summary>
    string CropPlantingId,

    /// <summary>Loại sự cố. Bắt buộc.</summary>
    InfestationType InfestationType,

    /// <summary>ID sâu hại. Bắt buộc nếu InfestationType = Pest.</summary>
    string? PestId,

    /// <summary>ID bệnh. Bắt buộc nếu InfestationType = Disease.</summary>
    string? DiseaseId,

    /// <summary>Ngày phát hiện. Bắt buộc.</summary>
    DateTimeOffset DetectionDate,

    /// <summary>Diện tích bị ảnh hưởng (hecta). ≥ 0.</summary>
    decimal AffectedArea,

    /// <summary>Tỷ lệ cây bị ảnh hưởng (%). 0–100.</summary>
    decimal AffectedPercentage,

    /// <summary>Mức độ nghiêm trọng. Bắt buộc.</summary>
    SeverityLevel SeverityLevel,

    /// <summary>Trạng thái. Mặc định Detected.</summary>
    InfestationStatus Status,

    /// <summary>Biện pháp đã áp dụng. Tối đa 500 ký tự.</summary>
    string? TreatmentApplied,

    /// <summary>Ngày xử lý.</summary>
    DateTimeOffset? TreatmentDate,

    /// <summary>Thuốc / chế phẩm đã dùng. Tối đa 500 ký tự.</summary>
    string? ProductUsed,

    /// <summary>Chi phí xử lý. ≥ 0.</summary>
    decimal? TreatmentCost,

    /// <summary>Hiệu quả xử lý (%). 0–100.</summary>
    decimal? EffectivenessRating,

    /// <summary>Ngày kiểm soát được.</summary>
    DateTimeOffset? ControlledDate,

    /// <summary>Tỷ lệ giảm năng suất (%). 0–100.</summary>
    decimal? YieldLossPercentage,

    /// <summary>Thiệt hại kinh tế. ≥ 0.</summary>
    decimal? EconomicLoss,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);

/// <summary>
/// Request cập nhật vụ sâu bệnh. Field null = không đổi.
/// </summary>
public record UpdateInfestationRequest(
    /// <summary>ID vụ sâu bệnh. Bắt buộc.</summary>
    string Id,

    /// <summary>ID lần trồng.</summary>
    string? CropPlantingId,

    /// <summary>Loại sự cố.</summary>
    InfestationType? InfestationType,

    /// <summary>ID sâu hại.</summary>
    string? PestId,

    /// <summary>ID bệnh.</summary>
    string? DiseaseId,

    /// <summary>Ngày phát hiện.</summary>
    DateTimeOffset? DetectionDate,

    /// <summary>Diện tích bị ảnh hưởng. ≥ 0.</summary>
    decimal? AffectedArea,

    /// <summary>Tỷ lệ cây bị ảnh hưởng (%). 0–100.</summary>
    decimal? AffectedPercentage,

    /// <summary>Mức độ nghiêm trọng.</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Trạng thái.</summary>
    InfestationStatus? Status,

    /// <summary>Biện pháp đã áp dụng. Tối đa 500 ký tự.</summary>
    string? TreatmentApplied,

    /// <summary>Ngày xử lý.</summary>
    DateTimeOffset? TreatmentDate,

    /// <summary>Thuốc / chế phẩm đã dùng. Tối đa 500 ký tự.</summary>
    string? ProductUsed,

    /// <summary>Chi phí xử lý. ≥ 0.</summary>
    decimal? TreatmentCost,

    /// <summary>Hiệu quả xử lý (%). 0–100.</summary>
    decimal? EffectivenessRating,

    /// <summary>Ngày kiểm soát được.</summary>
    DateTimeOffset? ControlledDate,

    /// <summary>Tỷ lệ giảm năng suất (%). 0–100.</summary>
    decimal? YieldLossPercentage,

    /// <summary>Thiệt hại kinh tế. ≥ 0.</summary>
    decimal? EconomicLoss,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);

public record SearchInfestationsRequest(string? Term, string? CropPlantingId, InfestationType? InfestationType, InfestationStatus? Status, SeverityLevel? SeverityLevel, int PageNumber, int PageSize);