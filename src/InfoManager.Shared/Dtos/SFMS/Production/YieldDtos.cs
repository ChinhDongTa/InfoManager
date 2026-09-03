namespace InfoManager.Shared.Dtos.SFMS.Production;

/// <summary>
/// Chi tiết phân tích năng suất
/// </summary>
public record YieldDto(
    string Id,

    /// <summary>ID lần trồng</summary>
    string CropPlantingId,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>ID đợt thu hoạch</summary>
    string? HarvestId,

    /// <summary>Ngày thu hoạch</summary>
    DateTimeOffset? HarvestDate,

    /// <summary>Sản lượng thực tế</summary>
    decimal ActualYield,

    /// <summary>Sản lượng kỳ vọng</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Năng suất / hecta</summary>
    decimal YieldPerHectare,

    /// <summary>Điểm chất lượng (%)</summary>
    decimal? QualityRating,

    /// <summary>Tỷ lệ hao hụt (%)</summary>
    decimal? WastePercentage,

    /// <summary>Chênh lệch so với kỳ vọng (%)</summary>
    decimal? YieldVariance,

    /// <summary>Số ngày sinh trưởng</summary>
    int? GrowthDays,

    /// <summary>Chi phí sản xuất</summary>
    decimal? ProductionCost,

    /// <summary>Doanh thu</summary>
    decimal? Revenue,

    /// <summary>Lợi nhuận</summary>
    decimal? Profit,

    /// <summary>ROI (%)</summary>
    decimal? ROI,

    /// <summary>Yếu tố ảnh hưởng</summary>
    string? AffectingFactors,

    /// <summary>Phân tích</summary>
    string? Analysis,

    /// <summary>Khuyến nghị vụ sau</summary>
    string? Recommendations,

    DateTimeOffset Created
);

/// <summary>
/// Năng suất dùng cho danh sách
/// </summary>
public record YieldSummaryDto(
    string Id,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Sản lượng thực tế</summary>
    decimal ActualYield,

    /// <summary>Sản lượng kỳ vọng</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Năng suất / hecta</summary>
    decimal YieldPerHectare,

    /// <summary>Chênh lệch (%)</summary>
    decimal? YieldVariance,

    /// <summary>Lợi nhuận</summary>
    decimal? Profit
);

/// <summary>
/// Request tạo bản phân tích năng suất
/// </summary>
public record CreateYieldRequest(
    /// <summary>ID lần trồng. Bắt buộc.</summary>
    string CropPlantingId,

    /// <summary>ID đợt thu hoạch. Tùy chọn.</summary>
    string? HarvestId,

    /// <summary>Sản lượng thực tế. Bắt buộc, ≥ 0.</summary>
    decimal ActualYield,

    /// <summary>Sản lượng kỳ vọng. ≥ 0. Để trống thì lấy từ CropSchedule.ExpectedYield.</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị. Bắt buộc, tối đa 50 ký tự.</summary>
    string Unit,

    /// <summary>Năng suất / hecta. ≥ 0. Để trống thì server tính từ ActualYield / diện tích trồng.</summary>
    decimal? YieldPerHectare,

    /// <summary>Điểm chất lượng (%). 0–100.</summary>
    decimal? QualityRating,

    /// <summary>Tỷ lệ hao hụt (%). 0–100.</summary>
    decimal? WastePercentage,

    /// <summary>Chênh lệch (%). Để trống thì server tính = (Actual - Expected) / Expected × 100.</summary>
    decimal? YieldVariance,

    /// <summary>Số ngày sinh trưởng. ≥ 0. Để trống thì server tính từ PlantingDate → HarvestDate.</summary>
    int? GrowthDays,

    /// <summary>Chi phí sản xuất. ≥ 0.</summary>
    decimal? ProductionCost,

    /// <summary>Doanh thu. ≥ 0.</summary>
    decimal? Revenue,

    /// <summary>Lợi nhuận. Để trống thì server tính = Revenue - ProductionCost.</summary>
    decimal? Profit,

    /// <summary>ROI (%). Để trống thì server tính = Profit / ProductionCost × 100.</summary>
    decimal? ROI,

    /// <summary>Yếu tố ảnh hưởng. Tối đa 1000 ký tự.</summary>
    string? AffectingFactors,

    /// <summary>Phân tích. Tối đa 1000 ký tự.</summary>
    string? Analysis,

    /// <summary>Khuyến nghị vụ sau. Tối đa 1000 ký tự.</summary>
    string? Recommendations
);

/// <summary>
/// Request cập nhật phân tích năng suất. Field null = không đổi.
/// </summary>
public record UpdateYieldRequest(
    /// <summary>ID bản ghi năng suất. Bắt buộc.</summary>
    string Id,

    /// <summary>ID lần trồng.</summary>
    string? CropPlantingId,

    /// <summary>ID đợt thu hoạch.</summary>
    string? HarvestId,

    /// <summary>Sản lượng thực tế. ≥ 0.</summary>
    decimal? ActualYield,

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị. Tối đa 50 ký tự.</summary>
    string? Unit,

    /// <summary>Năng suất / hecta. ≥ 0.</summary>
    decimal? YieldPerHectare,

    /// <summary>Điểm chất lượng (%). 0–100.</summary>
    decimal? QualityRating,

    /// <summary>Tỷ lệ hao hụt (%). 0–100.</summary>
    decimal? WastePercentage,

    /// <summary>Chênh lệch (%).</summary>
    decimal? YieldVariance,

    /// <summary>Số ngày sinh trưởng. ≥ 0.</summary>
    int? GrowthDays,

    /// <summary>Chi phí sản xuất. ≥ 0.</summary>
    decimal? ProductionCost,

    /// <summary>Doanh thu. ≥ 0.</summary>
    decimal? Revenue,

    /// <summary>Lợi nhuận.</summary>
    decimal? Profit,

    /// <summary>ROI (%).</summary>
    decimal? ROI,

    /// <summary>Yếu tố ảnh hưởng. Tối đa 1000 ký tự.</summary>
    string? AffectingFactors,

    /// <summary>Phân tích. Tối đa 1000 ký tự.</summary>
    string? Analysis,

    /// <summary>Khuyến nghị vụ sau. Tối đa 1000 ký tự.</summary>
    string? Recommendations
);