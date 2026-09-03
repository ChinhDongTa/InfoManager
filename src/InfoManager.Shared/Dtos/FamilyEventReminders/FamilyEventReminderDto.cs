namespace InfoManager.Shared.Dtos.FamilyEventReminders;

// ========== Create ==========
public record CreateFamilyEventReminderRequest(
    string FamilyEventId,
    int DaysBefore = 7,
    TimeOnly? RemindTime = null,          // null = 08:00 mặc định
    ReminderChannel Channel = ReminderChannel.Push,
    bool IsEnabled = true,
    string? Note = null
);

// ========== Update ==========
public record UpdateFamilyEventReminderRequest(
    string Id,
    int? DaysBefore,
    TimeOnly? RemindTime,
    ReminderChannel? Channel,
    bool IsEnabled,
    string? Note
);

// ========== Summary (dùng cho danh sách) ==========
public record FamilyEventReminderSummaryDto(
    string Id,
    string EventTitle,                // từ FamilyEvent.Title
    string MemberName,                // từ FamilyMember.FullName
    int DaysBefore,
    TimeOnly? RemindTime
);

// ========== Detail ==========
public record FamilyEventReminderDto(
    string Id,
    string FamilyEventId,
    string EventTitle,
    string MemberName,
    int DaysBefore,
    TimeOnly? RemindTime,
    ReminderChannel Channel,
    bool IsEnabled,
    string? Note
);

public record SearchFamilyEventReminderRequest(int? MinDaysBefore, int? MaxDaysBefore, ReminderChannel? Channel, int PageNumber = 1, int PageSize = 20);