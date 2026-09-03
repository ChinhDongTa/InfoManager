using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.ModelClient.Families;

public class UpdateFamilyEventReminderModel
{
    [Required]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Nhắc trước bao nhiêu ngày (0 = đúng ngày sự kiện, 1 = 1 ngày trước, 7 = 1 tuần...)
    /// </summary>
    public int DaysBefore { get; set; } 

    /// <summary>
    /// Giờ nhắc trong ngày (ví dụ 08:00, 19:30). Null = cả ngày
    /// </summary>
    public TimeOnly? RemindTime { get; set; } 

    /// <summary>
    /// Kênh nhắc nhở
    /// </summary>
    public ReminderChannel Channel { get; set; } 

    /// <summary>
    /// Bật / tắt nhắc nhở này
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Ghi chú thêm (tùy chọn)
    /// </summary>
    [MaxLength(500)]
    public string? Note { get; set; }

    public UpdateFamilyEventReminderModel(FamilyEventReminderDto dto)
    {
        Id = dto.Id;
        DaysBefore = dto.DaysBefore;
        RemindTime = dto.RemindTime;
        Channel = dto.Channel;
        IsEnabled = dto.IsEnabled;
        Note = dto.Note;
    }
    public UpdateFamilyEventReminderRequest CreateRequest() => new(
            Id: this.Id,
            DaysBefore: this.DaysBefore,
            RemindTime: this.RemindTime,
            Channel: this.Channel,
            IsEnabled: this.IsEnabled,
            Note: this.Note
        );
    public bool HasChanges(UpdateFamilyEventReminderModel originalModel) 
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
