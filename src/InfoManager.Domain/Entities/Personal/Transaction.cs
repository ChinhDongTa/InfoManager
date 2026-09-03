namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Mô tả giao dịch, ví dụ: chi tiêu, thu nhập, v.v.
/// </summary>
public class Transaction : BaseAuditableEntity
{
    /// <summary>
    /// Số tiền giao dịch
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Mã loại giao dịch
    /// </summary>
    public string? CategoryId { get; set; }
    public Category? Category { get; set; }

    /// <summary>
    /// Nội dung giao dịch, ví dụ: "Mua sắm tại siêu thị", "Nhận lương tháng 6", v.v.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Phương thức thanh toán, ví dụ: tiền mặt, thẻ tín dụng, chuyển khoản, v.v.
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Ngày chi tiêu, có thể là null nếu chưa xác định nhưng sẽ cảnh báo ở giao diện người dùng.
    /// Nếu null, giao dịch sẽ sai.
    /// </summary>
    public DateTimeOffset? TransactionDate { get; set; }

    /// <summary>
    /// Loại giao dịch, ví dụ: chi tiêu, thu nhập, v.v.
    /// </summary>
    public TransactionType TransactionType { get; set; }
}