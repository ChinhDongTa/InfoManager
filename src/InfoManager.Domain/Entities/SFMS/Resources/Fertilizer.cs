namespace InfoManager.Domain.Entities.SFMS.Resources;

/// <summary>
/// Danh mục phân bón
/// </summary>
public class Fertilizer : BaseAuditableEntity
{
    /// <summary>
    /// Tên phân bón
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Loại phân (Hữu cơ, NPK, Đạm, Lân, Kali...)
    /// </summary>
    public FertilizerType FertilizerType { get; set; } = FertilizerType.NPK;

    /// <summary>
    /// Hàm lượng N (%)
    /// </summary>
    public decimal? NitrogenPercent { get; set; }

    /// <summary>
    /// Hàm lượng P (%)
    /// </summary>
    public decimal? PhosphorusPercent { get; set; }

    /// <summary>
    /// Hàm lượng K (%)
    /// </summary>
    public decimal? PotassiumPercent { get; set; }

    /// <summary>
    /// Đơn vị (kg, lít, bao...)
    /// </summary>
    [MaxLength(20)]
    public string Unit { get; set; } = "kg";

    /// <summary>
    /// Nhà sản xuất
    /// </summary>
    [MaxLength(200)]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Còn sử dụng hay không
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual ICollection<FertilizationPlan> Plans { get; set; } = [];
    public virtual ICollection<FertilizerApplication> Applications { get; set; } = [];
}