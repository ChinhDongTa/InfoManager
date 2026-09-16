using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.ModelClient.Families;

public class CreateFamilyEventReminderModel
{
    [Required]
    public string FamilyEventId { get; set; } = string.Empty;

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

    public CreateFamilyEventReminderRequest CreateRequest() => new(
            FamilyEventId: this.FamilyEventId,
            DaysBefore: this.DaysBefore,
            RemindTime: this.RemindTime,
            Channel: this.Channel,
            IsEnabled: this.IsEnabled,
            Note: this.Note
        );
}