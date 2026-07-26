using InfoManager.Enum;
using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.ModelClient.Transactions;

public class CreateTransactionModel
{
    /// <summary>
    /// Số tiền giao dịch
    /// </summary>
    [Required(ErrorMessage = "Số tiền giao dịch là bắt buộc.")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// Mã loại danh mục giao dịch, ví dụ: "food", "salary", v.v.
    /// </summary>
    public string? CategoryId { get; set; }

    /// <summary>
    /// Nội dung giao dịch, ví dụ: "Mua sắm tại siêu thị", "Nhận lương tháng 6", v.v.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Phương thức thanh toán, ví dụ: tiền mặt, thẻ tín dụng, chuyển khoản, v.v.
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;

    /// <summary>
    /// Ngày chi tiêu, có thể là null nếu chưa xác định nhưng sẽ cảnh báo ở giao diện người dùng.
    /// Nếu null, giao dịch sẽ sai.
    /// </summary>
    public DateTime? TransactionDate { get; set; }

    /// <summary>
    /// Loại giao dịch, ví dụ: chi tiêu, thu nhập, v.v.
    /// </summary>
    public TransactionType TransactionType { get; set; } = TransactionType.Expense;

    public CreateTransactionRequest CreateRequest()
    {
        return new CreateTransactionRequest
        {
            Amount = this.Amount!.Value,
            CategoryId = this.CategoryId,
            Description = this.Description,
            PaymentMethod = this.PaymentMethod,
            TransactionDate = this.TransactionDate,
            TransactionType = this.TransactionType
        };
    }
}