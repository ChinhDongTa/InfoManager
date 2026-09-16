namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Ý định, việc muốn làm (Task-like)
/// </summary>
public class Intention : BaseAuditableEntity
{
    [MaxLength(500)]
    public string Content { get; set; }

    /// <summary>
    /// Mô tả chi tiết về ý định, việc muốn làm
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ngày dự kiến thực hiện ý định, việc muốn làm
    /// </summary>
    public DateTimeOffset? PlannDate { get; set; }

    /// <summary>
    /// Trạng thái hoàn thành của ý định, việc muốn làm
    /// </summary>
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Mức độ ưu tiên của ý định, việc muốn làm
    /// </summary>
    public Priority Priority { get; set; } = Priority.Medium;

    public string? CategoryId { get; set; }
    public Category? Category { get; set; }
}