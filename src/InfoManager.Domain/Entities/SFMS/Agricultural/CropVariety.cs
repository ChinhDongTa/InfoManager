namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Đại diện cho giống cây trồng - một giống cụ thể của loại cây.
/// </summary>
public class CropVariety : BaseAuditableEntity
{
    /// <summary>
    /// Tên giống / tên cultivar
    /// </summary>
    [MaxLength(200)]
    public string VarietyName { get; set; }

    /// <summary>
    /// ID loại cây trồng
    /// </summary>
    public string CropId { get; set; }

    /// <summary>
    /// Tên nhà tạo giống / công ty phát triển
    /// </summary>
    [MaxLength(200)]
    public string? BreederName { get; set; }

    /// <summary>
    /// Số ngày đến khi chín của giống này
    /// </summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>
    /// Năng suất kỳ vọng trên mỗi hecta (kg)
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Đơn vị năng suất
    /// </summary>
    [MaxLength(50)]
    public string? YieldUnit { get; set; } = "kg/ha";

    /// <summary>
    /// Lượng hạt giống cần dùng (kg/ha)
    /// </summary>
    public decimal? SeedRate { get; set; }

    /// <summary>
    /// Đặc điểm kháng bệnh
    /// </summary>
    [MaxLength(500)]
    public string? DiseaseResistance { get; set; }

    /// <summary>
    /// Đặc điểm kháng sâu bệnh
    /// </summary>
    [MaxLength(500)]
    public string? PestResistance { get; set; }

    /// <summary>
    /// Khả năng thích nghi khí hậu
    /// </summary>
    [MaxLength(200)]
    public string? ClimateSuitability { get; set; }

    /// <summary>
    /// Năm phát hành giống
    /// </summary>
    public int? YearOfRelease { get; set; }

    /// <summary>
    /// Giống còn đang sử dụng / còn sẵn có hay không
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Crop? Crop { get; set; }

    public virtual ICollection<CropSchedule> Schedules { get; set; } = [];
    public virtual ICollection<CropPlanting> Plantings { get; set; } = [];
}