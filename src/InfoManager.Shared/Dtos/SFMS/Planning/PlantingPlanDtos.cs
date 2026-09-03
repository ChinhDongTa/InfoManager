namespace InfoManager.Shared.Dtos.SFMS.Planning;

/// <summary>
/// Chi tiết kế hoạch trồng
/// </summary>
public record PlantingPlanDto(
    string Id,

    /// <summary>ID chu kỳ trồng</summary>
    string CropCycleId,

    /// <summary>Tên chu kỳ trồng</summary>
    string? CropCycleName,

    /// <summary>Tên kế hoạch</summary>
    string PlanName,

    /// <summary>Phân bổ thửa ruộng</summary>
    string? FieldAllocation,

    /// <summary>Phương pháp trồng</summary>
    string? PlantingMethod,

    /// <summary>Lượng giống cần</summary>
    decimal? SeedQuantityRequired,

    /// <summary>Nguồn giống</summary>
    string? SeedSource,

    /// <summary>Chuẩn bị luống / đất gieo</summary>
    string? SeedbedPreparation,

    /// <summary>Tỷ lệ nảy mầm kỳ vọng (%)</summary>
    decimal? ExpectedGerminationRate,

    /// <summary>Kế hoạch tưới</summary>
    string? IrrigationPlan,

    /// <summary>Kế hoạch bón phân</summary>
    string? FertilizationPlan,

    /// <summary>Nhu cầu nhân công (ngày công)</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng</summary>
    string? EquipmentRequired,

    /// <summary>Trạng thái</summary>
    PlanStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Kế hoạch trồng dùng cho danh sách
/// </summary>
public record PlantingPlanSummaryDto(
    string Id,

    /// <summary>Tên kế hoạch</summary>
    string PlanName,

    /// <summary>Tên chu kỳ</summary>
    string? CropCycleName,

    /// <summary>Phương pháp trồng</summary>
    string? PlantingMethod,

    /// <summary>Lượng giống cần</summary>
    decimal? SeedQuantityRequired,

    /// <summary>Trạng thái</summary>
    PlanStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName
);

/// <summary>
/// Request tạo kế hoạch trồng
/// </summary>
public record CreatePlantingPlanRequest(
    /// <summary>ID chu kỳ trồng. Bắt buộc.</summary>
    string CropCycleId,

    /// <summary>Tên kế hoạch. Bắt buộc, tối đa 200 ký tự.</summary>
    string PlanName,

    /// <summary>Phân bổ thửa ruộng. Tối đa 1000 ký tự.</summary>
    string? FieldAllocation,

    /// <summary>Phương pháp trồng. Tối đa 100 ký tự.</summary>
    string? PlantingMethod,

    /// <summary>Lượng giống cần. ≥ 0.</summary>
    decimal? SeedQuantityRequired,

    /// <summary>Nguồn giống. Tối đa 200 ký tự.</summary>
    string? SeedSource,

    /// <summary>Chuẩn bị luống / đất gieo. Tối đa 500 ký tự.</summary>
    string? SeedbedPreparation,

    /// <summary>Tỷ lệ nảy mầm kỳ vọng (%). 0–100.</summary>
    decimal? ExpectedGerminationRate,

    /// <summary>Kế hoạch tưới. Tối đa 500 ký tự.</summary>
    string? IrrigationPlan,

    /// <summary>Kế hoạch bón phân. Tối đa 500 ký tự.</summary>
    string? FertilizationPlan,

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    string? EquipmentRequired,

    /// <summary>Trạng thái. Mặc định Draft.</summary>
    PlanStatus Status = PlanStatus.Draft,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes = null
);

/// <summary>
/// Request cập nhật kế hoạch trồng. Field null = không đổi.
/// </summary>
public record UpdatePlantingPlanRequest(
    /// <summary>ID kế hoạch. Bắt buộc.</summary>
    string Id,

    /// <summary>ID chu kỳ trồng.</summary>
    string? CropCycleId,

    /// <summary>Tên kế hoạch. Tối đa 200 ký tự.</summary>
    string? PlanName,

    /// <summary>Phân bổ thửa ruộng. Tối đa 1000 ký tự.</summary>
    string? FieldAllocation,

    /// <summary>Phương pháp trồng. Tối đa 100 ký tự.</summary>
    string? PlantingMethod,

    /// <summary>Lượng giống cần. ≥ 0.</summary>
    decimal? SeedQuantityRequired,

    /// <summary>Nguồn giống. Tối đa 200 ký tự.</summary>
    string? SeedSource,

    /// <summary>Chuẩn bị luống / đất gieo. Tối đa 500 ký tự.</summary>
    string? SeedbedPreparation,

    /// <summary>Tỷ lệ nảy mầm kỳ vọng (%). 0–100.</summary>
    decimal? ExpectedGerminationRate,

    /// <summary>Kế hoạch tưới. Tối đa 500 ký tự.</summary>
    string? IrrigationPlan,

    /// <summary>Kế hoạch bón phân. Tối đa 500 ký tự.</summary>
    string? FertilizationPlan,

    /// <summary>Nhu cầu nhân công. ≥ 0.</summary>
    decimal? LaborRequirement,

    /// <summary>Thiết bị cần dùng. Tối đa 500 ký tự.</summary>
    string? EquipmentRequired,

    /// <summary>Trạng thái.</summary>
    PlanStatus? Status,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes
);