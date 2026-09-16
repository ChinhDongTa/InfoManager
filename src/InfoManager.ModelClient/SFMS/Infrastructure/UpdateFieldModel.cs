using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateFieldModel
{
    /// <summary>ID thửa đất. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thửa đất.</summary>
    public string? Name { get; set; }

    /// <summary>Mô tả.</summary>
    public string? Description { get; set; }

    /// <summary>Diện tích.</summary>
    public decimal? Area { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>Loại đất.</summary>
    public string? SoilType { get; set; }

    /// <summary>Tình trạng đất.</summary>
    public SoilCondition? SoilCondition { get; set; }

    /// <summary>Độ cao.</summary>
    public decimal? Elevation { get; set; }

    /// <summary>Vĩ độ.</summary>
    public decimal? Latitude { get; set; }

    /// <summary>Kinh độ.</summary>
    public decimal? Longitude { get; set; }

    /// <summary>Trạng thái thửa đất.</summary>
    public FieldStatus? Status { get; set; }

    /// <summary>Ngày làm đất gần nhất.</summary>
    public DateTimeOffset? LastPreparationDate { get; set; }

    /// <summary>Điều kiện thoát nước.</summary>
    public string? DrainageCondition { get; set; }

    /// <summary>Có hệ thống tưới hay không.</summary>
    public bool? HasIrrigation { get; set; }

    public UpdateFieldModel(string id, FieldDto dto)
    {
        Id = id;
        Name = dto.Name;
        Description = dto.Description;
        Area = dto.Area;
        FarmId = dto.FarmId;
        SoilType = dto.SoilType;
        SoilCondition = dto.SoilCondition;
        Elevation = dto.Elevation;
        Latitude = dto.Latitude;
        Longitude = dto.Longitude;
        Status = dto.Status;
        LastPreparationDate = dto.LastPreparationDate;
        DrainageCondition = dto.DrainageCondition;
        HasIrrigation = dto.HasIrrigation;
    }

    public UpdateFieldRequest CreateRequest()
    {
        return new UpdateFieldRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateFieldModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}