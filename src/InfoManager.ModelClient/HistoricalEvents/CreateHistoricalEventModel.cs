using InfoManager.Enum;
using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.ModelClient.HistoricalEvents;

public class CreateHistoricalEventModel
{
    /// <summary>
    /// Ngày diễn ra sự kiện lịch sử
    /// </summary>
    [Required]
    public DateOnly EventDate { get; set; }

    /// <summary>
    /// Tên sự kiện lịch sử
    /// </summary>
    [MaxLength(500)]
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Loại sự kiện lịch sử (Chính trị, Quân sự, Văn hóa, Khoa học, Kinh tế, Khác)
    /// </summary>
    public HistoricalEventType EventType { get; set; } = HistoricalEventType.Political;

    /// <summary>
    /// Địa điểm diễn ra sự kiện lịch sử
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Tóm tắt sự kiện lịch sử
    /// </summary>
    [Required]
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Nguồn tham khảo, ví dụ: sách, bài báo, trang web, v.v.
    /// </summary>
    public string? ReferenceSource { get; set; }

    public CreateHistoricalEventRequest CreateRequest()
    {
        return new CreateHistoricalEventRequest
        {
            EventDate = this.EventDate,
            Title = this.Title,
            EventType = this.EventType,
            Location = this.Location,
            Summary = this.Summary,
            ReferenceSource = this.ReferenceSource
        };
    }
}