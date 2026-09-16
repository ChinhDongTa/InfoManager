using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Domain.Entities;

/// <summary>
/// Kinh nghiệm cá nhân (Experience-like)
/// </summary>
public class Experience : BaseAuditableEntity
{
    [MaxLength(500)]
    public string Content { get; set; }

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

    public Category? Category { get; set; } = null;
}