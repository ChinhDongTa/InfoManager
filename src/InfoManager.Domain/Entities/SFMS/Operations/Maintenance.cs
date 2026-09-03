namespace InfoManager.Domain.Entities.SFMS.Operations;
/// <summary>
/// Bản ghi bảo trì thiết bị
/// </summary>
public class Maintenance : BaseAuditableEntity
{
    /// <summary>
    /// ID thiết bị liên quan
    /// </summary>
    public required string EquipmentId { get; set; }

    /// <summary>
    /// Ngày thực hiện bảo trì
    /// </summary>
    public DateTimeOffset MaintenanceDate { get; set; }

    /// <summary>
    /// Loại bảo trì (Routine, Repair, Inspection, Overhaul)
    /// </summary>
    public MaintenanceType MaintenanceType { get; set; }

    /// <summary>
    /// Mô tả công việc bảo trì đã thực hiện
    /// </summary>
    [MaxLength(500)]
    public required string Description { get; set; }

    /// <summary>
    /// Các phụ tùng đã thay/sử dụng (ngăn cách bằng dấu phẩy)
    /// </summary>
    [MaxLength(500)]
    public string? PartReplaced { get; set; }

    /// <summary>
    /// Chi phí bảo trì
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Nhà cung cấp dịch vụ / tên kỹ thuật viên
    /// </summary>
    [MaxLength(200)]
    public string? ServiceProvider { get; set; }

    /// <summary>
    /// Số giờ vận hành tại thời điểm bảo trì
    /// </summary>
    public decimal? OperatingHours { get; set; }

    /// <summary>
    /// Trạng thái bảo trì
    /// </summary>
    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Completed;

    /// <summary>
    /// Ghi chú thêm về bảo trì
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    /// <summary>
    /// URL tài liệu / hóa đơn liên quan
    /// </summary>
    [MaxLength(500)]
    public string? DocumentUrl { get; set; }

    // Navigation properties
    /// <summary>
    /// Thông tin thiết bị liên quan
    /// </summary>
    public virtual Equipment? Equipment { get; set; }
}