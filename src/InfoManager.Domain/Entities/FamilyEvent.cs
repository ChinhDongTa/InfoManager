namespace InfoManager.Domain.Entities;

public class FamilyEvent : BaseEntity
{
    public required string FamilyMemberId { get; set; }
    public FamilyMember? FamilyMember { get; set; }

    /// <summary>
    /// Ngày diễn ra sự kiện 
    /// </summary>
    public required DateOnly EventDate { get; set; }

    /// <summary>
    /// Tên sự kiện 
    /// </summary>
    [MaxLength(300)]
    public required string Title { get; set; }
    /// <summary>
    /// Loại sự kiện (Sinh nhật, Kỷ niệm, Lễ hội, Sự kiện quan trọng khác)
    /// </summary>
    public FamilyEventType EventType { get; set; }

    /// <summary>
    /// Địa điểm diễn ra sự kiện
    /// </summary>
    [MaxLength(100)]
    public string? Location { get; set; }
}