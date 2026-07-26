using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.ModelClient.Families;

public class UpdateFamilyEventModel
{
    public string Id { get; set; } = string.Empty;
    public string? FamilyMemberId { get; set; } 
    /// <summary>
    /// Ngày diễn ra sự kiện 
    /// </summary>
    public DateOnly? EventDate { get; set; }
    /// <summary>
    /// Tên sự kiện 
    /// </summary>
    [MaxLength(300)]
    public string? Title { get; set; } 
    /// <summary>
    /// Loại sự kiện (Sinh nhật, Kỷ niệm, Lễ hội, Sự kiện quan trọng khác)
    /// </summary>
    public FamilyEventType? EventType { get; set; }
    /// <summary>
    /// Địa điểm diễn ra sự kiện
    /// </summary>
    [MaxLength(100)]
    public string? Location { get; set; }

    public UpdateFamilyEventModel(FamilyEventDto dto)
    {
        Id = dto.Id;
        FamilyMemberId = dto.FamilyMemberId;
        EventDate = dto.EventDate;
        Title = dto.Title;
        EventType = dto.EventType;
        Location = dto.Location;
    }

    public UpdateFamilyEventRequest CreateRequest()
    {
        return new UpdateFamilyEventRequest
        {
            Id = this.Id,
            FamilyMemberId = this.FamilyMemberId,
            EventDate = this.EventDate,
            Title = this.Title,
            EventType = this.EventType,
            Location = this.Location
        };
    }
    public bool HasChanges(UpdateFamilyEventModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}