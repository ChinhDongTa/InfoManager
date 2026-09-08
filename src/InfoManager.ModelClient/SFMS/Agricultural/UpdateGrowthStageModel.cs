using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class UpdateGrowthStageModel
{
    /// <summary>ID giai đoạn sinh trưởng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên giai đoạn.</summary>
    public string? StageName { get; set; }

    /// <summary>ID cây trồng.</summary>
    public string? CropId { get; set; }

    /// <summary>ID lịch canh tác.</summary>
    public string? CropScheduleId { get; set; }

    /// <summary>Thứ tự giai đoạn.</summary>
    public int? StageSequence { get; set; }

    /// <summary>Số ngày sau khi trồng.</summary>
    public int? DaysAfterPlanting { get; set; }

    /// <summary>Thời gian kéo dài giai đoạn.</summary>
    public int? StageDuration { get; set; }

    /// <summary>Mô tả.</summary>
    public string? Description { get; set; }

    /// <summary>Nhiệt độ tối thiểu.</summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>Nhiệt độ tối đa.</summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>Độ ẩm tối thiểu.</summary>
    public decimal? MinHumidity { get; set; }

    /// <summary>Độ ẩm tối đa.</summary>
    public decimal? MaxHumidity { get; set; }

    /// <summary>Nhu cầu nước.</summary>
    public decimal? WaterRequirement { get; set; }

    /// <summary>Nhu cầu đạm.</summary>
    public decimal? NitrogenRequirement { get; set; }

    /// <summary>Nhu cầu lân.</summary>
    public decimal? PhosphorusRequirement { get; set; }

    /// <summary>Nhu cầu kali.</summary>
    public decimal? PotassiumRequirement { get; set; }

    /// <summary>Sâu hại thường gặp.</summary>
    public string? CommonPests { get; set; }

    /// <summary>Bệnh thường gặp.</summary>
    public string? CommonDiseases { get; set; }

    /// <summary>Hoạt động quản lý.</summary>
    public string? ManagementActivities { get; set; }

    public UpdateGrowthStageModel(string id, GrowthStageDto dto)
    {
        Id = id;
        StageName = dto.StageName;
        CropId = dto.CropId;
        CropScheduleId = dto.CropScheduleId;
        StageSequence = dto.StageSequence;
        DaysAfterPlanting = dto.DaysAfterPlanting;
        StageDuration = dto.StageDuration;
        Description = dto.Description;
        MinTemperature = dto.MinTemperature;
        MaxTemperature = dto.MaxTemperature;
        MinHumidity = dto.MinHumidity;
        MaxHumidity = dto.MaxHumidity;
        WaterRequirement = dto.WaterRequirement;
        NitrogenRequirement = dto.NitrogenRequirement;
        PhosphorusRequirement = dto.PhosphorusRequirement;
        PotassiumRequirement = dto.PotassiumRequirement;
        CommonPests = dto.CommonPests;
        CommonDiseases = dto.CommonDiseases;
        ManagementActivities = dto.ManagementActivities;
    }

    public UpdateGrowthStageRequest CreateRequest()
    {
        return new UpdateGrowthStageRequest
        (
            Id: this.Id,
            StageName: this.StageName,
            CropId: this.CropId,
            CropScheduleId: this.CropScheduleId,
            StageSequence: this.StageSequence,
            DaysAfterPlanting: this.DaysAfterPlanting,
            StageDuration: this.StageDuration,
            Description: this.Description,
            MinTemperature: this.MinTemperature,
            MaxTemperature: this.MaxTemperature,
            MinHumidity: this.MinHumidity,
            MaxHumidity: this.MaxHumidity,
            WaterRequirement: this.WaterRequirement,
            NitrogenRequirement: this.NitrogenRequirement,
            PhosphorusRequirement: this.PhosphorusRequirement,
            PotassiumRequirement: this.PotassiumRequirement,
            CommonPests: this.CommonPests,
            CommonDiseases: this.CommonDiseases,
            ManagementActivities: this.ManagementActivities
        );
    }

    public bool HasChanges(UpdateGrowthStageModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
