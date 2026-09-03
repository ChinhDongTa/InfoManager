using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Query/Command của Sensor.
/// </summary>
public static class SensorMappings
{
    public static SearchSensorsQuery ToSearchQuery(SearchSensorsRequest request)
        => new(
            Term : request.Term,
            FieldId : request.FieldId,
            DeviceId : request.DeviceId,
            SensorType : request.SensorType,
            Status : request.Status,
            StartInstallationDate : request.StartInstallationDate,
            EndInstallationDate : request.EndInstallationDate,
            PageNumber : request.PageNumber,
            PageSize : request.PageSize
        );

    public static CreateSensorCommand ToCreateCommand(CreateSensorRequest request)
        => new()
        {
            Name = request.Name,
            SensorType = request.SensorType,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            FieldId = request.FieldId,
            DeviceId = request.DeviceId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Depth = request.Depth,
            Status = request.Status,
            InstallationDate = request.InstallationDate,
            NextCalibrationDate = request.NextCalibrationDate
        };

    public static UpdateSensorCommand ToUpdateCommand(UpdateSensorRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            SensorType = request.SensorType,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            FieldId = request.FieldId,
            DeviceId = request.DeviceId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Depth = request.Depth,
            Status = request.Status,
            LastReadingTime = request.LastReadingTime,
            BatteryLevel = request.BatteryLevel,
            SignalStrength = request.SignalStrength,
            NextCalibrationDate = request.NextCalibrationDate
        };
}