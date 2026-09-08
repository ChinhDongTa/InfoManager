using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class CreateCustomerModel
{
    /// <summary>
    /// Nông trại liên kết
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Tên khách hàng
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Mã khách hàng
    /// </summary>
    public string? CustomerCode { get; set; }

    /// <summary>
    /// Loại khách hàng
    /// </summary>
    [Required]
    public CustomerType CustomerType { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Địa chỉ
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Mã số thuế
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Người liên hệ
    /// </summary>
    public string? ContactPerson { get; set; }

    /// <summary>
    /// Hạn mức tín dụng
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// Trạng thái khách hàng
    /// </summary>
    public CustomerStatus Status { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateCustomerRequest CreateRequest()
    {
        return new CreateCustomerRequest
        (
            FarmId: this.FarmId,
            Name: this.Name,
            CustomerCode: this.CustomerCode,
            CustomerType: this.CustomerType,
            Phone: this.Phone,
            Email: this.Email,
            Address: this.Address,
            TaxCode: this.TaxCode,
            ContactPerson: this.ContactPerson,
            CreditLimit: this.CreditLimit,
            Status: this.Status,
            Notes: this.Notes
        );
    }
}