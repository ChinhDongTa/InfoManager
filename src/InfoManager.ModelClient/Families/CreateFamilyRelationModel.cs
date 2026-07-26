using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ModelClient.Families;

public class CreateFamilyRelationModel
{
    [MaxLength(100)]
    [Required]
    /// <summary>
    /// Tên mối quan hệ (Ông cố nội, Bà cố nội, Ông cố ngoại, Bà cố ngoại, Ông nội, Bà nội, Ông ngoại, Bà ngoại, Cha, Mẹ, Con trai, Con gái)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public CreateFamilyRelationRequest CreateRequest()
    {
        return new CreateFamilyRelationRequest
        {
            Name = this.Name,
            Description = this.Description
        };
    }
}
