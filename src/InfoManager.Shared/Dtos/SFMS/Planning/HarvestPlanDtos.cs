namespace InfoManager.Shared.Dtos.SFMS.Planning;

/// <summary>
/// Chi tiết kế hoạch thu hoạch
/// </summary>
public record HarvestPlanDto(
    string Id,

    /// <summary>ID chu kỳ trồng</summary>
    string CropCycleId,

    /// <summary>Tên chu kỳ trồng</summary>
    string? CropCycleName,

    /// <summary>Tên kế hoạch</summary>
    string PlanName,

    /// <summary>Ngày bắt đầu thu dự kiến</summary>
    DateTimeOffset ExpectedStartDate,

    /// <summary>Ngày kết thúc thu dự kiến</summary>
    DateTimeOffset? ExpectedEndDate,

    /// <summary>Phương pháp thu hoạch</summary>
    string? HarvestMethod,

    /// <summary>Sản lượng kỳ vọng</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị sản lượng</summary>
    string? YieldUnit,

    /// <summary>Nhu cầu nhân công (ngày công)</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng</summary>
    string? EquipmentRequired,

    /// <summary>Kế hoạch sơ chế sau thu</summary>
    string? PostHarvestProcessing,

    /// <summary>Nhu cầu kho chứa</summary>
    string? StorageRequirement,

    /// <summary>Thời gian lưu kho (ngày)</summary>
    int? StorageDuration,

    /// <summary>Kế hoạch vận chuyển</summary>
    string? TransportationPlan,

    /// <summary>Ngày bán dự kiến</summary>
    DateTimeOffset? ExpectedSaleDate,

    /// <summary>Khách hàng mục tiêu</summary>
    string? TargetBuyer,

    /// <summary>Giá bán dự kiến</summary>
    decimal? ExpectedSellingPrice,

    /// <summary>Trạng thái</summary>
    PlanStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Đánh giá rủi ro</summary>
    string? RiskAssessment,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Kế hoạch thu hoạch dùng cho danh sách
/// </summary>
public record HarvestPlanSummaryDto(
    string Id,

    /// <summary>Tên kế hoạch</summary>
    string PlanName,

    /// <summary>Tên chu kỳ</summary>
    string? CropCycleName,

    /// <summary>Ngày bắt đầu thu dự kiến</summary>
    DateTimeOffset ExpectedStartDate,

    /// <summary>Sản lượng kỳ vọng</summary>
    decimal? ExpectedYield,

    /// <summary>Trạng thái</summary>
    PlanStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName
);

/// <summary>
/// Request tạo kế hoạch thu hoạch
/// </summary>
public record CreateHarvestPlanRequest(
    /// <summary>ID chu kỳ trồng. Bắt buộc.</summary>
    string CropCycleId,

    /// <summary>Tên kế hoạch. Bắt buộc, tối đa 200 ký tự.</summary>
    string PlanName,

    /// <summary>Ngày bắt đầu thu dự kiến. Bắt buộc.</summary>
    DateTimeOffset ExpectedStartDate,

    /// <summary>Ngày kết thúc thu dự kiến. Phải ≥ ngày bắt đầu nếu có.</summary>
    DateTimeOffset? ExpectedEndDate,

    /// <summary>Phương pháp thu hoạch. Tối đa 100 ký tự.</summary>
    string? HarvestMethod,

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị sản lượng. Tối đa 50 ký tự.</summary>
    string? YieldUnit,

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    string? EquipmentRequired,

    /// <summary>Kế hoạch sơ chế. Tối đa 1000 ký tự.</summary>
    string? PostHarvestProcessing,

    /// <summary>Nhu cầu kho chứa. Tối đa 500 ký tự.</summary>
    string? StorageRequirement,

    /// <summary>Thời gian lưu kho (ngày). ≥ 0.</summary>
    int? StorageDuration,

    /// <summary>Kế hoạch vận chuyển. Tối đa 500 ký tự.</summary>
    string? TransportationPlan,

    /// <summary>Ngày bán dự kiến.</summary>
    DateTimeOffset? ExpectedSaleDate,

    /// <summary>Khách hàng mục tiêu. Tối đa 300 ký tự.</summary>
    string? TargetBuyer,

    /// <summary>Giá bán dự kiến. ≥ 0.</summary>
    decimal? ExpectedSellingPrice,

    /// <summary>Trạng thái. Mặc định Draft.</summary>
    PlanStatus Status = PlanStatus.Draft,

    /// <summary>Đánh giá rủi ro. Tối đa 1000 ký tự.</summary>
    string? RiskAssessment = null,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes = null
);

/// <summary>
/// Request cập nhật kế hoạch thu hoạch. Field null = không đổi.
/// </summary>
public record UpdateHarvestPlanRequest(
    /// <summary>ID kế hoạch. Bắt buộc.</summary>
    string Id,

    /// <summary>ID chu kỳ trồng.</summary>
    string? CropCycleId,

    /// <summary>Tên kế hoạch. Tối đa 200 ký tự.</summary>
    string? PlanName,

    /// <summary>Ngày bắt đầu thu dự kiến.</summary>
    DateTimeOffset? ExpectedStartDate,

    /// <summary>Ngày kết thúc thu dự kiến.</summary>
    DateTimeOffset? ExpectedEndDate,

    /// <summary>Phương pháp thu hoạch. Tối đa 100 ký tự.</summary>
    string? HarvestMethod,

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    decimal? ExpectedYield,

    /// <summary>Đơn vị sản lượng. Tối đa 50 ký tự.</summary>
    string? YieldUnit,

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    string? EquipmentRequired,

    /// <summary>Kế hoạch sơ chế. Tối đa 1000 ký tự.</summary>
    string? PostHarvestProcessing,

    /// <summary>Nhu cầu kho chứa. Tối đa 500 ký tự.</summary>
    string? StorageRequirement,

    /// <summary>Thời gian lưu kho (ngày). ≥ 0.</summary>
    int? StorageDuration,

    /// <summary>Kế hoạch vận chuyển. Tối đa 500 ký tự.</summary>
    string? TransportationPlan,

    /// <summary>Ngày bán dự kiến.</summary>
    DateTimeOffset? ExpectedSaleDate,

    /// <summary>Khách hàng mục tiêu. Tối đa 300 ký tự.</summary>
    string? TargetBuyer,

    /// <summary>Giá bán dự kiến. ≥ 0.</summary>
    decimal? ExpectedSellingPrice,

    /// <summary>Trạng thái.</summary>
    PlanStatus? Status,

    /// <summary>Đánh giá rủi ro. Tối đa 1000 ký tự.</summary>
    string? RiskAssessment,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes
);