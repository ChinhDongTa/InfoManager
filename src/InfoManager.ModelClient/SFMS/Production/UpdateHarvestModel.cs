using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class UpdateHarvestModel
{
    /// <summary>ID thu hoạch. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>Ngày thu hoạch.</summary>
    public DateTimeOffset? HarvestDate { get; set; }

    /// <summary>Phương pháp thu hoạch. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? HarvestMethod { get; set; }

    /// <summary>Diện tích đã thu. > 0.</summary>
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal? HarvestedArea { get; set; }

    /// <summary>Tổng sản lượng. > 0.</summary>
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal? TotalQuantity { get; set; }

    /// <summary>Đơn vị sản lượng. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? QuantityUnit { get; set; }

    /// <summary>Năng suất / hecta. Không âm.</summary>
    [Range(0, double.MaxValue)]
    public decimal? YieldPerHectare { get; set; }

    /// <summary>Phân loại chất lượng. Tối đa 10 ký tự.</summary>
    [MaxLength(10)]
    public string? QualityGrade { get; set; }

    /// <summary>Người / tổ thu hoạch. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? HarvesterName { get; set; }

    /// <summary>Điều kiện thời tiết. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? WeatherCondition { get; set; }

    /// <summary>Tỷ lệ thất thoát (%). 0–100.</summary>
    [Range(0, 100)]
    public decimal? LossPercentage { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public UpdateHarvestModel(string id, HarvestDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        CropPlantingId = dto.CropPlantingId;
        HarvestDate = dto.HarvestDate;
        HarvestMethod = dto.HarvestMethod;
        HarvestedArea = dto.HarvestedArea;
        TotalQuantity = dto.TotalQuantity;
        QuantityUnit = dto.QuantityUnit;
        YieldPerHectare = dto.YieldPerHectare;
        QualityGrade = dto.QualityGrade;
        HarvesterName = dto.HarvesterName;
        WeatherCondition = dto.WeatherCondition;
        LossPercentage = dto.LossPercentage;
        Notes = dto.Notes;
        PhotoUrl = dto.PhotoUrl;
    }

    public UpdateHarvestRequest CreateRequest()
    {
        return new UpdateHarvestRequest
        (
            Id: this.Id,
            CropPlantingId: this.CropPlantingId,
            HarvestDate: this.HarvestDate,
            HarvestMethod: this.HarvestMethod,
            HarvestedArea: this.HarvestedArea,
            TotalQuantity: this.TotalQuantity,
            QuantityUnit: this.QuantityUnit,
            YieldPerHectare: this.YieldPerHectare,
            QualityGrade: this.QualityGrade,
            HarvesterName: this.HarvesterName,
            WeatherCondition: this.WeatherCondition,
            LossPercentage: this.LossPercentage,
            Notes: this.Notes,
            PhotoUrl: this.PhotoUrl
        );
    }

    public bool HasChanges(UpdateHarvestModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
