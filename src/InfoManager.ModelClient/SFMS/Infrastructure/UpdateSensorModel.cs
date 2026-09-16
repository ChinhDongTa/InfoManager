using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateSensorModel
{
    /// <summary>ID cảm biến. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên cảm biến.</summary>
    public string? Name { get; set; }

    /// <summary>Loại cảm biến.</summary>
    public SensorType? SensorType { get; set; }

    /// <summary>Model cảm biến.</summary>
    public string? Model { get; set; }

    /// <summary>Số serial.</summary>
    public string? SerialNumber { get; set; }

    /// <summary>ID thửa đất.</summary>
    public string? FieldId { get; set; }

    /// <summary>ID thiết bị.</summary>
    public string? DeviceId { get; set; }

    /// <summary>Vĩ độ.</summary>
    public decimal? Latitude { get; set; }

    /// <summary>Kinh độ.</summary>
    public decimal? Longitude { get; set; }

    /// <summary>Độ sâu lắp đặt.</summary>
    public decimal? Depth { get; set; }

    /// <summary>Trạng thái thiết bị.</summary>
    public DeviceStatus? Status { get; set; }

    /// <summary>Thời điểm đọc dữ liệu gần nhất.</summary>
    public DateTimeOffset? LastReadingTime { get; set; }

    /// <summary>Mức pin.</summary>
    public decimal? BatteryLevel { get; set; }

    /// <summary>Cường độ tín hiệu.</summary>
    public decimal? SignalStrength { get; set; }

    /// <summary>Ngày hiệu chuẩn tiếp theo.</summary>
    public DateTimeOffset? NextCalibrationDate { get; set; }

    public UpdateSensorModel(string id, SensorDto dto)
    {
        Id = id;
        Name = dto.Name;
        SensorType = dto.SensorType;
        Model = dto.Model;
        SerialNumber = dto.SerialNumber;
        FieldId = dto.FieldId;
        DeviceId = dto.DeviceId;
        Latitude = dto.Latitude;
        Longitude = dto.Longitude;
        Depth = dto.Depth;
        Status = dto.Status;
        LastReadingTime = dto.LastReadingTime;
        BatteryLevel = dto.BatteryLevel;
        SignalStrength = dto.SignalStrength;
        NextCalibrationDate = dto.NextCalibrationDate;
    }

    public UpdateSensorRequest CreateRequest()
    {
        return new UpdateSensorRequest
        (
            Id: this.Id,
            Name: this.Name,
            SensorType: this.SensorType,
            Model: this.Model,
            SerialNumber: this.SerialNumber,
            FieldId: this.FieldId,
            DeviceId: this.DeviceId,
            Latitude: this.Latitude,
            Longitude: this.Longitude,
            Depth: this.Depth,
            Status: this.Status,
            LastReadingTime: this.LastReadingTime,
            BatteryLevel: this.BatteryLevel,
            SignalStrength: this.SignalStrength,
            NextCalibrationDate: this.NextCalibrationDate
        );
    }

    public bool HasChanges(UpdateSensorModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}