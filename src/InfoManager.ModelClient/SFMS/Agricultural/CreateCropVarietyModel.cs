using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class CreateCropVarietyModel
{
    /// <summary>
    /// Tên giống
    /// </summary>
    [Required]
    public string VarietyName { get; set; } = string.Empty;

    /// <summary>
    /// Cây trồng
    /// </summary>
    [Required]
    public string CropId { get; set; } = string.Empty;

    /// <summary>
    /// Tên đơn vị lai tạo
    /// </summary>
    public string? BreederName { get; set; }

    /// <summary>
    /// Số ngày đến thu hoạch
    /// </summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>
    /// Năng suất dự kiến
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị năng suất
    /// </summary>
    public string? YieldUnit { get; set; }

    /// <summary>
    /// Định mức hạt giống
    /// </summary>
    public decimal? SeedRate { get; set; }

    /// <summary>
    /// Khả năng kháng bệnh
    /// </summary>
    public string? DiseaseResistance { get; set; }

    /// <summary>
    /// Khả năng kháng sâu
    /// </summary>
    public string? PestResistance { get; set; }

    /// <summary>
    /// Khả năng thích nghi khí hậu
    /// </summary>
    public string? ClimateSuitability { get; set; }

    /// <summary>
    /// Năm công nhận giống
    /// </summary>
    public int? YearOfRelease { get; set; }

    /// <summary>
    /// Đang hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    public CreateCropVarietyRequest CreateRequest()
    {
        return new CreateCropVarietyRequest
        (
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
}