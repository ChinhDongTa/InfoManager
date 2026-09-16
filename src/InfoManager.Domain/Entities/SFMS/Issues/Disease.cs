namespace InfoManager.Domain.Entities.SFMS.Issues;

/// <summary>
/// Danh mục bệnh cây trồng
/// </summary>
public class Disease : BaseAuditableEntity
{
    /// <summary>
    /// Tên thông thường của bệnh
    /// </summary>
    [MaxLength(100)]
    public string CommonName { get; set; }

    /// <summary>
    /// Tên khoa học của bệnh
    /// </summary>
    [MaxLength(200)]
    public string? ScientificName { get; set; }

    /// <summary>
    /// Loại bệnh (Nấm, Vi khuẩn, Virus, Tuyến trùng...)
    /// </summary>
    [MaxLength(50)]
    public string? DiseaseType { get; set; }

    /// <summary>
    /// Tác nhân gây bệnh
    /// </summary>
    [MaxLength(200)]
    public string? CausativeOrganism { get; set; }

    /// <summary>
    /// Các loại cây bị ảnh hưởng (cách nhau bởi dấu phẩy)
    /// </summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>
    /// Triệu chứng
    /// </summary>
    [MaxLength(1000)]
    public string? Symptoms { get; set; }

    /// <summary>
    /// Điều kiện thuận lợi để bệnh phát triển
    /// </summary>
    [MaxLength(500)]
    public string? FavorableConditions { get; set; }

    /// <summary>
    /// Con đường lây truyền
    /// </summary>
    [MaxLength(500)]
    public string? TransmissionMethod { get; set; }

    /// <summary>
    /// Biện pháp phòng ngừa
    /// </summary>
    [MaxLength(1000)]
    public string? PreventionMethods { get; set; }

    /// <summary>
    /// Thuốc / biện pháp xử lý khuyến nghị
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedTreatments { get; set; }

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
    public virtual ICollection<PestDiseaseLink> PestLinks { get; set; } = [];
}