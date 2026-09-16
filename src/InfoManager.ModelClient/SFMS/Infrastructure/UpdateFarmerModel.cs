namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateFarmerModel
{
    /// <summary>ID hồ sơ. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID thành viên gia đình.</summary>
    public string? FamilyMemberId { get; set; }

    /// <summary>Mã chủ hộ. Tối đa 50 ký tự.</summary>
    public string? FarmerCode { get; set; }

    /// <summary>Họ tên. Tối đa 200 ký tự.</summary>
    public string? FullName { get; set; }

    /// <summary>Số điện thoại. Tối đa 20 ký tự.</summary>
    public string? Phone { get; set; }

    /// <summary>Email. Tối đa 200 ký tự.</summary>
    public string? Email { get; set; }

    /// <summary>CCCD / CMND. Tối đa 50 ký tự.</summary>
    public string? IdentityNumber { get; set; }

    /// <summary>Địa chỉ. Tối đa 500 ký tự.</summary>
    public string? Address { get; set; }

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    public string? Notes { get; set; }

    public UpdateFarmerModel(string id, FarmerDto dto)
    {
        Id = id;
        FamilyMemberId = dto.FamilyMemberId;
        FarmerCode = dto.FarmerCode;
        FullName = dto.FullName;
        Phone = dto.Phone;
        Email = dto.Email;
        IdentityNumber = dto.IdentityNumber;
        Address = dto.Address;
        Notes = dto.Notes;
    }

    public UpdateFarmerRequest CreateRequest()
    {
        return new UpdateFarmerRequest
        (
            Id: this.Id,
            FamilyMemberId: this.FamilyMemberId,
            FarmerCode: this.FarmerCode,
            FullName: this.FullName,
            Phone: this.Phone,
            Email: this.Email,
            IdentityNumber: this.IdentityNumber,
            Address: this.Address,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateFarmerModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}