using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.ModelClient.Experiences;

public class UpdateExperienceModel
{
    public string Id { get; set; }

    [MaxLength(500)]
    public string? Content { get; set; }

    /// <summary>
    /// Mô tả chi tiết về trải nghiệm
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ngày diễn ra trải nghiệm
    /// </summary>
    public DateOnly? ExperienceDate { get; set; }

    /// <summary>
    /// Phân loại trải nghiệm (Nông nghiệp, Công nghệ, Học tập, Khác)
    /// </summary>
    public string? CategoryId { get; set; }

    public UpdateExperienceModel(ExperienceDto dto)
    {
        Id = dto.Id;
        Content = dto.Content;
        Description = dto.Description;
        ExperienceDate = dto.ExperienceDate;
        CategoryId = dto.CategoryId;
    }

    public UpdateExperienceRequest CreateRequest()
    {
        return new UpdateExperienceRequest
        {
            Id = this.Id,
            Content = this.Content,
            Description = this.Description,
            ExperienceDate = this.ExperienceDate,
            CategoryId = this.CategoryId
        };
    }

    public bool HasChanges(UpdateExperienceModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}