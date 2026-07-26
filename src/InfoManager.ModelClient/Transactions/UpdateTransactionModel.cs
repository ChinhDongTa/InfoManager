using InfoManager.Enum;
using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.ModelClient.Transactions;

public class UpdateTransactionModel
{
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// Số tiền giao dịch
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Mã loại giao dịch
    /// </summary>
    public string? CategoryId { get; set; }

    /// <summary>
    /// Nội dung giao dịch, ví dụ: "Mua sắm tại siêu thị", "Nhận lương tháng 6", v.v.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Phương thức thanh toán, ví dụ: tiền mặt, thẻ tín dụng, chuyển khoản, v.v.
    /// </summary>
    public PaymentMethod? PaymentMethod { get; set; }

    /// <summary>
    /// Ngày chi tiêu, có thể là null nếu chưa xác định nhưng sẽ cảnh báo ở giao diện người dùng.
    /// Nếu null, giao dịch sẽ sai.
    /// </summary>
    public DateTime? TransactionDate { get; set; }

    /// <summary>
    /// Loại giao dịch, ví dụ: chi tiêu, thu nhập, v.v.
    /// </summary>
    public TransactionType? TransactionType { get; set; }

    public bool HasChanges(UpdateTransactionModel original)
    {
        return ClientUpdateHelper.HasChanges(this, original);
    }
    public UpdateTransactionModel(TransactionDto dto)
    {
        Id = dto.Id;
        Amount = dto.Amount;
        CategoryId = dto.CategoryId;
        Description = dto.Description;
        PaymentMethod = dto.PaymentMethod;
        TransactionDate = dto.TransactionDate;
        TransactionType = dto.TransactionType;
    }
    public UpdateTransactionRequest CreateRequest()
    {
        return new UpdateTransactionRequest
        {
            Id = this.Id,
            Amount = this.Amount,
            CategoryId = this.CategoryId,
            Description = this.Description,
            PaymentMethod = this.PaymentMethod,
            TransactionDate = this.TransactionDate,
            TransactionType = this.TransactionType
        };
    }
}