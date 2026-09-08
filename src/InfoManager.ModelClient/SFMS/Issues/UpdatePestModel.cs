using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class UpdatePestModel
{
    /// <summary>ID sâu hại. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thông thường. Tối đa 100 ký tự.</summary>
    [MaxLength(100)]
    public string? CommonName { get; set; }

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? ScientificName { get; set; }

    /// <summary>Loại sâu hại. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? PestType { get; set; }

    /// <summary>Mô tả. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>Triệu chứng gây hại. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? DamageSymptoms { get; set; }

    /// <summary>Vòng đời. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? LifeCycle { get; set; }

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? PreventionMethods { get; set; }

    /// <summary>Thuốc BVTV khuyến nghị. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? RecommendedPesticides { get; set; }

    /// <summary>Biện pháp sinh học. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? BiologicalControl { get; set; }

    /// <summary>Mức độ nghiêm trọng.</summary>
    public SeverityLevel? SeverityLevel { get; set; }

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public UpdatePestModel(string id, PestDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CommonName = dto.CommonName;
        ScientificName = dto.ScientificName;
        PestType = dto.PestType;
        Description = dto.Description;
        AffectedCrops = dto.AffectedCrops;
        DamageSymptoms = dto.DamageSymptoms;
        LifeCycle = dto.LifeCycle;
        PreventionMethods = dto.PreventionMethods;
        RecommendedPesticides = dto.RecommendedPesticides;
        BiologicalControl = dto.BiologicalControl;
        SeverityLevel = dto.SeverityLevel;
        ImageUrl = dto.ImageUrl;
    }

    public UpdatePestRequest CreateRequest()
    {
        return new UpdatePestRequest
        (
            Id: this.Id,
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            PestType: this.PestType,
            Description: this.Description,
            AffectedCrops: this.AffectedCrops,
            DamageSymptoms: this.DamageSymptoms,
            LifeCycle: this.LifeCycle,
            PreventionMethods: this.PreventionMethods,
            RecommendedPesticides: this.RecommendedPesticides,
            BiologicalControl: this.BiologicalControl,
            SeverityLevel: this.SeverityLevel,
            ImageUrl: this.ImageUrl
        );
    }

    public bool HasChanges(UpdatePestModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
