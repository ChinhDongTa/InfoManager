using InfoManager.Domain.Entities.Authentication;

namespace InfoManager.Domain.Entities.SFMS.Customers;

/// <summary>
/// Khách hàng mua nông sản / dịch vụ của nông trại
/// </summary>
public class Customer : BaseAuditableEntity
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    public string FarmId { get; set; }

    /// <summary>
    /// Mã khách hàng
    /// </summary>
    [MaxLength(50)]
    public string? CustomerCode { get; set; }

    /// <summary>
    /// Tên khách hàng / tên công ty
    /// </summary>
    [MaxLength(200)]
    public string Name { get; set; }

    /// <summary>
    /// Loại khách hàng (Cá nhân, Doanh nghiệp)
    /// </summary>
    public CustomerType CustomerType { get; set; } = CustomerType.Individual;

    /// <summary>
    /// Số điện thoại
    /// </summary>
    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// Địa chỉ
    /// </summary>
    [MaxLength(500)]
    public string? Address { get; set; }

    /// <summary>
    /// Mã số thuế (nếu là doanh nghiệp)
    /// </summary>
    [MaxLength(50)]
    public string? TaxCode { get; set; }

    /// <summary>
    /// Người liên hệ
    /// </summary>
    [MaxLength(200)]
    public string? ContactPerson { get; set; }

    /// <summary>
    /// Hạn mức công nợ
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// Trạng thái khách hàng
    /// </summary>
    public CustomerStatus Status { get; set; } = CustomerStatus.Active;

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    /// <summary>
    /// Khách hàng đăng ký tài khoản Identity thì gắn UserId.
    /// Tuy nhiên, không phải khách nào cũng có tài khoản (mua tại chỗ, khách quen, đại lý chưa tạo user)
    /// </summary>
    public string? UserId { get; set; }

    // Navigation
    public virtual Farm? Farm { get; set; }

    public virtual ApplicationUser? User { get; set; }
    public virtual ICollection<CustomerPayment> Payments { get; set; } = [];
    public virtual ICollection<CustomerCare> CareRecords { get; set; } = [];
}