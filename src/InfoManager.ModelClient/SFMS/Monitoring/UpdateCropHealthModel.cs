using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class UpdateCropHealthModel
{
    /// <summary>ID bản ghi. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>Ngày đánh giá.</summary>
    public DateTimeOffset? AssessmentDate { get; set; }

    /// <summary>Tình trạng sức khỏe.</summary>
    public HealthStatus? HealthStatus { get; set; }

    /// <summary>Tình trạng lá. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? LeafCondition { get; set; }

    /// <summary>Tình trạng thân. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? StemCondition { get; set; }

    /// <summary>Tình trạng rễ. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? RootCondition { get; set; }

    /// <summary>Chiều cao cây (cm). ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? PlantHeight { get; set; }

    /// <summary>Mật độ thực vật (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? VegetationDensity { get; set; }

    /// <summary>Thiệt hại do sâu (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? PestDamagePercentage { get; set; }

    /// <summary>Triệu chứng bệnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? DiseaseSymptoms { get; set; }

    /// <summary>Sinh khối ước tính. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? BiomassEstimate { get; set; }

    /// <summary>Chỉ số LAI. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? LeafAreaIndex { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>Việc nên làm tiếp. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? RecommendedActions { get; set; }

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public UpdateCropHealthModel(string id, CropHealthDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropPlantingId = dto.CropPlantingId;
        AssessmentDate = dto.AssessmentDate;
        HealthStatus = dto.HealthStatus;
        LeafCondition = dto.LeafCondition;
        StemCondition = dto.StemCondition;
        RootCondition = dto.RootCondition;
        PlantHeight = dto.PlantHeight;
        VegetationDensity = dto.VegetationDensity;
        PestDamagePercentage = dto.PestDamagePercentage;
        DiseaseSymptoms = dto.DiseaseSymptoms;
        BiomassEstimate = dto.BiomassEstimate;
        LeafAreaIndex = dto.LeafAreaIndex;
        Notes = dto.Notes;
        RecommendedActions = dto.RecommendedActions;
        PhotoUrl = dto.PhotoUrl;
    }

    public UpdateCropHealthRequest CreateRequest()
    {
        return new UpdateCropHealthRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateCropHealthModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
