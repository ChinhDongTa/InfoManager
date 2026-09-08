using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class CreateInfestationModel
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    [Required]
    public string CropPlantingId { get; set; } = string.Empty;

    /// <summary>
    /// Loại sự cố
    /// </summary>
    [Required]
    public InfestationType InfestationType { get; set; }

    /// <summary>
    /// ID sâu hại. Bắt buộc nếu InfestationType = Pest.
    /// </summary>
    public string? PestId { get; set; }

    /// <summary>
    /// ID bệnh. Bắt buộc nếu InfestationType = Disease.
    /// </summary>
    public string? DiseaseId { get; set; }

    /// <summary>
    /// Ngày phát hiện
    /// </summary>
    [Required]
    public DateTimeOffset DetectionDate { get; set; }

    /// <summary>
    /// Diện tích bị ảnh hưởng (hecta)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal AffectedArea { get; set; }

    /// <summary>
    /// Tỷ lệ cây bị ảnh hưởng (%)
    /// </summary>
    [Range(0, 100)]
    public decimal AffectedPercentage { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng
    /// </summary>
    [Required]
    public SeverityLevel SeverityLevel { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public InfestationStatus Status { get; set; } = InfestationStatus.Detected;

    /// <summary>
    /// Biện pháp đã áp dụng
    /// </summary>
    [MaxLength(500)]
    public string? TreatmentApplied { get; set; }

    /// <summary>
    /// Ngày xử lý
    /// </summary>
    public DateTimeOffset? TreatmentDate { get; set; }

    /// <summary>
    /// Thuốc / chế phẩm đã dùng
    /// </summary>
    [MaxLength(500)]
    public string? ProductUsed { get; set; }

    /// <summary>
    /// Chi phí xử lý
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? TreatmentCost { get; set; }

    /// <summary>
    /// Hiệu quả xử lý (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? EffectivenessRating { get; set; }

    /// <summary>
    /// Ngày kiểm soát được
    /// </summary>
    public DateTimeOffset? ControlledDate { get; set; }

    /// <summary>
    /// Tỷ lệ giảm năng suất (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? YieldLossPercentage { get; set; }

    /// <summary>
    /// Thiệt hại kinh tế
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? EconomicLoss { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Đường dẫn ảnh
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public CreateInfestationRequest CreateRequest()
    {
        return new CreateInfestationRequest
        (
            CropPlantingId: this.CropPlantingId,
            InfestationType: this.InfestationType,
            PestId: this.PestId,
            DiseaseId: this.DiseaseId,
            DetectionDate: this.DetectionDate,
            AffectedArea: this.AffectedArea,
            AffectedPercentage: this.AffectedPercentage,
            SeverityLevel: this.SeverityLevel,
            Status: this.Status,
            TreatmentApplied: this.TreatmentApplied,
            TreatmentDate: this.TreatmentDate,
            ProductUsed: this.ProductUsed,
            TreatmentCost: this.TreatmentCost,
            EffectivenessRating: this.EffectivenessRating,
            ControlledDate: this.ControlledDate,
            YieldLossPercentage: this.YieldLossPercentage,
            EconomicLoss: this.EconomicLoss,
            Notes: this.Notes,
            PhotoUrl: this.PhotoUrl
        );
    }
}