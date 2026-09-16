using TaskStatus = InfoManager.Enum.SFMS.TaskStatus;

namespace InfoManager.Domain.Entities.SFMS.Operations;

/// <summary>
/// Công việc / hoạt động trên nông trại
/// </summary>
public class Task : BaseAuditableEntity
{
    /// <summary>
    /// Tên công việc
    /// </summary>
    [MaxLength(200)]
    public string TaskName { get; set; }

    /// <summary>
    /// Mô tả công việc
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// ID thửa ruộng / ô ruộng liên quan
    /// </summary>
    public string FieldId { get; set; }

    /// <summary>
    /// ID lần trồng (CropPlanting) liên quan (tùy chọn)
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// Loại công việc (Planting, Weeding, Spraying, Harvesting, ...)
    /// </summary>
    public TaskType TaskType { get; set; }

    /// <summary>
    /// ID thiết bị liên quan (tùy chọn)
    /// </summary>
    public string? EquipmentId { get; set; }

    /// <summary>
    /// Trạng thái công việc
    /// </summary>
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    /// <summary>
    /// Ngày bắt đầu dự kiến
    /// </summary>
    public DateTimeOffset ScheduledStartDate { get; set; }

    /// <summary>
    /// Ngày kết thúc dự kiến
    /// </summary>
    public DateTimeOffset? ScheduledEndDate { get; set; }

    /// <summary>
    /// Ngày bắt đầu thực tế
    /// </summary>
    public DateTimeOffset? ActualStartDate { get; set; }

    /// <summary>
    /// Ngày kết thúc thực tế
    /// </summary>
    public DateTimeOffset? ActualEndDate { get; set; }

    /// <summary>
    /// Thời lượng công việc (giờ)
    /// </summary>
    public decimal? DurationHours { get; set; }

    /// <summary>
    /// Diện tích làm việc (hecta)
    /// </summary>
    public decimal? WorkArea { get; set; }

    /// <summary>
    /// Người được phân công / chịu trách nhiệm
    /// </summary>
    [MaxLength(100)]
    public string? AssignedTo { get; set; }

    /// <summary>
    /// Mức độ ưu tiên
    /// </summary>
    public TaskPriority Priority { get; set; } = TaskPriority.Normal;

    /// <summary>
    /// Tỷ lệ hoàn thành (0-100)
    /// </summary>
    public decimal? CompletionPercentage { get; set; }

    /// <summary>
    /// Ghi chú / bình luận về công việc
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    // Navigation properties
    /// <summary>Thửa ruộng liên quan</summary>
    public virtual Field? Field { get; set; }

    /// <summary>Lần trồng liên quan</summary>
    public virtual CropPlanting? CropPlanting { get; set; }

    /// <summary>Thiết bị liên quan</summary>
    public virtual Equipment? Equipment { get; set; }
}