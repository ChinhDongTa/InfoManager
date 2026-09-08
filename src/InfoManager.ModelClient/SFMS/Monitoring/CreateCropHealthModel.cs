using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class CreateCropHealthModel
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    [Required]
    public string CropPlantingId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày đánh giá
    /// </summary>
    [Required]
    public DateTimeOffset AssessmentDate { get; set; }

    /// <summary>
    /// Tình trạng sức khỏe
    /// </summary>
    [Required]
    public HealthStatus HealthStatus { get; set; }

    /// <summary>
    /// Tình trạng lá
    /// </summary>
    [MaxLength(500)]
    public string? LeafCondition { get; set; }

    /// <summary>
    /// Tình trạng thân
    /// </summary>
    [MaxLength(500)]
    public string? StemCondition { get; set; }

    /// <summary>
    /// Tình trạng rễ
    /// </summary>
    [MaxLength(500)]
    public string? RootCondition { get; set; }

    /// <summary>
    /// Chiều cao cây (cm)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? PlantHeight { get; set; }

    /// <summary>
    /// Mật độ thực vật (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? VegetationDensity { get; set; }

    /// <summary>
    /// Thiệt hại do sâu (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? PestDamagePercentage { get; set; }

    /// <summary>
    /// Triệu chứng bệnh
    /// </summary>
    [MaxLength(500)]
    public string? DiseaseSymptoms { get; set; }

    /// <summary>
    /// Sinh khối ước tính (tấn/ha)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? BiomassEstimate { get; set; }

    /// <summary>
    /// Chỉ số LAI
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? LeafAreaIndex { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Việc nên làm tiếp
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedActions { get; set; }

    /// <summary>
    /// Đường dẫn ảnh
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public CreateCropHealthRequest CreateRequest()
    {
        return new CreateCropHealthRequest
        (
            CropPlantingId: this.CropPlantingId,
            AssessmentDate: this.AssessmentDate,
            HealthStatus: this.HealthStatus,
            LeafCondition: this.LeafCondition,
            StemCondition: this.StemCondition,
            RootCondition: this.RootCondition,
            PlantHeight: this.PlantHeight,
            VegetationDensity: this.VegetationDensity,
            PestDamagePercentage: this.PestDamagePercentage,
            DiseaseSymptoms: this.DiseaseSymptoms,
            BiomassEstimate: this.BiomassEstimate,
            LeafAreaIndex: this.LeafAreaIndex,
            Notes: this.Notes,
            RecommendedActions: this.RecommendedActions,
            PhotoUrl: this.PhotoUrl
        );
    }
}