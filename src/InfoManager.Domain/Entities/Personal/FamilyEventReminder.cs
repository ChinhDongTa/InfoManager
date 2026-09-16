using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Domain.Entities;

/// <summary>
/// Thông tin nhắc nhở cho sự kiện gia đình (ví dụ: nhắc trước 1 tuần, 1 ngày, đúng ngày, v.v.)
/// </summary>
public class FamilyEventReminder : BaseAuditableEntity
{
    public string FamilyEventId { get; set; }
    public FamilyEvent? FamilyEvent { get; set; }

    /// <summary>
    /// Nhắc trước bao nhiêu ngày (0 = đúng ngày sự kiện, 1 = 1 ngày trước, 7 = 1 tuần...)
    /// </summary>
    public int DaysBefore { get; set; } = 7;

    /// <summary>
    /// Giờ nhắc trong ngày (ví dụ 08:00, 19:30). Null = cả ngày
    /// </summary>
    public TimeOnly? RemindTime { get; set; } = new TimeOnly(8, 0);

    /// <summary>
    /// Kênh nhắc nhở
    /// </summary>
    public ReminderChannel Channel { get; set; } = ReminderChannel.Push;

    /// <summary>
    /// Bật / tắt nhắc nhở này
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Ghi chú thêm (tùy chọn)
    /// </summary>
    [MaxLength(500)]
    public string? Note { get; set; }
}