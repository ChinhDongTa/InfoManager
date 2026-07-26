using InfoManager.Enum;
using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.ModelClient.Intentions;

public class UpdateIntentionModel
{
    public string Id { get; set; } = string.Empty;
    [MaxLength(500)]
    /// <summary>
    /// Nội dung ý định, việc muốn làm
    /// </summary>
    public string? Content { get; set; }
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
    public bool? IsCompleted { get; set; } 
    /// <summary>
    /// Mức độ ưu tiên của ý định, việc muốn làm
    /// </summary>
    public Priority? Priority { get; set; } 

    public string? CategoryId { get; set; }

    public UpdateIntentionModel(IntentionDto dto)
    {
        Id = dto.Id;
        Content = dto.Content;
        Description = dto.Description;
        PlannDate = dto.PlannDate;
        IsCompleted = dto.IsCompleted;
        Priority = dto.Priority;
        CategoryId = dto.CategoryId;
    }
    public UpdateIntentionRequest CreateRequest()
    {
        return new UpdateIntentionRequest
        {
            Id = this.Id,
            Content = this.Content,
            Description = this.Description,
            PlannDate = this.PlannDate,
            IsCompleted = this.IsCompleted,
            Priority = this.Priority,
            CategoryId = this.CategoryId
        };
    }
    public bool HasChanges(UpdateIntentionModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}