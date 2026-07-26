using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ModelClient.Families;

public class UpdateFamilyRelationModel
{
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Tên mối quan hệ (Ông cố nội, Bà cố nội, Ông cố ngoại, Bà cố ngoại, Ông nội, Bà nội, Ông ngoại, Bà ngoại, Cha, Mẹ, Con trai, Con gái)
    /// </summary>
    [MaxLength(100)]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public UpdateFamilyRelationModel(FamilyRelationDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Description = dto.Description;
    }
    public UpdateFamilyRelationRequest CreateRequest()
    {
        return new UpdateFamilyRelationRequest
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description
        };
    }
    public bool HasChanges(UpdateFamilyRelationModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}