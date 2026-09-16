using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.ModelClient.Families;

public class CreateFamilyEventModel
{
    [Required]
    public string FamilyMemberId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày diễn ra sự kiện
    /// </summary>
    [Required]
    public DateOnly EventDate { get; set; }

    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Tên sự kiện
    /// </summary>
    [MaxLength(300)]
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Loại sự kiện (Sinh nhật, Kỷ niệm, Lễ hội, Sự kiện quan trọng khác)
    /// </summary>
    public FamilyEventType EventType { get; set; }

    /// <summary>
    /// Địa điểm diễn ra sự kiện
    /// </summary>
    [MaxLength(100)]
    public string? Location { get; set; }

    public CreateFamilyEventRequest CreateRequest() => new()
    {
        FamilyMemberId = this.FamilyMemberId,
        EventDate = this.EventDate,
        IsActive = this.IsActive,
        Title = this.Title,
        EventType = this.EventType,
        Location = this.Location
    };
}