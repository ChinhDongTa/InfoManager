namespace InfoManager.Domain.Entities.SFMS.Issues;

/// <summary>
/// Danh mục sâu hại
/// </summary>
public class Pest : BaseAuditableEntity
{
    /// <summary>
    /// Tên thông thường
    /// </summary>
    [MaxLength(100)]
    public string CommonName { get; set; }

    /// <summary>
    /// Tên khoa học
    /// </summary>
    [MaxLength(200)]
    public string? ScientificName { get; set; }

    /// <summary>
    /// Loại sâu hại (Côn trùng, Nhện, Tuyến trùng, Gặm nhấm, Chim...)
    /// </summary>
    [MaxLength(50)]
    public string? PestType { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Các loại cây bị ảnh hưởng (cách nhau bởi dấu phẩy)
    /// </summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>
    /// Triệu chứng / đặc điểm gây hại
    /// </summary>
    [MaxLength(1000)]
    public string? DamageSymptoms { get; set; }

    /// <summary>
    /// Vòng đời
    /// </summary>
    [MaxLength(1000)]
    public string? LifeCycle { get; set; }

    /// <summary>
    /// Biện pháp phòng ngừa
    /// </summary>
    [MaxLength(1000)]
    public string? PreventionMethods { get; set; }

    /// <summary>
    /// Thuốc BVTV khuyến nghị
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedPesticides { get; set; }

    /// <summary>
    /// Biện pháp sinh học
    /// </summary>
    [MaxLength(1000)]
    public string? BiologicalControl { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng
    /// </summary>
    public SeverityLevel? SeverityLevel { get; set; }

    /// <summary>
    /// Đường dẫn ảnh tham chiếu
    /// </summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public virtual ICollection<Infestation> Infestations { get; set; } = [];
    public virtual ICollection<PestDiseaseLink> DiseaseLinks { get; set; } = [];
}