using InfoManager.Enum;
using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.ModelClient.HistoricalEvents;

public class UpdateHistoricalEventModel
{
    public string Id { get; set; } =string.Empty;
    /// <summary>
    /// Ngày diễn ra sự kiện lịch sử
    /// </summary>
    public DateOnly? EventDate { get; set; }

    /// <summary>
    /// Tên sự kiện lịch sử
    /// </summary>
    [MaxLength(500)]
    public string? Title { get; set; }

    /// <summary>
    /// Loại sự kiện lịch sử (Chính trị, Quân sự, Văn hóa, Khoa học, Kinh tế, Khác)
    /// </summary>
    public HistoricalEventType? EventType { get; set; } = HistoricalEventType.Political;

    /// <summary>
    /// Địa điểm diễn ra sự kiện lịch sử
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Tóm tắt sự kiện lịch sử
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Nguồn tham khảo, ví dụ: sách, bài báo, trang web, v.v.
    /// </summary>
    public string? ReferenceSource { get; set; }

    public UpdateHistoricalEventModel(HistoricalEventDto dto)
    {
        Id = dto.Id;
        EventDate = dto.EventDate;
        Title = dto.Title;
        EventType = dto.EventType;
        Location = dto.Location;
        Summary = dto.Summary;
        ReferenceSource = dto.ReferenceSource;
    }
    public UpdateHistoricalEventRequest CreateRequest()
    {
        return new UpdateHistoricalEventRequest
        {
            Id = this.Id,
            EventDate = this.EventDate,
            Title = this.Title,
            EventType = this.EventType,
            Location = this.Location,
            Summary = this.Summary,
            ReferenceSource = this.ReferenceSource
        };
    }
    public bool HasChanges(UpdateHistoricalEventModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}
