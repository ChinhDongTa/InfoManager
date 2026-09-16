using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class UpdateCropVarietyModel
{
    /// <summary>ID giống cây trồng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên giống.</summary>
    public string? VarietyName { get; set; }

    /// <summary>ID cây trồng.</summary>
    public string? CropId { get; set; }

    /// <summary>Tên đơn vị lai tạo.</summary>
    public string? BreederName { get; set; }

    /// <summary>Số ngày đến thu hoạch.</summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>Năng suất dự kiến.</summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>Đơn vị năng suất.</summary>
    public string? YieldUnit { get; set; }

    /// <summary>Định mức hạt giống.</summary>
    public decimal? SeedRate { get; set; }

    /// <summary>Khả năng kháng bệnh.</summary>
    public string? DiseaseResistance { get; set; }

    /// <summary>Khả năng kháng sâu.</summary>
    public string? PestResistance { get; set; }

    /// <summary>Khả năng thích nghi khí hậu.</summary>
    public string? ClimateSuitability { get; set; }

    /// <summary>Năm công nhận giống.</summary>
    public int? YearOfRelease { get; set; }

    /// <summary>Đang hoạt động.</summary>
    public bool? IsActive { get; set; }

    public UpdateCropVarietyModel(string id, CropVarietyDto dto)
    {
        Id = id;
        VarietyName = dto.VarietyName;
        CropId = dto.CropId;
        BreederName = dto.BreederName;
        DaysToMaturity = dto.DaysToMaturity;
        ExpectedYield = dto.ExpectedYield;
        YieldUnit = dto.YieldUnit;
        SeedRate = dto.SeedRate;
        DiseaseResistance = dto.DiseaseResistance;
        PestResistance = dto.PestResistance;
        ClimateSuitability = dto.ClimateSuitability;
        YearOfRelease = dto.YearOfRelease;
        IsActive = dto.IsActive;
    }

    public UpdateCropVarietyRequest CreateRequest()
    {
        return new UpdateCropVarietyRequest
        (
            Id: this.Id,
            VarietyName: this.VarietyName,
            CropId: this.CropId,
            BreederName: this.BreederName,
            DaysToMaturity: this.DaysToMaturity,
            ExpectedYield: this.ExpectedYield,
            YieldUnit: this.YieldUnit,
            SeedRate: this.SeedRate,
            DiseaseResistance: this.DiseaseResistance,
            PestResistance: this.PestResistance,
            ClimateSuitability: this.ClimateSuitability,
            YearOfRelease: this.YearOfRelease,
            IsActive: this.IsActive
        );
    }

    public bool HasChanges(UpdateCropVarietyModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}