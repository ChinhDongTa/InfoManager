using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Issues;

namespace InfoManager.ModelClient.SFMS.Issues;

public class UpdateDiseaseModel
{
    /// <summary>ID bệnh. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thông thường. Tối đa 100 ký tự.</summary>
    [MaxLength(100)]
    public string? CommonName { get; set; }

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? ScientificName { get; set; }

    /// <summary>Loại bệnh. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? DiseaseType { get; set; }

    /// <summary>Tác nhân gây bệnh. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? CausativeOrganism { get; set; }

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? AffectedCrops { get; set; }

    /// <summary>Triệu chứng. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Symptoms { get; set; }

    /// <summary>Điều kiện thuận lợi. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? FavorableConditions { get; set; }

    /// <summary>Con đường lây truyền. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? TransmissionMethod { get; set; }

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? PreventionMethods { get; set; }

    /// <summary>Biện pháp xử lý khuyến nghị. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? RecommendedTreatments { get; set; }

    /// <summary>Mức độ nghiêm trọng.</summary>
    public SeverityLevel? SeverityLevel { get; set; }

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public UpdateDiseaseModel(string id, DiseaseDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CommonName = dto.CommonName;
        ScientificName = dto.ScientificName;
        DiseaseType = dto.DiseaseType;
        CausativeOrganism = dto.CausativeOrganism;
        AffectedCrops = dto.AffectedCrops;
        Symptoms = dto.Symptoms;
        FavorableConditions = dto.FavorableConditions;
        TransmissionMethod = dto.TransmissionMethod;
        PreventionMethods = dto.PreventionMethods;
        RecommendedTreatments = dto.RecommendedTreatments;
        SeverityLevel = dto.SeverityLevel;
        ImageUrl = dto.ImageUrl;
    }

    public UpdateDiseaseRequest CreateRequest()
    {
        return new UpdateDiseaseRequest
        (
            Id: this.Id,
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            DiseaseType: this.DiseaseType,
            CausativeOrganism: this.CausativeOrganism,
            AffectedCrops: this.AffectedCrops,
            Symptoms: this.Symptoms,
            FavorableConditions: this.FavorableConditions,
            TransmissionMethod: this.TransmissionMethod,
            PreventionMethods: this.PreventionMethods,
            RecommendedTreatments: this.RecommendedTreatments,
            SeverityLevel: this.SeverityLevel,
            ImageUrl: this.ImageUrl
        );
    }

    public bool HasChanges(UpdateDiseaseModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}