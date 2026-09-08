using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class CreateCustomerCareModel
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    [Required]
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    /// Nông trại liên kết
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Tiêu đề chăm sóc
    /// </summary>
    [Required]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Loại chăm sóc
    /// </summary>
    [Required]
    public CustomerCareType CareType { get; set; }

    /// <summary>
    /// Nội dung
    /// </summary>
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
    /// Trạng thái chăm sóc
    /// </summary>
    public CustomerCareStatus Status { get; set; }

    /// <summary>
    /// Người xử lý
    /// </summary>
    public string? HandledBy { get; set; }

    /// <summary>
    /// Kết quả
    /// </summary>
    public string? Result { get; set; }

    public CreateCustomerCareRequest CreateRequest()
    {
        return new CreateCustomerCareRequest
        (
            CustomerId: this.CustomerId,
            FarmId: this.FarmId,
            Subject: this.Subject,
            CareType: this.CareType,
            Content: this.Content,
            CareDate: this.CareDate,
            NextFollowUpDate: this.NextFollowUpDate,
            Status: this.Status,
            HandledBy: this.HandledBy,
            Result: this.Result
        );
    }
}