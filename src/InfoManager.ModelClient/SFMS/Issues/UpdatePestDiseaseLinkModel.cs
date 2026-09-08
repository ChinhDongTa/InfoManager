using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class UpdatePestDiseaseLinkModel
{
    /// <summary>ID liên kết. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID sâu hại.</summary>
    public string? PestId { get; set; }

    /// <summary>ID bệnh.</summary>
    public string? DiseaseId { get; set; }

    /// <summary>Mô tả quan hệ. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? RelationshipDescription { get; set; }

    public UpdatePestDiseaseLinkModel(string id, PestDiseaseLinkDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        PestId = dto.PestId;
        DiseaseId = dto.DiseaseId;
        RelationshipDescription = dto.RelationshipDescription;
    }

    public UpdatePestDiseaseLinkRequest CreateRequest()
    {
        return new UpdatePestDiseaseLinkRequest
        (
            Id: this.Id,
            PestId: this.PestId,
            DiseaseId: this.DiseaseId,
            RelationshipDescription: this.RelationshipDescription
        );
    }

    public bool HasChanges(UpdatePestDiseaseLinkModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
