using InfoManager.Domain.Entities.SFMS.Issues;

namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Đại diện cho một lần trồng cụ thể của cây trồng trên một thửa ruộng / khu vực.
/// </summary>
public class CropPlanting : BaseAuditableEntity
{
    /// <summary>
    /// Mã định danh cho 1 lần trồng gồm: yyyymmdd-FieldSlug-CommonNameSlug
    /// Bỏ dấu, khoảng trắng và ký tự đặc biệt, giữ chữ và số và tất cả viết hoa.
    /// Được sinh tự động khi tạo mới, nhưng có thể chỉnh sửa nếu cần.
    /// </summary>
    [MaxLength(300)]
    public string PlantingCode { get; set; }=string.Empty;

    /// <summary>
    /// ID thửa ruộng / khu vực trồng
    /// </summary>
    public required string FieldId { get; set; }

    /// <summary>
    /// ID loại cây trồng
    /// </summary>
    public required string CropId { get; set; }

    /// <summary>
    /// ID giống cây trồng
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// ID lịch trồng / kế hoạch trồng
    /// </summary>
    public string? CropScheduleId { get; set; }

    /// <summary>
    /// Ngày trồng thực tế
    /// </summary>
    public DateTimeOffset PlantingDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch dự kiến
    /// </summary>
    public DateTimeOffset? ExpectedHarvestDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch thực tế
    /// </summary>
    public DateTimeOffset? ActualHarvestDate { get; set; }

    /// <summary>
    /// Diện tích trồng (hecta)
    /// </summary>
    public decimal PlantedArea { get; set; }

    /// <summary>
    /// Số lượng hạt giống / cây giống đã trồng
    /// </summary>
    public decimal? QuantityPlanted { get; set; }

    /// <summary>
    /// Đơn vị số lượng trồng (Hạt giống, Cây giống, kg...)
    /// </summary>
    [MaxLength(50)]
    public string? PlantedUnit { get; set; }

    /// <summary>
    /// Trạng thái hiện tại của lần trồng
    /// </summary>
    public PlantingStatus Status { get; set; } = PlantingStatus.Planned;

    /// <summary>
    /// Ghi chú về lần trồng
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Field? Field { get; set; }
    public virtual Crop? Crop { get; set; }
    public virtual CropVariety? CropVariety { get; set; }
    public virtual CropSchedule? CropSchedule { get; set; }
    public virtual ICollection<CropHealth> HealthRecords { get; set; } = [];
    public virtual ICollection<Harvest> Harvests { get; set; } = [];
    public virtual ICollection<Infestation> Infestations { get; set; } = [];
}