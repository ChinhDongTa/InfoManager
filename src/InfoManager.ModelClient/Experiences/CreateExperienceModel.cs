using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.ModelClient.Experiences;

public class CreateExperienceModel
{
    [MaxLength(500)]
    [Required]
    /// <summary>
    /// Nội dung trải nghiệm
    /// </summary>
    public string Content { get; set; } = string.Empty;
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

    public CreateExperienceRequest CreateRequest()
    {
        return new CreateExperienceRequest
        {
            Content = this.Content,
            Description = this.Description,
            ExperienceDate = this.ExperienceDate,
            CategoryId = this.CategoryId
        };
    }
}
