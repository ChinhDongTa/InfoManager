namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Cảnh báo thiết bị để theo dõi tình trạng sức khỏe thiết bị
/// </summary>
public class DeviceAlert : BaseAuditableEntity
{
    /// <summary>
    /// ID thiết bị liên quan
    /// </summary>
    public required string DeviceId { get; set; }

    /// <summary>
    /// Loại cảnh báo (Pin yếu, Tín hiệu yếu, Không có dữ liệu, Lỗi phần cứng...)
    /// </summary>
    public required AlertType AlertType { get; set; }

    /// <summary>
    /// Nội dung / mô tả cảnh báo
    /// </summary>
    [MaxLength(500)]
    public required string Message { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng của cảnh báo
    /// </summary>
    public AlertSeverity Severity { get; set; }

    /// <summary>
    /// Thời điểm cảnh báo được kích hoạt
    /// </summary>
    public DateTimeOffset AlertTime { get; set; }

    /// <summary>
    /// Thời điểm xử lý xong cảnh báo (nếu đã xử lý)
    /// </summary>
    public DateTimeOffset? ResolvedTime { get; set; }

    /// <summary>
    /// Cảnh báo đã được xử lý hay chưa
    /// </summary>
    public bool IsResolved { get; set; } = false;

    /// <summary>
    /// Ghi chú xử lý
    /// </summary>
    [MaxLength(500)]
    public string? ResolutionNotes { get; set; }

    // Navigation properties
    public virtual Device? Device { get; set; }
}