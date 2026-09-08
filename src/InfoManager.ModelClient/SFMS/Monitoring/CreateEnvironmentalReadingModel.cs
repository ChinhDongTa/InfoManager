using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class CreateEnvironmentalReadingModel
{
    /// <summary>
    /// ID cảm biến
    /// </summary>
    [Required]
    public string SensorId { get; set; } = string.Empty;

    /// <summary>
    /// Thời điểm đo
    /// </summary>
    [Required]
    public DateTimeOffset ReadingTime { get; set; }

    /// <summary>
    /// Loại cảm biến
    /// </summary>
    [Required]
    public SensorType SensorType { get; set; }

    /// <summary>
    /// Giá trị đo
    /// </summary>
    [Required]
    public decimal Value { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// Chất lượng dữ liệu
    /// </summary>
    public DataQuality Quality { get; set; } = DataQuality.Good;

    /// <summary>
    /// Giá trị thô trước xử lý
    /// </summary>
    public decimal? RawValue { get; set; }

    /// <summary>
    /// Giá trị tối thiểu kỳ vọng
    /// </summary>
    public decimal? MinExpectedValue { get; set; }

    /// <summary>
    /// Giá trị tối đa kỳ vọng
    /// </summary>
    public decimal? MaxExpectedValue { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public CreateEnvironmentalReadingRequest CreateRequest()
    {
        return new CreateEnvironmentalReadingRequest
        (
            SensorId: this.SensorId,
            ReadingTime: this.ReadingTime,
            SensorType: this.SensorType,
            Value: this.Value,
            Unit: this.Unit,
            Quality: this.Quality,
            RawValue: this.RawValue,
            MinExpectedValue: this.MinExpectedValue,
            MaxExpectedValue: this.MaxExpectedValue,
            Notes: this.Notes
        );
    }
}