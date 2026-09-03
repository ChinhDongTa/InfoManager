namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== EmployeeContract ========================
/// <summary>
/// Hợp đồng lao động
/// </summary>
public class EmployeeContract : BaseAuditableEntity
{
    /// <summary>ID nhân viên</summary>
    public required string HREmployeeId { get; set; }

    /// <summary>Số hợp đồng</summary>
    [MaxLength(50)]
    public required string ContractNumber { get; set; }

    /// <summary>Loại hợp đồng (Thử việc, Chính thức, Thời vụ...)</summary>
    [MaxLength(50)]
    public required string ContractType { get; set; }

    /// <summary>Ngày bắt đầu</summary>
    public DateTimeOffset StartDate { get; set; }

    /// <summary>Ngày kết thúc (null = không thời hạn)</summary>
    public DateTimeOffset? EndDate { get; set; }

    /// <summary>Loại lương</summary>
    public SalaryType SalaryType { get; set; }

    /// <summary>Mức lương theo hợp đồng</summary>
    public decimal BaseSalary { get; set; }

    /// <summary>Đang hiệu lực</summary>
    public bool IsActive { get; set; } = true;

    // Navigation
    public virtual HREmployee? HREmployee { get; set; }
}
