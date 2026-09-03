namespace InfoManager.Domain.Entities.SFMS.Customers;

/// <summary>
/// Chăm sóc / theo dõi khách hàng
/// </summary>
public class CustomerCare : BaseAuditableEntity
{
    /// <summary>
    /// ID khách hàng
    /// </summary>
    public required string CustomerId { get; set; }

    /// <summary>
    /// ID nông trại
    /// </summary>
    public required string FarmId { get; set; }

    /// <summary>
    /// Loại chăm sóc (Gọi điện, Ghé thăm, Khiếu nại, Theo dõi...)
    /// </summary>
    public CustomerCareType CareType { get; set; } = CustomerCareType.FollowUp;

    /// <summary>
    /// Tiêu đề
    /// </summary>
    [MaxLength(200)]
    public required string Subject { get; set; }

    /// <summary>
    /// Nội dung chăm sóc
    /// </summary>
    [MaxLength(1000)]
    public string? Content { get; set; }

    /// <summary>
    /// Ngày chăm sóc
    /// </summary>
    public DateTimeOffset CareDate { get; set; }

    /// <summary>
    /// Ngày theo dõi tiếp theo
    /// </summary>
    public DateTimeOffset? NextFollowUpDate { get; set; }

    /// <summary>
    /// Trạng thái xử lý
    /// </summary>
    public CustomerCareStatus Status { get; set; } = CustomerCareStatus.Open;

    /// <summary>
    /// Người phụ trách
    /// </summary>
    [MaxLength(100)]
    public string? HandledBy { get; set; }

    /// <summary>
    /// Kết quả / ghi chú xử lý
    /// </summary>
    [MaxLength(500)]
    public string? Result { get; set; }

    // Navigation
    public virtual Customer? Customer { get; set; }
    public virtual Farm? Farm { get; set; }
}