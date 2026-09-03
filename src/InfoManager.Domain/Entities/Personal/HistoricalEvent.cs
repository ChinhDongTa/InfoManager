namespace InfoManager.Domain.Entities.Personal;

public class HistoricalEvent : BaseAuditableEntity
{
    /// <summary>
    /// Ngày diễn ra sự kiện lịch sử
    /// </summary>
    public DateOnly? EventDate { get; set; }

    /// <summary>
    /// Tên sự kiện lịch sử
    /// </summary>
    [MaxLength(500)]
    public required string Title { get; set; }

    /// <summary>
    /// Loại sự kiện lịch sử (Chính trị, Quân sự, Văn hóa, Khoa học, Kinh tế, Khác)
    /// </summary>
    public  HistoricalEventType EventType { get; set; }=HistoricalEventType.Political;

    /// <summary>
    /// Địa điểm diễn ra sự kiện lịch sử
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Tóm tắt sự kiện lịch sử
    /// </summary>
    public required string Summary { get; set; }

    /// <summary>
    /// Nguồn tham khảo, ví dụ: sách, bài báo, trang web, v.v.
    /// </summary>
    public string? ReferenceSource { get; set; }
}
