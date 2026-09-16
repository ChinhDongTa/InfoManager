namespace InfoManager.Domain.Entities.SFMS.Monitoring;

/// <summary>
/// Số liệu môi trường từ cảm biến (dữ liệu theo thời gian)
/// </summary>
public class EnvironmentalReading : BaseAuditableEntity
{
    /// <summary>
    /// ID cảm biến
    /// </summary>
    public string SensorId { get; set; }

    /// <summary>
    /// Thời điểm đo
    /// </summary>
    public DateTimeOffset ReadingTime { get; set; }

    /// <summary>
    /// Loại cảm biến
    /// </summary>
    public SensorType SensorType { get; set; }

    /// <summary>
    /// Giá trị đo
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Đơn vị đo
    /// </summary>
    [MaxLength(50)]
    public string Unit { get; set; }

    /// <summary>
    /// Chất lượng dữ liệu (Tốt, Cảnh báo, Lỗi)
    /// </summary>
    public DataQuality Quality { get; set; } = DataQuality.Good;

    /// <summary>
    /// Giá trị thô trước khi xử lý
    /// </summary>
    public decimal? RawValue { get; set; }

    /// <summary>
    /// Có nằm trong khoảng kỳ vọng hay không
    /// </summary>
    public bool IsWithinRange { get; set; } = true;

    /// <summary>
    /// Giá trị tối thiểu kỳ vọng
    /// </summary>
    public decimal? MinExpectedValue { get; set; }

    /// <summary>
    /// Giá trị tối đa kỳ vọng
    /// </summary>
    public decimal? MaxExpectedValue { get; set; }

    /// <summary>
    /// Ghi chú (lỗi cảm biến, hiệu chuẩn...)
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public virtual Sensor? Sensor { get; set; }
}