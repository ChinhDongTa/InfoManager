using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class CreateCropCycleModel
{
    /// <summary>
    /// ID nông trại
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Tên chu kỳ
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string CycleName { get; set; } = string.Empty;

    /// <summary>
    /// ID cây trồng
    /// </summary>
    [Required]
    public string CropId { get; set; } = string.Empty;

    /// <summary>
    /// ID giống
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// ID lịch trồng
    /// </summary>
    public string? CropScheduleId { get; set; }

    /// <summary>
    /// Năm bắt đầu
    /// </summary>
    [Required]
    public int StartYear { get; set; }

    /// <summary>
    /// Mùa vụ
    /// </summary>
    [MaxLength(50)]
    public string? Season { get; set; }

    /// <summary>
    /// Ngày trồng dự kiến
    /// </summary>
    public DateTimeOffset? PlannedPlantingDate { get; set; }

    /// <summary>
    /// Ngày thu hoạch dự kiến
    /// </summary>
    public DateTimeOffset? PlannedHarvestDate { get; set; }

    /// <summary>
    /// Diện tích kế hoạch (hecta)
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal PlannedArea { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public CropCycleStatus Status { get; set; } = CropCycleStatus.Planned;

    /// <summary>
    /// Chi phí dự kiến
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? EstimatedCost { get; set; }

    /// <summary>
    /// Doanh thu dự kiến
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? EstimatedRevenue { get; set; }

    /// <summary>
    /// Lợi nhuận dự kiến
    /// </summary>
    public decimal? EstimatedProfit { get; set; }

    /// <summary>
    /// Sản lượng kỳ vọng
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Thị trường mục tiêu
    /// </summary>
    [MaxLength(300)]
    public string? TargetMarket { get; set; }

    /// <summary>
    /// Giá bán mục tiêu
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? TargetSellingPrice { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public CreateCropCycleRequest CreateRequest()
    {
        return new CreateCropCycleRequest
        (
            FarmId: this.FarmId,
            CycleName: this.CycleName,
            CropId: this.CropId,
            CropVarietyId: this.CropVarietyId,
            CropScheduleId: this.CropScheduleId,
            StartYear: this.StartYear,
            Season: this.Season,
            PlannedPlantingDate: this.PlannedPlantingDate,
            PlannedHarvestDate: this.PlannedHarvestDate,
            PlannedArea: this.PlannedArea,
            Status: this.Status,
            EstimatedCost: this.EstimatedCost,
            EstimatedRevenue: this.EstimatedRevenue,
            EstimatedProfit: this.EstimatedProfit,
            ExpectedYield: this.ExpectedYield,
            TargetMarket: this.TargetMarket,
            TargetSellingPrice: this.TargetSellingPrice,
            Notes: this.Notes
        );
    }
}
