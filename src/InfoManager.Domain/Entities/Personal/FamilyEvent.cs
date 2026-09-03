namespace InfoManager.Domain.Entities.Personal;

public class FamilyEvent : BaseAuditableEntity
{
    public required string FamilyMemberId { get; set; }
    public FamilyMember? FamilyMember { get; set; }

    /// <summary>
    /// Ngày gốc của sự kiện (ngày sinh, ngày mất, ngày cưới...)
    /// Chỉ lấy Month + Day để lặp hàng năm
    /// </summary>
    public required DateOnly EventDate { get; set; }

    /// <summary>
    /// Trạng thái sự kiện (có hiệu lực hay không)
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Tên sự kiện 
    /// </summary>
    [MaxLength(300)]
    public required string Title { get; set; }
    /// <summary>
    /// Loại sự kiện (Kỷ niệm, Lễ hội, Sự kiện quan trọng khác)
    /// </summary>
    public FamilyEventType EventType { get; set; }

    /// <summary>
    /// Địa điểm diễn ra sự kiện gốc, đầu tiên
    /// </summary>
    [MaxLength(100)]
    public string? Location { get; set; }

    /// <summary>
    /// Navigation
    /// </summary>
    public ICollection<FamilyEventOccurrence> Occurrences { get; set; } = [];
    public ICollection<FamilyEventReminder> Reminders { get; set; } = [];
}
