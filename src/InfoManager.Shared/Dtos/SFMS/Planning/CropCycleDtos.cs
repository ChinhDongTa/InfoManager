namespace InfoManager.Shared.Dtos.SFMS.Planning;

/// <summary>
/// Chi tiết chu kỳ trồng
/// </summary>
public record CropCycleDto(
    string Id,

    /// <summary>ID nông trại</summary>
    string FarmId,

    /// <summary>Tên nông trại</summary>
    string? FarmName,

    /// <summary>Tên chu kỳ</summary>
    string CycleName,

    /// <summary>ID cây trồng</summary>
    string CropId,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>ID giống</summary>
    string? CropVarietyId,

    /// <summary>Tên giống</summary>
    string? CropVarietyName,

    /// <summary>ID lịch trồng</summary>
    string? CropScheduleId,

    /// <summary>Tên lịch trồng</summary>
    string? CropScheduleName,

    /// <summary>Năm bắt đầu</summary>
    int StartYear,

    /// <summary>Mùa vụ</summary>
    string? Season,

    /// <summary>Ngày trồng dự kiến</summary>
    DateTimeOffset? PlannedPlantingDate,

    /// <summary>Ngày thu hoạch dự kiến</summary>
    DateTimeOffset? PlannedHarvestDate,

    /// <summary>Diện tích kế hoạch (hecta)</summary>
    decimal PlannedArea,

    /// <summary>Trạng thái</summary>
    CropCycleStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Chi phí dự kiến</summary>
    decimal? EstimatedCost,

    /// <summary>Doanh thu dự kiến</summary>
    decimal? EstimatedRevenue,

    /// <summary>Lợi nhuận dự kiến</summary>
    decimal? EstimatedProfit,

    /// <summary>Sản lượng kỳ vọng</summary>
    decimal? ExpectedYield,

    /// <summary>Thị trường mục tiêu</summary>
    string? TargetMarket,

    /// <summary>Giá bán mục tiêu</summary>
    decimal? TargetSellingPrice,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Số lần trồng thuộc chu kỳ</summary>
    int PlantingCount,

    DateTimeOffset Created
);

/// <summary>
/// Chu kỳ trồng dùng cho danh sách
/// </summary>
public record CropCycleSummaryDto(
    string Id,

    /// <summary>Tên chu kỳ</summary>
    string CycleName,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Năm bắt đầu</summary>
    int StartYear,

    /// <summary>Mùa vụ</summary>
    string? Season,

    /// <summary>Diện tích kế hoạch</summary>
    decimal PlannedArea,

    /// <summary>Trạng thái</summary>
    CropCycleStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName
);

public record SearchCropCyclesRequest(string? Term,
                                     int? StartYear,
                                     CropCycleStatus? Status,
                                     int PageNumber,
                                     int PageSize);

/// <summary>
/// Request tạo chu kỳ trồng
/// </summary>
public record CreateCropCycleRequest(
    /// <summary>ID nông trại. Bắt buộc.</summary>
    string FarmId,

    /// <summary>Tên chu kỳ. Bắt buộc, tối đa 200 ký tự.</summary>
    string CycleName,

    /// <summary>ID cây trồng. Bắt buộc.</summary>
    string CropId,

    /// <summary>ID giống.</summary>
    string? CropVarietyId,

    /// <summary>ID lịch trồng.</summary>
    string? CropScheduleId,

    /// <summary>Năm bắt đầu. Bắt buộc, ví dụ 2026.</summary>
    int StartYear,

    /// <summary>Mùa vụ. Tối đa 50 ký tự.</summary>
    string? Season,

    /// <summary>Ngày trồng dự kiến.</summary>
    DateTimeOffset? PlannedPlantingDate,

    /// <summary>Ngày thu hoạch dự kiến. Phải ≥ ngày trồng nếu cả hai có giá trị.</summary>
    DateTimeOffset? PlannedHarvestDate,

    /// <summary>Diện tích kế hoạch (hecta). ≥ 0.</summary>
    decimal PlannedArea,

    /// <summary>Trạng thái. Mặc định Planned.</summary>
    CropCycleStatus Status,

    /// <summary>Chi phí dự kiến. ≥ 0.</summary>
    decimal? EstimatedCost,

    /// <summary>Doanh thu dự kiến. ≥ 0.</summary>
    decimal? EstimatedRevenue,

    /// <summary>Lợi nhuận dự kiến. Để trống thì server tính = Revenue - Cost.</summary>
    decimal? EstimatedProfit,

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    decimal? ExpectedYield,

    /// <summary>Thị trường mục tiêu. Tối đa 300 ký tự.</summary>
    string? TargetMarket,

    /// <summary>Giá bán mục tiêu. ≥ 0.</summary>
    decimal? TargetSellingPrice,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes
);

/// <summary>
/// Request cập nhật chu kỳ trồng. Field null = không đổi.
/// </summary>
public record UpdateCropCycleRequest(
    /// <summary>ID chu kỳ. Bắt buộc.</summary>
    string Id,

    /// <summary>ID nông trại.</summary>
    string? FarmId,

    /// <summary>Tên chu kỳ. Tối đa 200 ký tự.</summary>
    string? CycleName,

    /// <summary>ID cây trồng.</summary>
    string? CropId,

    /// <summary>ID giống.</summary>
    string? CropVarietyId,

    /// <summary>ID lịch trồng.</summary>
    string? CropScheduleId,

    /// <summary>Năm bắt đầu.</summary>
    int? StartYear,

    /// <summary>Mùa vụ. Tối đa 50 ký tự.</summary>
    string? Season,

    /// <summary>Ngày trồng dự kiến.</summary>
    DateTimeOffset? PlannedPlantingDate,

    /// <summary>Ngày thu hoạch dự kiến.</summary>
    DateTimeOffset? PlannedHarvestDate,

    /// <summary>Diện tích kế hoạch. ≥ 0.</summary>
    decimal? PlannedArea,

    /// <summary>Trạng thái.</summary>
    CropCycleStatus? Status,

    /// <summary>Chi phí dự kiến. ≥ 0.</summary>
    decimal? EstimatedCost,

    /// <summary>Doanh thu dự kiến. ≥ 0.</summary>
    decimal? EstimatedRevenue,

    /// <summary>Lợi nhuận dự kiến.</summary>
    decimal? EstimatedProfit,

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    decimal? ExpectedYield,

    /// <summary>Thị trường mục tiêu. Tối đa 300 ký tự.</summary>
    string? TargetMarket,

    /// <summary>Giá bán mục tiêu. ≥ 0.</summary>
    decimal? TargetSellingPrice,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes
);