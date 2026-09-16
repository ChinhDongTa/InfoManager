using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class UpdateCustomerModel
{
    /// <summary>ID khách hàng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại liên kết.</summary>
    public string? FarmId { get; set; }

    /// <summary>Mã khách hàng.</summary>
    public string? CustomerCode { get; set; }

    /// <summary>Tên khách hàng.</summary>
    public string? Name { get; set; }

    /// <summary>Loại khách hàng.</summary>
    public CustomerType? CustomerType { get; set; }

    /// <summary>Số điện thoại.</summary>
    public string? Phone { get; set; }

    /// <summary>Email.</summary>
    public string? Email { get; set; }

    /// <summary>Địa chỉ.</summary>
    public string? Address { get; set; }

    /// <summary>Mã số thuế.</summary>
    public string? TaxCode { get; set; }

    /// <summary>Người liên hệ.</summary>
    public string? ContactPerson { get; set; }

    /// <summary>Hạn mức tín dụng.</summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>Trạng thái khách hàng.</summary>
    public CustomerStatus? Status { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateCustomerModel(string id, CustomerDto dto)
    {
        Id = id;
        FarmId = dto.FarmId;
        CustomerCode = dto.CustomerCode;
        Name = dto.Name;
        CustomerType = dto.CustomerType;
        Phone = dto.Phone;
        Email = dto.Email;
        Address = dto.Address;
        TaxCode = dto.TaxCode;
        ContactPerson = dto.ContactPerson;
        CreditLimit = dto.CreditLimit;
        Status = dto.Status;
        Notes = dto.Notes;
    }

    public UpdateCustomerRequest CreateRequest()
    {
        return new UpdateCustomerRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            CustomerCode: this.CustomerCode,
            Name: this.Name,
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

    public bool HasChanges(UpdateCustomerModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}