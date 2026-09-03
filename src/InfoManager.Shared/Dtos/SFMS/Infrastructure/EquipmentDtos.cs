namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

/// <summary>
/// Thông tin chi tiết thiết bị
/// </summary>
public record EquipmentDto(
    /// <summary>Khóa chính (UUID) của thiết bị</summary>
    string Id,

    /// <summary>Tên thiết bị</summary>
    string? Name,

    /// <summary>Loại thiết bị (Tractor, Pump, Sprayer...)</summary>
    string? EquipmentTypeName,

    /// <summary>ID nông trại liên kết</summary>
    string? FarmId,
    string? FarmName,

    /// <summary>Tên nhà sản xuất</summary>
    string? Manufacturer,

    /// <summary>Số model</summary>
    string? Model,

    /// <summary>Số serial</summary>
    string? SerialNumber,

    /// <summary>Công suất (HP)</summary>
    decimal? PowerRating,

    /// <summary>Thông số kỹ thuật / dung tích</summary>
    string? Specifications,

    /// <summary>Ngày mua</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Giá mua</summary>
    decimal? PurchaseCost,

    /// <summary>Giá trị hiện tại / giá trị sổ sách</summary>
    decimal? CurrentValue,

    /// <summary>Trạng thái thiết bị (Active, Idle, UnderMaintenance, Retired)</summary>
    string? StatusName,

    /// <summary>Số giờ vận hành</summary>
    decimal? OperatingHours,

    /// <summary>Ngày bảo trì gần nhất</summary>
    DateTimeOffset? LastMaintenanceDate,

    /// <summary>Ngày bảo trì kế tiếp dự kiến</summary>
    DateTimeOffset? NextMaintenanceDate,

    /// <summary>Vị trí lưu trữ / kho</summary>
    string? StorageLocation,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Ngày tạo bản ghi</summary>
    DateTimeOffset? Created
);

/// <summary>
/// Thông tin tóm tắt thiết bị (dùng cho danh sách / bảng)
/// </summary>
public record EquipmentSummaryDto(
    /// <summary>Khóa chính (UUID) của thiết bị</summary>
    string Id,

    /// <summary>Tên thiết bị</summary>
    string? Name,

    /// <summary>Loại thiết bị</summary>
    string? EquipmentTypeName,

    /// <summary>ID nông trại liên kết</summary>
    string? FarmName,

    /// <summary>Trạng thái thiết bị (mã)</summary>
    string? StatusName,

    /// <summary>Số giờ vận hành</summary>
    decimal? OperatingHours,

    /// <summary>Ngày bảo trì gần nhất</summary>
    DateTimeOffset? LastMaintenanceDate,

    /// <summary>Vị trí lưu trữ ngắn</summary>
    string? StorageLocation
);

public record SearchEquipmentsRequest(
    /// <summary>Từ khóa tìm kiếm (tên thiết bị, nhà sản xuất, model, serial)</summary>
    string? Term,
    /// <summary>Loại thiết bị</summary>
    EquipmentType? EquipmentType,
    /// <summary>ID nông trại liên kết</summary>
    string? FarmId,
    /// <summary>Trạng thái thiết bị</summary>
    EquipmentStatus? Status,
    /// <summary>Ngày bảo trì gần nhất từ</summary>
    DateTimeOffset? LastMaintenanceDateFrom,
    /// <summary>Ngày bảo trì gần nhất đến</summary>
    DateTimeOffset? LastMaintenanceDateTo,
    /// <summary>Ngày bảo trì kế tiếp từ</summary>
    DateTimeOffset? NextMaintenanceDateFrom,
    /// <summary>Ngày bảo trì kế tiếp đến</summary>
    DateTimeOffset? NextMaintenanceDateTo,
    int PageNumeber,
    int PageSize
);

/// <summary>
/// Yêu cầu tạo thiết bị mới
/// </summary>
public record CreateEquipmentRequest(
    
    /// <summary>Tên thiết bị</summary>
    string Name,

    /// <summary>Loại thiết bị</summary>
    EquipmentType EquipmentType,

    /// <summary>ID nông trại liên kết</summary>
    string FarmId,

    /// <summary>Tên nhà sản xuất</summary>
    string? Manufacturer,

    /// <summary>Số model</summary>
    string? Model,

    /// <summary>Số serial</summary>
    string? SerialNumber,

    /// <summary>Công suất (HP)</summary>
    decimal? PowerRating,

    /// <summary>Thông số kỹ thuật / dung tích</summary>
    string? Specifications,

    /// <summary>Ngày mua</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Giá mua</summary>
    decimal? PurchaseCost,

    /// <summary>Giá trị hiện tại</summary>
    decimal? CurrentValue,

    /// <summary>Trạng thái thiết bị (mã)</summary>
    EquipmentStatus Status,

    /// <summary>Số giờ vận hành</summary>
    decimal? OperatingHours,

    /// <summary>Ngày bảo trì gần nhất</summary>
    DateTimeOffset? LastMaintenanceDate,

    /// <summary>Ngày bảo trì kế tiếp</summary>
    DateTimeOffset? NextMaintenanceDate,

    /// <summary>Vị trí lưu trữ</summary>
    string? StorageLocation,

    /// <summary>Ghi chú</summary>
    string? Notes
);

/// <summary>
/// Yêu cầu cập nhật thiết bị
/// </summary>
public record UpdateEquipmentRequest(
    /// <summary>Khóa chính (UUID) của thiết bị cần cập nhật</summary>
    string Id,

    /// <summary>Tên thiết bị</summary>
    string? Name,

    /// <summary>Loại thiết bị</summary>
    EquipmentType? EquipmentType,

    /// <summary>ID nông trại liên kết</summary>
    string? FarmId,

    /// <summary>Tên nhà sản xuất</summary>
    string? Manufacturer,

    /// <summary>Số model</summary>
    string? Model,

    /// <summary>Số serial</summary>
    string? SerialNumber,

    /// <summary>Công suất (HP)</summary>
    decimal? PowerRating,

    /// <summary>Thông số kỹ thuật / dung tích</summary>
    string? Specifications,

    /// <summary>Ngày mua</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Giá mua</summary>
    decimal? PurchaseCost,

    /// <summary>Giá trị hiện tại</summary>
    decimal? CurrentValue,

    /// <summary>Trạng thái thiết bị (mã)</summary>
    EquipmentStatus? Status,

    /// <summary>Số giờ vận hành</summary>
    decimal? OperatingHours,

    /// <summary>Ngày bảo trì gần nhất</summary>
    DateTimeOffset? LastMaintenanceDate,

    /// <summary>Ngày bảo trì kế tiếp</summary>
    DateTimeOffset? NextMaintenanceDate,

    /// <summary>Vị trí lưu trữ</summary>
    string? StorageLocation,

    /// <summary>Ghi chú</summary>
    string? Notes
);
