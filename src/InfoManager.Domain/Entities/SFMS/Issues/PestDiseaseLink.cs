namespace InfoManager.Domain.Entities.SFMS.Issues;

/// <summary>
/// Liên kết sâu hại và bệnh (ví dụ: sâu truyền bệnh)
/// </summary>
public class PestDiseaseLink : BaseAuditableEntity
{
    /// <summary>
    /// ID sâu hại
    /// </summary>
    public required string PestId { get; set; }

    /// <summary>
    /// ID bệnh
    /// </summary>
    public required string DiseaseId { get; set; }

    /// <summary>
    /// Mô tả quan hệ (truyền bệnh, phát tán...)
    /// </summary>
    [MaxLength(500)]
    public string? RelationshipDescription { get; set; }

    public virtual Pest? Pest { get; set; }
    public virtual Disease? Disease { get; set; }
}