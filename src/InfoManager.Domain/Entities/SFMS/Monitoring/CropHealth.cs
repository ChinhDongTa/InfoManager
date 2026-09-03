namespace InfoManager.Domain.Entities.SFMS.Monitoring;

/// <summary>
/// Bản ghi theo dõi sức khỏe / tình trạng cây trồng
/// </summary>
public class CropHealth : BaseAuditableEntity
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    public required string CropPlantingId { get; set; }

    /// <summary>
    /// Ngày đánh giá
    /// </summary>
    public DateTimeOffset AssessmentDate { get; set; }

    /// <summary>
    /// Tình trạng sức khỏe tổng thể (Rất tốt, Tốt, Trung bình, Kém, Nguy cấp)
    /// </summary>
    public HealthStatus HealthStatus { get; set; }

    /// <summary>
    /// Tình trạng lá (vàng, héo, đốm...)
    /// </summary>
    [MaxLength(500)]
    public string? LeafCondition { get; set; }

    /// <summary>
    /// Tình trạng thân
    /// </summary>
    [MaxLength(500)]
    public string? StemCondition { get; set; }

    /// <summary>
    /// Tình trạng rễ (nếu có)
    /// </summary>
    [MaxLength(500)]
    public string? RootCondition { get; set; }

    /// <summary>
    /// Chiều cao cây (cm)
    /// </summary>
    public decimal? PlantHeight { get; set; }

    /// <summary>
    /// Mật độ / độ che phủ thực vật (%)
    /// </summary>
    public decimal? VegetationDensity { get; set; }

    /// <summary>
    /// Tỷ lệ thiệt hại do sâu (%)
    /// </summary>
    public decimal? PestDamagePercentage { get; set; }

    /// <summary>
    /// Triệu chứng bệnh nhìn thấy
    /// </summary>
    [MaxLength(500)]
    public string? DiseaseSymptoms { get; set; }

    /// <summary>
    /// Sinh khối ước tính (tấn/ha)
    /// </summary>
    public decimal? BiomassEstimate { get; set; }

    /// <summary>
    /// Chỉ số diện tích lá (LAI)
    /// </summary>
    public decimal? LeafAreaIndex { get; set; }

    /// <summary>
    /// Ghi chú người đánh giá
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Việc nên làm tiếp
    /// </summary>
    [MaxLength(1000)]
    public string? RecommendedActions { get; set; }

    /// <summary>
    /// Đường dẫn ảnh đánh giá
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public virtual CropPlanting? CropPlanting { get; set; }
}