namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Đại diện cho một thửa ruộng / khu vực trồng trong nông trại.
/// Mỗi thửa ruộng là một vùng canh tác cụ thể với điều kiện và hệ thống giám sát riêng.
/// </summary>
public class Field : BaseAuditableEntity
{
    /// <summary>
    /// Tên hoặc mã định danh của thửa ruộng
    /// </summary>
    [MaxLength(100)]
    public required string Name { get; set; }

    /// <summary>
    /// Mô tả thửa ruộng
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Diện tích thửa ruộng (hecta)
    /// </summary>
    public decimal Area { get; set; }

    /// <summary>
    /// ID nông trại liên quan
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Loại đất (Đất thịt, Đất cát, Đất sét...)
    /// </summary>
    [MaxLength(50)]
    public string? SoilType { get; set; }

    /// <summary>
    /// Tình trạng / chất lượng đất (Kém, Trung bình, Tốt, Rất tốt)
    /// </summary>
    public SoilCondition? SoilCondition { get; set; }

    /// <summary>
    /// Độ cao của thửa ruộng (mét)
    /// </summary>
    public decimal? Elevation { get; set; }

    /// <summary>
    /// Tọa độ vĩ độ
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Tọa độ kinh độ
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Trạng thái thửa ruộng (Trống, Đang canh tác, Để hoang, Đang chuẩn bị)
    /// </summary>
    public FieldStatus Status { get; set; } = FieldStatus.Vacant;

    /// <summary>
    /// Ngày chuẩn bị / cày xới gần nhất
    /// </summary>
    public DateTimeOffset? LastPreparationDate { get; set; }

    /// <summary>
    /// Tình trạng thoát nước (Thoát nước tốt, Trung bình, Kém)
    /// </summary>
    [MaxLength(50)]
    public string? DrainageCondition { get; set; }

    /// <summary>
    /// Có hệ thống tưới tiêu hay không
    /// </summary>
    public bool HasIrrigation { get; set; }

    // Navigation properties
    public virtual Farm? Farm { get; set; }
    public virtual ICollection<CropPlanting> CropPlantings { get; set; } = [];
    public virtual ICollection<Sensor> Sensors { get; set; } = [];
    public virtual ICollection<SoilAnalysis> SoilAnalyses { get; set; } = [];
    public virtual ICollection<Operations.Task> Tasks { get; set; } = [];
}