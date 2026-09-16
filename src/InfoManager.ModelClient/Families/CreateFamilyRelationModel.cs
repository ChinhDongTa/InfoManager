using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ModelClient.Families;

public class CreateFamilyRelationModel
{
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public CreateFamilyRelationRequest CreateRequest() => new()
    {
        Name = this.Name,
        Description = this.Description
    };
}