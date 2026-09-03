namespace InfoManager.Domain.Entities.SFMS.Agricultural;

/// <summary>
/// Đại diện cho giai đoạn sinh trưởng của cây trồng (ví dụ: Sinh dưỡng, Ra hoa, Kết trái, Chín).
/// </summary>
public class GrowthStage : BaseAuditableEntity
{
    /// <summary>
    /// Tên giai đoạn (ví dụ: "Sinh dưỡng", "Ra hoa", "Kết trái", "Chín")
    /// </summary>
    [MaxLength(100)]
    public required string StageName { get; set; }

    /// <summary>
    /// ID loại cây trồng
    /// </summary>
    public required string CropId { get; set; }

    /// <summary>
    /// ID lịch trình trồng (tùy chọn)
    /// </summary>
    public string? CropScheduleId { get; set; }

    /// <summary>
    /// Số thứ tự giai đoạn (1, 2, 3...)
    /// </summary>
    public int StageSequence { get; set; }

    /// <summary>
    /// Số ngày sau khi trồng khi giai đoạn bắt đầu
    /// </summary>
    public int DaysAfterPlanting { get; set; }

    /// <summary>
    /// Thời gian kéo dài của giai đoạn (ngày)
    /// </summary>
    public int? StageDuration { get; set; }

    /// <summary>
    /// Mô tả giai đoạn sinh trưởng
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Nhiệt độ tối thiểu tối ưu (°C)
    /// </summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>
    /// Nhiệt độ tối đa tối ưu (°C)
    /// </summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>
    /// Độ ẩm tối thiểu tối ưu (%)
    /// </summary>
    public decimal? MinHumidity { get; set; }

    /// <summary>
    /// Độ ẩm tối đa tối ưu (%)
    /// </summary>
    public decimal? MaxHumidity { get; set; }

    /// <summary>
    /// Nhu cầu nước (mm mỗi ngày)
    /// </summary>
    public decimal? WaterRequirement { get; set; }

    /// <summary>
    /// Nhu cầu đạm (kg/ha)
    /// </summary>
    public decimal? NitrogenRequirement { get; set; }

    /// <summary>
    /// Nhu cầu lân (kg/ha)
    /// </summary>
    public decimal? PhosphorusRequirement { get; set; }

    /// <summary>
    /// Nhu cầu kali (kg/ha)
    /// </summary>
    public decimal? PotassiumRequirement { get; set; }

    /// <summary>
    /// Sâu bệnh phổ biến trong giai đoạn này
    /// </summary>
    [MaxLength(500)]
    public string? CommonPests { get; set; }

    /// <summary>
    /// Bệnh phổ biến trong giai đoạn này
    /// </summary>
    [MaxLength(500)]
    public string? CommonDiseases { get; set; }

    /// <summary>
    /// Các hoạt động quản lý trong giai đoạn này
    /// </summary>
    [MaxLength(1000)]
    public string? ManagementActivities { get; set; }

    // Navigation properties
    public virtual Crop? Crop { get; set; }
    public virtual CropSchedule? CropSchedule { get; set; }
    public virtual ICollection<GrowthStageAlert> Alerts { get; set; } = [];
}