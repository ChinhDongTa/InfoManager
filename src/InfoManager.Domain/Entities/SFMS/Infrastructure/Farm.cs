using InfoManager.Domain.Entities.SFMS.HR;

namespace InfoManager.Domain.Entities.SFMS.Infrastructure;

/// <summary>
/// Nông trại thuộc về một Farmer.
/// Đây là đơn vị vận hành chính, chứa thửa ruộng, thiết bị, nhân sự.
/// </summary>
public class Farm : BaseAuditableEntity
{
    /// <summary>
    /// Tên nông trại
    /// </summary>
    [MaxLength(200)]
    public string Name { get; set; }

    /// <summary>
    /// Mô tả nông trại
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Tổng diện tích nông trại (hecta)
    /// </summary>
    public decimal TotalArea { get; set; }

    /// <summary>
    /// Diện tích có thể canh tác (hecta)
    /// </summary>
    public decimal CultivableArea { get; set; }

    /// <summary>
    /// Địa điểm / địa chỉ nông trại
    /// </summary>
    [MaxLength(500)]
    public string? Location { get; set; }

    /// <summary>
    /// Tọa độ vĩ độ
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Tọa độ kinh độ
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Chủ hộ sở hữu nông trại.
    /// </summary>
    public string FarmerId { get; set; }

    /// <summary>
    /// Số đăng ký / giấy phép nông trại
    /// </summary>
    [MaxLength(100)]
    public string? LicenseNumber { get; set; }

    /// <summary>
    /// Trạng thái nông trại
    /// </summary>
    public FarmStatus Status { get; set; } = FarmStatus.Active;

    /// <summary>
    /// Ngày bắt đầu hoạt động
    /// </summary>
    public DateTimeOffset? EstablishedDate { get; set; }

    public virtual Farmer? Farmer { get; set; }
    public virtual ICollection<Field> Fields { get; set; } = [];
    public virtual ICollection<Equipment> Equipment { get; set; } = [];
    public virtual ICollection<FarmExpense> Expenses { get; set; } = [];
    public virtual ICollection<FarmInventory> Inventory { get; set; } = [];
    public virtual ICollection<HREmployee> Employees { get; set; } = [];
}