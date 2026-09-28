namespace InfoManager.Domain.Entities.SFMS.Issues;

/// <summary>
/// Bản ghi sâu bệnh trên lần trồng
/// </summary>
public class Infestation : BaseAuditableEntity
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    public required string CropPlantingId { get; set; }

    /// <summary>
    /// ID sâu hại (nếu là sâu)
    /// </summary>
    public string? PestId { get; set; }

    /// <summary>
    /// ID bệnh (nếu là bệnh)
    /// </summary>
    public string? DiseaseId { get; set; }

    /// <summary>
    /// Loại sự cố (Sâu hại / Bệnh)
    /// </summary>
    public InfestationType InfestationType { get; set; }

    /// <summary>
    /// Ngày phát hiện lần đầu
    /// </summary>
    public DateTimeOffset DetectionDate { get; set; }

    /// <summary>
    /// Diện tích bị ảnh hưởng (hecta)
    /// </summary>
    public decimal AffectedArea { get; set; }

    /// <summary>
    /// Tỷ lệ cây bị ảnh hưởng (0-100)
    /// </summary>
    public decimal AffectedPercentage { get; set; }

    /// <summary>
    /// Mức độ nghiêm trọng lúc phát hiện
    /// </summary>
    public SeverityLevel SeverityLevel { get; set; }

    /// <summary>
    /// Trạng thái xử lý
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
    /// Thuốc / chế phẩm đã dùng (tên và liều lượng)
    /// </summary>
    [MaxLength(500)]
    public string? ProductUsed { get; set; }

    /// <summary>
    /// Chi phí xử lý
    /// </summary>
    public decimal? TreatmentCost { get; set; }

    /// <summary>
    /// Hiệu quả xử lý (0-100)
    /// </summary>
    public decimal? EffectivenessRating { get; set; }

    /// <summary>
    /// Ngày kiểm soát được
    /// </summary>
    public DateTimeOffset? ControlledDate { get; set; }

    /// <summary>
    /// Tỷ lệ giảm năng suất do sâu bệnh (%)
    /// </summary>
    public decimal? YieldLossPercentage { get; set; }

    /// <summary>
    /// Thiệt hại kinh tế
    /// </summary>
    public decimal? EconomicLoss { get; set; }

    /// <summary>
    /// Ghi chú / mô tả
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Đường dẫn ảnh / bằng chứng
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public virtual CropPlanting? CropPlanting { get; set; }
    public virtual Pest? Pest { get; set; }
    public virtual Disease? Disease { get; set; }
}