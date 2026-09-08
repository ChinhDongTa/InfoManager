using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class CreateDiseaseModel
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
    /// Loại bệnh
    /// </summary>
    [MaxLength(50)]
    public string? DiseaseType { get; set; }

    /// <summary>
    /// Tác nhân gây bệnh
    /// </summary>
    [MaxLength(200)]
    public string? CausativeOrganism { get; set; }

    /// <summary>
    /// Cây bị ảnh hưởng
    /// </summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>
    /// Triệu chứng
    /// </summary>
    [MaxLength(1000)]
    public string? Symptoms { get; set; }

    /// <summary>
    /// Điều kiện thuận lợi
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
    /// Biện pháp xử lý khuyến nghị
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedTreatments { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng
    /// </summary>
    public SeverityLevel? SeverityLevel { get; set; }

    /// <summary>
    /// Đường dẫn ảnh
    /// </summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public CreateDiseaseRequest CreateRequest()
    {
        return new CreateDiseaseRequest
        (
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            DiseaseType: this.DiseaseType,
            CausativeOrganism: this.CausativeOrganism,
            AffectedCrops: this.AffectedCrops,
            Symptoms: this.Symptoms,
            FavorableConditions: this.FavorableConditions,
            TransmissionMethod: this.TransmissionMethod,
            PreventionMethods: this.PreventionMethods,
            RecommendedTreatments: this.RecommendedTreatments,
            SeverityLevel: this.SeverityLevel,
            ImageUrl: this.ImageUrl
        );
    }
}