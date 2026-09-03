using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyMembers;

namespace InfoManager.ModelClient.Families;

public class UpdateFamilyMemberModel 
{
    public string Id { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public string? FamilyRelationId { get; set; }

    /// <summary>
    /// Ngày sinh của thành viên gia đình
    /// </summary>
    public DateOnly? BirthDate { get; set; }
    /// <summary>
    /// Ngày mất của thành viên gia đình
    /// </summary>
    public DateOnly? DeathDate { get; set; }

    /// <summary>
    /// Giới tính của thành viên gia đình
    /// </summary>
    public Gender? Gender { get; set; }

    /// <summary>
    /// Địa chỉ email của thành viên gia đình
    /// </summary>
    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// Số điện thoại của thành viên gia đình
    /// </summary>
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Ghi chú về thành viên gia đình
    /// </summary>
    public string? Note { get; set; }
    public UpdateFamilyMemberModel(FamilyMemberDto dto)
    {
        Id = dto.Id;
        FullName = dto.FullName;
        FamilyRelationId = dto.FamilyRelationId;
        BirthDate = dto.BirthDate;
        DeathDate = dto.DeathDate;
        Gender = dto.Gender;
        Email = dto.Email;
        PhoneNumber = dto.PhoneNumber;
        Note = dto.Note;
    }

    public UpdateFamilyMemberRequest CreateRequest() => new()
    {
        Id = this.Id,
        FullName = this.FullName,
        FamilyRelationId = this.FamilyRelationId,
        BirthDate = this.BirthDate,
        DeathDate = this.DeathDate,
        Gender = this.Gender,
        Email = this.Email,
        PhoneNumber = this.PhoneNumber,
        Note = this.Note
    };

    public bool HasChanges(UpdateFamilyMemberModel originalModel) 
        => ClientUpdateHelper.HasChanges(this, originalModel);
}