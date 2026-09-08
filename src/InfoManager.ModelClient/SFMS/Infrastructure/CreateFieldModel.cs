using InfoManager.Enum.SFMS;


namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class CreateFieldModel
{
    /// <summary>
    /// Tên thửa đất
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Mô tả
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Diện tích
    /// </summary>
    public decimal Area { get; set; }

    /// <summary>
    /// Nông trại sở hữu thửa đất
    /// </summary>
    [Required]
    public string FarmId { get; set; } = string.Empty;

    /// <summary>
    /// Loại đất
    /// </summary>
    public string? SoilType { get; set; }

    /// <summary>
    /// Tình trạng đất
    /// </summary>
    public SoilCondition? SoilCondition { get; set; }

    /// <summary>
    /// Độ cao
    /// </summary>
    public decimal? Elevation { get; set; }

    /// <summary>
    /// Vĩ độ
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// Kinh độ
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// Trạng thái thửa đất
    /// </summary>
    public FieldStatus Status { get; set; } = FieldStatus.Vacant;

    /// <summary>
    /// Ngày làm đất gần nhất
    /// </summary>
    public DateTimeOffset? LastPreparationDate { get; set; }

    /// <summary>
    /// Điều kiện thoát nước
    /// </summary>
    public string? DrainageCondition { get; set; }

    /// <summary>
    /// Có hệ thống tưới hay không
    /// </summary>
    public bool HasIrrigation { get; set; }

    public CreateFieldRequest CreateRequest()
    {
        return new CreateFieldRequest
        (
            Name: this.Name,
            Description: this.Description,
            Area: this.Area,
            FarmId: this.FarmId,
            SoilType: this.SoilType,
            SoilCondition: this.SoilCondition,
            Elevation: this.Elevation,
            Latitude: this.Latitude,
            Longitude: this.Longitude,
            Status: this.Status,
            LastPreparationDate: this.LastPreparationDate,
            DrainageCondition: this.DrainageCondition,
            HasIrrigation: this.HasIrrigation
        );
    }
}
