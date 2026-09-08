using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class UpdateCropModel
{
    /// <summary>ID cây trồng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thường gọi.</summary>
    public string? CommonName { get; set; }

    /// <summary>Tên khoa học.</summary>
    public string? ScientificName { get; set; }

    /// <summary>Mô tả.</summary>
    public string? Description { get; set; }

    /// <summary>Họ thực vật.</summary>
    public string? Family { get; set; }

    /// <summary>Số ngày đến thu hoạch.</summary>
    public int? DaysToMaturity { get; set; }

    /// <summary>Nhiệt độ tối thiểu.</summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>Nhiệt độ tối đa.</summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>Độ ẩm tối thiểu.</summary>
    public decimal? MinHumidity { get; set; }

    /// <summary>Độ ẩm tối đa.</summary>
    public decimal? MaxHumidity { get; set; }

    /// <summary>pH đất tối thiểu.</summary>
    public decimal? MinSoilPh { get; set; }

    /// <summary>pH đất tối đa.</summary>
    public decimal? MaxSoilPh { get; set; }

    /// <summary>Nhu cầu nước.</summary>
    public decimal? WaterRequirement { get; set; }

    /// <summary>Số giờ ánh sáng.</summary>
    public decimal? SunLightHours { get; set; }

    /// <summary>Đang hoạt động.</summary>
    public bool? IsActive { get; set; }

    public UpdateCropModel(string id, CropDto dto)
    {
        Id = id;
        CommonName = dto.CommonName;
        ScientificName = dto.ScientificName;
        Description = dto.Description;
        Family = dto.Family;
        DaysToMaturity = dto.DaysToMaturity;
        MinTemperature = dto.MinTemperature;
        MaxTemperature = dto.MaxTemperature;
        MinHumidity = dto.MinHumidity;
        MaxHumidity = dto.MaxHumidity;
        MinSoilPh = dto.MinSoilPh;
        MaxSoilPh = dto.MaxSoilPh;
        WaterRequirement = dto.WaterRequirement;
        SunLightHours = dto.SunLightHours;
        IsActive = dto.IsActive;
    }

    public UpdateCropRequest CreateRequest()
    {
        return new UpdateCropRequest
        (
            Id: this.Id,
            CommonName: this.CommonName,
            ScientificName: this.ScientificName,
            Description: this.Description,
            Family: this.Family,
            DaysToMaturity: this.DaysToMaturity,
            MinTemperature: this.MinTemperature,
            MaxTemperature: this.MaxTemperature,
            MinHumidity: this.MinHumidity,
            MaxHumidity: this.MaxHumidity,
            MinSoilPh: this.MinSoilPh,
            MaxSoilPh: this.MaxSoilPh,
            WaterRequirement: this.WaterRequirement,
            SunLightHours: this.SunLightHours,
            IsActive: this.IsActive
        );
    }

    public bool HasChanges(UpdateCropModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}