using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class UpdateInfestationModel
{
    /// <summary>ID vụ sâu bệnh. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>Loại sự cố.</summary>
    public InfestationType? InfestationType { get; set; }

    /// <summary>ID sâu hại.</summary>
    public string? PestId { get; set; }

    /// <summary>ID bệnh.</summary>
    public string? DiseaseId { get; set; }

    /// <summary>Ngày phát hiện.</summary>
    public DateTimeOffset? DetectionDate { get; set; }

    /// <summary>Diện tích bị ảnh hưởng. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? AffectedArea { get; set; }

    /// <summary>Tỷ lệ cây bị ảnh hưởng (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? AffectedPercentage { get; set; }

    /// <summary>Mức độ nghiêm trọng.</summary>
    public SeverityLevel? SeverityLevel { get; set; }

    /// <summary>Trạng thái.</summary>
    public InfestationStatus? Status { get; set; }

    /// <summary>Biện pháp đã áp dụng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? TreatmentApplied { get; set; }

    /// <summary>Ngày xử lý.</summary>
    public DateTimeOffset? TreatmentDate { get; set; }

    /// <summary>Thuốc / chế phẩm đã dùng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? ProductUsed { get; set; }

    /// <summary>Chi phí xử lý. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? TreatmentCost { get; set; }

    /// <summary>Hiệu quả xử lý (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? EffectivenessRating { get; set; }

    /// <summary>Ngày kiểm soát được.</summary>
    public DateTimeOffset? ControlledDate { get; set; }

    /// <summary>Tỷ lệ giảm năng suất (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? YieldLossPercentage { get; set; }

    /// <summary>Thiệt hại kinh tế. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? EconomicLoss { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public UpdateInfestationModel(string id, InfestationDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropPlantingId = dto.CropPlantingId;
        InfestationType = dto.InfestationType;
        PestId = dto.PestId;
        DiseaseId = dto.DiseaseId;
        DetectionDate = dto.DetectionDate;
        AffectedArea = dto.AffectedArea;
        AffectedPercentage = dto.AffectedPercentage;
        SeverityLevel = dto.SeverityLevel;
        Status = dto.Status;
        TreatmentApplied = dto.TreatmentApplied;
        TreatmentDate = dto.TreatmentDate;
        ProductUsed = dto.ProductUsed;
        TreatmentCost = dto.TreatmentCost;
        EffectivenessRating = dto.EffectivenessRating;
        ControlledDate = dto.ControlledDate;
        YieldLossPercentage = dto.YieldLossPercentage;
        EconomicLoss = dto.EconomicLoss;
        Notes = dto.Notes;
        PhotoUrl = dto.PhotoUrl;
    }

    public UpdateInfestationRequest CreateRequest()
    {
        return new UpdateInfestationRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateInfestationModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}