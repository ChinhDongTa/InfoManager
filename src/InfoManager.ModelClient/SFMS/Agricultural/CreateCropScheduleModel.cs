using InfoManager.Shared.Dtos.SFMS.Agricultural;

namespace InfoManager.ModelClient.SFMS.Agricultural;

public class CreateCropScheduleModel
{
    /// <summary>
    /// Tên lịch canh tác
    /// </summary>
    [Required]
    public string ScheduleName { get; set; } = string.Empty;

    /// <summary>
    /// Cây trồng
    /// </summary>
    [Required]
    public string CropId { get; set; } = string.Empty;

    /// <summary>
    /// Giống cây trồng
    /// </summary>
    public string? CropVarietyId { get; set; }

    /// <summary>
    /// Mùa vụ
    /// </summary>
    public string? PlantingSeason { get; set; }

    /// <summary>
    /// Khoảng thời gian gieo trồng
    /// </summary>
    public string? PlantingDateRange { get; set; }

    /// <summary>
    /// Khoảng thời gian thu hoạch
    /// </summary>
    public string? HarvestDateRange { get; set; }

    /// <summary>
    /// Số ngày đến thu hoạch
    /// </summary>
    public int DaysToHarvest { get; set; }

    /// <summary>
    /// Khoảng cách cây
    /// </summary>
    public decimal? PlantSpacing { get; set; }

    /// <summary>
    /// Khoảng cách hàng
    /// </summary>
    public decimal? RowSpacing { get; set; }

    /// <summary>
    /// Lịch tưới
    /// </summary>
    public string? IrrigationSchedule { get; set; }

    /// <summary>
    /// Lịch bón phân
    /// </summary>
    public string? FertilizationSchedule { get; set; }

    /// <summary>
    /// Lịch phun thuốc
    /// </summary>
    public string? PesticideSchedule { get; set; }

    /// <summary>
    /// Năng suất dự kiến
    /// </summary>
    public decimal? ExpectedYield { get; set; }

    /// <summary>
    /// Chi phí ước tính
    /// </summary>
    public decimal? EstimatedCost { get; set; }

    /// <summary>
    /// Đang hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    public CreateCropScheduleRequest CreateRequest()
    {
        return new CreateCropScheduleRequest
        (
            ScheduleName: this.ScheduleName,
            CropId: this.CropId,
            CropVarietyId: this.CropVarietyId,
            PlantingSeason: this.PlantingSeason,
            PlantingDateRange: this.PlantingDateRange,
            HarvestDateRange: this.HarvestDateRange,
            DaysToHarvest: this.DaysToHarvest,
            PlantSpacing: this.PlantSpacing,
            RowSpacing: this.RowSpacing,
            IrrigationSchedule: this.IrrigationSchedule,
            FertilizationSchedule: this.FertilizationSchedule,
            PesticideSchedule: this.PesticideSchedule,
            ExpectedYield: this.ExpectedYield,
            EstimatedCost: this.EstimatedCost,
            IsActive: this.IsActive,
            Notes: this.Notes
        );
    }
}