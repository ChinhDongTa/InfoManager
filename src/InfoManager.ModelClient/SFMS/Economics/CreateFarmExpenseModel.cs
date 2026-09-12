using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Economics;

namespace InfoManager.ModelClient.SFMS.Economics;

public class CreateFarmExpenseModel
{
    /// <summary>
    /// Nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Lượt trồng liên kết
    /// </summary>
    public string? CropPlantingId { get; set; }

    /// <summary>
    /// Loại chi phí
    /// </summary>
    [Required]
    public ExpenseType ExpenseType { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Số tiền
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Nhóm chi phí
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Ngày phát sinh chi phí
    /// </summary>
    public DateTimeOffset ExpenseDate { get; set; }

    /// <summary>
    /// Nhà cung cấp
    /// </summary>
    public string? Vendor { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Phương thức thanh toán
    /// </summary>
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Trạng thái phê duyệt
    /// </summary>
    public ApprovalStatus ApprovalStatus { get; set; }

    /// <summary>
    /// Người phê duyệt
    /// </summary>
    public string? ApprovedBy { get; set; }

    /// <summary>
    /// Đường dẫn chứng từ
    /// </summary>
    public string? AttachmentUrl { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateFarmExpenseRequest CreateRequest()
    {
        return new CreateFarmExpenseRequest
        (
            FarmId: this.FarmId,
            CropPlantingId: this.CropPlantingId,
            ExpenseType: this.ExpenseType,
            Description: this.Description,
            Amount: this.Amount,
            Category: this.Category,
            ExpenseDate: this.ExpenseDate,
            Vendor: this.Vendor,
            InvoiceNumber: this.InvoiceNumber,
            PaymentMethod: this.PaymentMethod,
            PaymentStatus: this.PaymentStatus,
            ApprovalStatus: this.ApprovalStatus,
            ApprovedBy: this.ApprovedBy,
            AttachmentUrl: this.AttachmentUrl,
            Notes: this.Notes
        );
    }
}