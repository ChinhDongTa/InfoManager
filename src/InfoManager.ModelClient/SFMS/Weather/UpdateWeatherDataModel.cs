using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Weather;

namespace InfoManager.ModelClient.SFMS.Weather;

public class UpdateWeatherDataModel
{
    /// <summary>ID bản ghi. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại liên quan.</summary>
    public string? FarmId { get; set; }

    /// <summary>Thời điểm ghi nhận dữ liệu.</summary>
    public DateTimeOffset? RecordingTime { get; set; }

    /// <summary>Nhiệt độ (°C).</summary>
    public decimal? Temperature { get; set; }

    /// <summary>Nhiệt độ tối thiểu (°C).</summary>
    public decimal? MinTemperature { get; set; }

    /// <summary>Nhiệt độ tối đa (°C).</summary>
    public decimal? MaxTemperature { get; set; }

    /// <summary>Độ ẩm (%).</summary>
    [Range(0, 100)]
    public decimal? Humidity { get; set; }

    /// <summary>Điểm sương (°C).</summary>
    public decimal? DewPoint { get; set; }

    /// <summary>Lượng mưa (mm).</summary>
    [Range(0, double.MaxValue)]
    public decimal? Rainfall { get; set; }

    /// <summary>Tốc độ gió (km/h).</summary>
    [Range(0, double.MaxValue)]
    public decimal? WindSpeed { get; set; }

    /// <summary>Hướng gió (độ).</summary>
    [Range(0, 360)]
    public decimal? WindDirection { get; set; }

    /// <summary>Tốc độ gió giật (km/h).</summary>
    [Range(0, double.MaxValue)]
    public decimal? WindGustSpeed { get; set; }

    /// <summary>Áp suất khí quyển (hPa).</summary>
    public decimal? Pressure { get; set; }

    /// <summary>Bức xạ mặt trời (W/m²).</summary>
    [Range(0, double.MaxValue)]
    public decimal? SolarRadiation { get; set; }

    /// <summary>Chỉ số UV.</summary>
    [Range(0, double.MaxValue)]
    public decimal? UVIndex { get; set; }

    /// <summary>Độ che phủ mây (%).</summary>
    [Range(0, 100)]
    public decimal? CloudCover { get; set; }

    /// <summary>Tầm nhìn (km).</summary>
    [Range(0, double.MaxValue)]
    public decimal? Visibility { get; set; }

    /// <summary>Mô tả điều kiện thời tiết.</summary>
    public string? WeatherCondition { get; set; }

    /// <summary>Nguồn dữ liệu.</summary>
    public string? DataSource { get; set; }

    /// <summary>Đánh giá chất lượng dữ liệu.</summary>
    public DataQuality? Quality { get; set; }

    public UpdateWeatherDataModel(string id, WeatherDataDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FarmId = dto.FarmId;
        RecordingTime = dto.RecordingTime;
        Temperature = dto.Temperature;
        MinTemperature = dto.MinTemperature;
        MaxTemperature = dto.MaxTemperature;
        Humidity = dto.Humidity;
        DewPoint = dto.DewPoint;
        Rainfall = dto.Rainfall;
        WindSpeed = dto.WindSpeed;
        WindDirection = dto.WindDirection;
        WindGustSpeed = dto.WindGustSpeed;
        Pressure = dto.Pressure;
        SolarRadiation = dto.SolarRadiation;
        UVIndex = dto.UVIndex;
        CloudCover = dto.CloudCover;
        Visibility = dto.Visibility;
        WeatherCondition = dto.WeatherCondition;
        DataSource = dto.DataSource;
        Quality = dto.Quality;
    }

    public UpdateWeatherDataRequest CreateRequest()
    {
        return new UpdateWeatherDataRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            RecordingTime: this.RecordingTime,
            Temperature: this.Temperature,
            MinTemperature: this.MinTemperature,
            MaxTemperature: this.MaxTemperature,
            Humidity: this.Humidity,
            DewPoint: this.DewPoint,
            Rainfall: this.Rainfall,
            WindSpeed: this.WindSpeed,
            WindDirection: this.WindDirection,
            WindGustSpeed: this.WindGustSpeed,
            Pressure: this.Pressure,
            SolarRadiation: this.SolarRadiation,
            UVIndex: this.UVIndex,
            CloudCover: this.CloudCover,
            Visibility: this.Visibility,
            WeatherCondition: this.WeatherCondition,
            DataSource: this.DataSource,
            Quality: this.Quality
        );
    }

    public bool HasChanges(UpdateWeatherDataModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}