using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class CreatePestDiseaseLinkModel
{
    /// <summary>
    /// ID sâu hại
    /// </summary>
    [Required]
    public string PestId { get; set; } = string.Empty;

    /// <summary>
    /// ID bệnh
    /// </summary>
    [Required]
    public string DiseaseId { get; set; } = string.Empty;

    /// <summary>
    /// Mô tả quan hệ
    /// </summary>
    [MaxLength(500)]
    public string? RelationshipDescription { get; set; }

    public CreatePestDiseaseLinkRequest CreateRequest()
    {
        return new CreatePestDiseaseLinkRequest
        (
            PestId: this.PestId,
            DiseaseId: this.DiseaseId,
            RelationshipDescription: this.RelationshipDescription
        );
    }
}