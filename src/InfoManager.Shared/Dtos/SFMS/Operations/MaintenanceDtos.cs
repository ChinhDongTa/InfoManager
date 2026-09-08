namespace InfoManager.Shared.Dtos.SFMS.Operations;

/// <summary>
/// Thông tin chi tiết bản ghi bảo trì
/// </summary>
public record MaintenanceDto(
    /// <summary>Khóa chính (UUID) của bản ghi bảo trì</summary>
    string Id,

    /// <summary>ID thiết bị liên quan</summary>
    string EquipmentId,
    string? EquipmentName,

    /// <summary>Ngày thực hiện bảo trì</summary>
    DateTimeOffset MaintenanceDate,

    /// <summary>Loại bảo trì (Routine, Repair, Inspection, Overhaul)</summary>
    MaintenanceType MaintenanceType,
    string MaintenanceTypeName,

    /// <summary>Mô tả công việc bảo trì</summary>
    string Description,

    /// <summary>Phụ tùng đã thay/sử dụng (danh sách, ngăn cách bằng dấu phẩy)</summary>
    string? PartReplaced,

    /// <summary>Chi phí bảo trì</summary>
    decimal? Cost,

    /// <summary>Tên nhà cung cấp dịch vụ / kỹ thuật viên</summary>
    string? ServiceProvider,

    /// <summary>Số giờ vận hành tại thời điểm bảo trì</summary>
    decimal? OperatingHours,

    /// <summary>Trạng thái bảo trì (mã)</summary>
    MaintenanceStatus Status,
    string StatusName,
    /// <summary>Ghi chú thêm</summary>
    string? Notes,

    /// <summary>URL tài liệu / hóa đơn</summary>
    string? DocumentUrl,

    /// <summary>Ngày tạo bản ghi</summary>
    DateTimeOffset? Created
);

/// <summary>
/// Thông tin tóm tắt bản ghi bảo trì (dùng cho danh sách)
/// </summary>
public record MaintenanceSummaryDto(
    /// <summary>Khóa chính (UUID) của bản ghi bảo trì</summary>
    string Id,

    /// <summary>ID thiết bị liên quan</summary>
    string EquipmentName,

    /// <summary>Ngày thực hiện bảo trì</summary>
    DateTimeOffset MaintenanceDate,

    /// <summary>Loại bảo trì (mã)</summary>
    string MaintenanceTypeName,

    /// <summary>Tên nhà cung cấp dịch vụ / kỹ thuật viên</summary>
    string? ServiceProvider,

    /// <summary>Chi phí bảo trì</summary>
    decimal? Cost,

    /// <summary>Trạng thái bảo trì (mã)</summary>
    int Status
);

/// <summary>
/// Yêu cầu tạo bản ghi bảo trì mới
/// </summary>
public record CreateMaintenanceRequest(
    /// <summary>Khóa chính (UUID) của bản ghi (có thể do client sinh hoặc server ghi đè)</summary>
    string Id,

    /// <summary>ID thiết bị liên quan</summary>
    string EquipmentId,

    /// <summary>Ngày thực hiện bảo trì</summary>
    DateTimeOffset MaintenanceDate,

    /// <summary>Loại bảo trì (Routine, Repair, Inspection, Overhaul)</summary>
    MaintenanceType MaintenanceType,

    /// <summary>Mô tả công việc bảo trì</summary>
    string Description,

    /// <summary>Phụ tùng đã thay/sử dụng (ngăn cách bằng dấu phẩy)</summary>
    string? PartReplaced,

    /// <summary>Chi phí bảo trì</summary>
    decimal? Cost,

    /// <summary>Tên nhà cung cấp dịch vụ / kỹ thuật viên</summary>
    string? ServiceProvider,

    /// <summary>Số giờ vận hành tại thời điểm bảo trì</summary>
    decimal? OperatingHours,

    /// <summary>Trạng thái bảo trì (mã)</summary>
    MaintenanceStatus? Status,

    /// <summary>Ghi chú thêm</summary>
    string? Notes,

    /// <summary>URL tài liệu / hóa đơn</summary>
    string? DocumentUrl
);

/// <summary>
/// Yêu cầu cập nhật bản ghi bảo trì
/// </summary>
public record UpdateMaintenanceRequest(
    /// <summary>Khóa chính (UUID) của bản ghi cần cập nhật</summary>
    string Id,

    /// <summary>ID thiết bị liên quan</summary>
    string? EquipmentId,

    /// <summary>Ngày thực hiện bảo trì</summary>
    DateTimeOffset? MaintenanceDate,

    /// <summary>Loại bảo trì (mã)</summary>
    MaintenanceType? MaintenanceType,

    /// <summary>Mô tả công việc bảo trì</summary>
    string? Description,

    /// <summary>Phụ tùng đã thay/sử dụng (ngăn cách bằng dấu phẩy)</summary>
    string? PartReplaced,

    /// <summary>Chi phí bảo trì</summary>
    decimal? Cost,

    /// <summary>Tên nhà cung cấp dịch vụ / kỹ thuật viên</summary>
    string? ServiceProvider,

    /// <summary>Số giờ vận hành tại thời điểm bảo trì</summary>
    decimal? OperatingHours,

    /// <summary>Trạng thái bảo trì (mã)</summary>
    MaintenanceStatus? Status,

    /// <summary>Ghi chú thêm</summary>
    string? Notes,

    /// <summary>URL tài liệu / hóa đơn</summary>
    string? DocumentUrl
);