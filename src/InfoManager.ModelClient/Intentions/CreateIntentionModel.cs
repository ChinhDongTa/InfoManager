using InfoManager.Enum;
using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.ModelClient.Intentions;

public class CreateIntentionModel
{
    [MaxLength(500)]
    /// <summary>
    /// Nội dung ý định, việc muốn làm
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;
    /// <summary>
    /// Mô tả chi tiết về ý định, việc muốn làm
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ngày dự kiến thực hiện ý định, việc muốn làm
    /// </summary>
    public DateTimeOffset? PlannDate { get; set; }
    /// <summary>
    /// Trạng thái hoàn thành của ý định, việc muốn làm
    /// </summary>
    public bool IsCompleted { get; set; } = false;
    /// <summary>
    /// Mức độ ưu tiên của ý định, việc muốn làm
    /// </summary>
    public Priority Priority { get; set; } = Priority.Medium;

    public string? CategoryId { get; set; }

    public CreateIntentionRequest CreateRequest()
    {
        return new CreateIntentionRequest
        {
            Content = this.Content,
            Description = this.Description,
            PlannDate = this.PlannDate,
            IsCompleted = this.IsCompleted,
            Priority = this.Priority,
            CategoryId = this.CategoryId
        };
    }
}