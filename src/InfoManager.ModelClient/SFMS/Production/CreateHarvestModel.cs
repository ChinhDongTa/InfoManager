using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class CreateHarvestModel
{
    /// <summary>
    /// ID lần trồng
    /// </summary>
    [Required]
    public string CropPlantingId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày thu hoạch
    /// </summary>
    [Required]
    public DateTimeOffset HarvestDate { get; set; }

    /// <summary>
    /// Phương pháp thu hoạch
    /// </summary>
    [MaxLength(50)]
    public string? HarvestMethod { get; set; }

    /// <summary>
    /// Diện tích đã thu (hecta)
    /// </summary>
    [Required]
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal HarvestedArea { get; set; }

    /// <summary>
    /// Tổng sản lượng
    /// </summary>
    [Required]
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// Đơn vị sản lượng
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string QuantityUnit { get; set; } = string.Empty;

    /// <summary>
    /// Năng suất / hecta
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? YieldPerHectare { get; set; }

    /// <summary>
    /// Phân loại chất lượng
    /// </summary>
    [MaxLength(10)]
    public string? QualityGrade { get; set; }

    /// <summary>
    /// Người / tổ thu hoạch
    /// </summary>
    [MaxLength(200)]
    public string? HarvesterName { get; set; }

    /// <summary>
    /// Điều kiện thời tiết
    /// </summary>
    [MaxLength(200)]
    public string? WeatherCondition { get; set; }

    /// <summary>
    /// Tỷ lệ thất thoát (%)
    /// </summary>
    [Range(0, 100)]
    public decimal? LossPercentage { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    /// <summary>
    /// Đường dẫn ảnh
    /// </summary>
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }

    public CreateHarvestRequest CreateRequest()
    {
        return new CreateHarvestRequest
        (
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
}