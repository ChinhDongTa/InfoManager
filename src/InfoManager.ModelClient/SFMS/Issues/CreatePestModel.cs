using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class CreatePestModel
{
    /// <summary>
    /// Tên thông thường
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string CommonName { get; set; } = string.Empty;

    /// <summary>
    /// Tên khoa học
    /// </summary>
    [MaxLength(200)]
    public string? ScientificName { get; set; }

    /// <summary>
    /// Loại sâu hại
    /// </summary>
    [MaxLength(50)]
    public string? PestType { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Cây bị ảnh hưởng
    /// </summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>
    /// Triệu chứng gây hại
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
    /// Đường dẫn ảnh
    /// </summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public CreatePestRequest CreateRequest()
    {
        return new CreatePestRequest
        (
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            PestType: this.PestType,
            Description: this.Description,
            AffectedCrops: this.AffectedCrops,
            DamageSymptoms: this.DamageSymptoms,
            LifeCycle: this.LifeCycle,
            PreventionMethods: this.PreventionMethods,
            RecommendedPesticides: this.RecommendedPesticides,
            BiologicalControl: this.BiologicalControl,
            SeverityLevel: this.SeverityLevel,
            ImageUrl: this.ImageUrl
        );
    }
}