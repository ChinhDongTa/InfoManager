namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Đại diện cho kế hoạch trồng cây theo lịch trình của một loại cây và giống cụ thể.
/// </summary>
public class CropSchedule : BaseAuditableEntity
{
    /// <summary>
    /// Tên lịch trình / kế hoạch trồng
    /// </summary>
    [MaxLength(200)]
    public required string ScheduleName { get; set; }

    /// <summary>
    /// ID loại cây trồng
    /// </summary>
    public required string CropId { get; set; }

    /// <summary>
    /// ID giống cây trồng
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// Mùa vụ trồng khuyến nghị
    /// </summary>
    [MaxLength(50)]
    public string? PlantingSeason { get; set; }

    /// <summary>
    /// Khoảng thời gian trồng khuyến nghị (Tháng-Ngày)
    /// </summary>
    public string? PlantingDateRange { get; set; }

    /// <summary>
    /// Khoảng thời gian thu hoạch khuyến nghị (Tháng-Ngày)
    /// </summary>
    public string? HarvestDateRange { get; set; }

    /// <summary>
    /// Số ngày từ khi trồng đến khi thu hoạch
    /// </summary>
    public int DaysToHarvest { get; set; }

    /// <summary>
    /// Khoảng cách giữa các cây (cm)
    /// </summary>
    public decimal? PlantSpacing { get; set; }

    /// <summary>
    /// Khoảng cách giữa các hàng (cm)
    /// </summary>
    public decimal? RowSpacing { get; set; }

    /// <summary>
    /// Mô tả lịch tưới nước
    /// </summary>
    [MaxLength(500)]
    public string? IrrigationSchedule { get; set; }

    /// <summary>
    /// Mô tả lịch bón phân
    /// </summary>
    [MaxLength(500)]
    public string? FertilizationSchedule { get; set; }

    /// <summary>
    /// Mô tả lịch phun thuốc trừ sâu / diệt cỏ
    /// </summary>
    [MaxLength(500)]
    public string? PesticideSchedule { get; set; }

    /// <summary>
    /// Năng suất kỳ vọng (kg/ha)
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Ước tính chi phí sản xuất
    /// </summary>
    public decimal? EstimatedCost { get; set; }

    /// <summary>
    /// Lịch trình còn đang sử dụng hay không
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú về lịch trình
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Crop? Crop { get; set; }
    public virtual CropVariety? CropVariety { get; set; }
    public virtual ICollection<GrowthStage> GrowthStages { get; set; } = [];
    public virtual ICollection<CropPlanting> Plantings { get; set; } = [];
}