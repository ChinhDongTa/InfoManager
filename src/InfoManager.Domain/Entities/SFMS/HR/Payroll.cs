namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== Payroll ========================
/// <summary>
/// Bảng lương
/// </summary>
public class Payroll : BaseAuditableEntity
{
    /// <summary>ID nhân viên</summary>
    public required string HREmployeeId { get; set; }

    /// <summary>Ngày bắt đầu kỳ lương</summary>
    public DateOnly PeriodStartDate { get; set; }

    /// <summary>Ngày kết thúc kỳ lương</summary>
    public DateOnly PeriodEndDate { get; set; }

    /// <summary>Lương cơ bản</summary>
    public decimal BaseSalary { get; set; }

    /// <summary>Số ngày công</summary>
    public decimal DaysWorked { get; set; }

    /// <summary>Số giờ làm thêm</summary>
    public decimal? OvertimeHours { get; set; }

    /// <summary>Tiền làm thêm</summary>
    public decimal? OvertimeAmount { get; set; }

    /// <summary>Tiền thưởng / phụ cấp</summary>
    public decimal? BonusAmount { get; set; }

    /// <summary>Các khoản khấu trừ</summary>
    public decimal? Deductions { get; set; }

    /// <summary>Chi tiết khấu trừ</summary>
    [MaxLength(1000)]
    public string? DeductionDetails { get; set; }

    /// <summary>Thực lãnh</summary>
    public decimal NetAmount { get; set; }

    /// <summary>Trạng thái thanh toán</summary>
    public PayrollStatus PaymentStatus { get; set; } = PayrollStatus.Pending;

    /// <summary>Ngày thanh toán</summary>
    public DateTimeOffset? PaymentDate { get; set; }

    /// <summary>Phương thức thanh toán</summary>
    [MaxLength(50)]
    public string? PaymentMethod { get; set; }

    /// <summary>Mã tham chiếu / giao dịch</summary>
    [MaxLength(100)]
    public string? ReferenceNumber { get; set; }

    /// <summary>Ghi chú</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    public virtual HREmployee? HREmployee { get; set; }
}