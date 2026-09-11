using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.ModelClient.SFMS.Planning;

public class UpdateCropCycleModel
{
    /// <summary>ID chu kỳ. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>Tên chu kỳ. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? CycleName { get; set; }

    /// <summary>ID cây trồng.</summary>
    public string? CropId { get; set; }

    /// <summary>ID giống.</summary>
    public string? CropVarietyId { get; set; }

    /// <summary>ID lịch trồng.</summary>
    public string? CropScheduleId { get; set; }

    /// <summary>Năm bắt đầu.</summary>
    public int? StartYear { get; set; }

    /// <summary>Mùa vụ. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? Season { get; set; }

    /// <summary>Ngày trồng dự kiến.</summary>
    public DateTimeOffset? PlannedPlantingDate { get; set; }

    /// <summary>Ngày thu hoạch dự kiến.</summary>
    public DateTimeOffset? PlannedHarvestDate { get; set; }

    /// <summary>Diện tích kế hoạch. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? PlannedArea { get; set; }

    /// <summary>Trạng thái.</summary>
    public CropCycleStatus? Status { get; set; }

    /// <summary>Chi phí dự kiến. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? EstimatedCost { get; set; }

    /// <summary>Doanh thu dự kiến. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? EstimatedRevenue { get; set; }

    /// <summary>Lợi nhuận dự kiến.</summary>
    public decimal? EstimatedProfit { get; set; }

    /// <summary>Sản lượng kỳ vọng. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? ExpectedYield { get; set; }

    /// <summary>Thị trường mục tiêu. Tối đa 300 ký tự.</summary>
    [MaxLength(300)]
    public string? TargetMarket { get; set; }

    /// <summary>Giá bán mục tiêu. ≥ 0.</summary>
    [Range(0, double.MaxValue)]
    public decimal? TargetSellingPrice { get; set; }

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    [MaxLength(1000)]
    public string? Notes { get; set; }

    public UpdateCropCycleModel(string id, CropCycleDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FarmId = dto.FarmId;
        CycleName = dto.CycleName;
        CropId = dto.CropId;
        CropVarietyId = dto.CropVarietyId;
        CropScheduleId = dto.CropScheduleId;
        StartYear = dto.StartYear;
        Season = dto.Season;
        PlannedPlantingDate = dto.PlannedPlantingDate;
        PlannedHarvestDate = dto.PlannedHarvestDate;
        PlannedArea = dto.PlannedArea;
        Status = dto.Status;
        EstimatedCost = dto.EstimatedCost;
        EstimatedRevenue = dto.EstimatedRevenue;
        EstimatedProfit = dto.EstimatedProfit;
        ExpectedYield = dto.ExpectedYield;
        TargetMarket = dto.TargetMarket;
        TargetSellingPrice = dto.TargetSellingPrice;
        Notes = dto.Notes;
    }

    public UpdateCropCycleRequest CreateRequest()
    {
        return new UpdateCropCycleRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateCropCycleModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
