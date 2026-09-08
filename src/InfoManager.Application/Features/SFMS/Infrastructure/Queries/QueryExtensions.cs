using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries;

internal static class QueryExtensions
{
    //===================================Device Queryable Extensions===================================================
    public static IQueryable<DeviceDto> ToDeviceDto(this IQueryable<Device> query)
    {
        return query.Select(d => new DeviceDto(
             Id: d.Id,
             Name: d.Name,
             DeviceType: d.DeviceType,
             DeviceTypeName: d.DeviceType.ToDisplayName(),
             Model: d.Model,
             MacAddress: d.MacAddress,
             FarmId: d.FarmId,
             FarmName: d.Farm != null ? d.Farm.Name : null,
             Status:d.Status,
             StatusName: d.Status.ToDisplayName(),
             IpAddress: d.IpAddress,
             CommunicationProtocol: d.CommunicationProtocol,
             LastDataSyncTime: d.LastDataSyncTime,
             FirmwareVersion: d.FirmwareVersion,
             BatteryLevel: d.BatteryLevel,
             StorageCapacity: d.StorageCapacity,
             StorageUsed: d.StorageUsed,
             InstallationDate: d.InstallationDate,
             LastMaintenanceDate: d.LastMaintenanceDate,
             Notes: d.Notes,
             Created: d.Created
            ));
    }

    public static IQueryable<DeviceSummaryDto> ToDeviceSummaryDto(this IQueryable<Device> query)
    {
        return query.Select(d => new DeviceSummaryDto(
             Id: d.Id,
             Name: d.Name,
             DeviceTypeName: d.DeviceType.ToDisplayName(),
             Model: d.Model,
             FarmName: d.Farm != null ? d.Farm.Name : null,
             StatusName: d.Status.ToDisplayName(),
             BatteryLevel: d.BatteryLevel,
             LastDataSyncTime: d.LastDataSyncTime
            ));
    }

    public static IQueryable<Device> BuildSearchQuery(this IQueryable<Device> query, SearchDevicesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(d => EF.Functions.ILike(d.Name, term)
            || (d.Model != null && EF.Functions.ILike(d.Model, term))
            || (d.MacAddress != null && EF.Functions.ILike(d.MacAddress, term))
            || (d.IpAddress != null && EF.Functions.ILike(d.IpAddress, term))
            || (d.FirmwareVersion != null && EF.Functions.ILike(d.FirmwareVersion, term))
            || (d.Notes != null && EF.Functions.ILike(d.Notes, term))
            || (d.CommunicationProtocol != null && EF.Functions.ILike(d.CommunicationProtocol, term))
            );
        }
        if (search.DeviceType.HasValue)
        {
            query = query.Where(d => d.DeviceType == search.DeviceType.Value);
        }
        if (search.DeviceStatus.HasValue)
        {
            query = query.Where(d => d.Status == search.DeviceStatus.Value);
        }
        if (search.StartInstallationDate.HasValue)
        {
            query = query.Where(d => d.InstallationDate >= search.StartInstallationDate.Value);
        }
        if (search.EndInstallationDate.HasValue)
        {
            query = query.Where(d => d.InstallationDate <= search.EndInstallationDate.Value);
        }
        if (search.StartLastMaintenanceDate.HasValue)
        {
            query = query.Where(d => d.LastMaintenanceDate.HasValue && d.LastMaintenanceDate.Value >= search.StartLastMaintenanceDate.Value);
        }
        if (search.EndLastMaintenanceDate.HasValue)
        {
            query = query.Where(d => d.LastMaintenanceDate.HasValue && d.LastMaintenanceDate.Value <= search.EndLastMaintenanceDate.Value);
        }

        return query;
    }

    /// <summary>
    /// Applies sorting to the Device query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">name, devicetype, status</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Device> ApplySorting(this IQueryable<Device> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.DeviceType);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "devicetype" => ascending ? query.OrderBy(a => a.DeviceType) : query.OrderByDescending(a => a.DeviceType),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    //===============================DeviceAlert Queryable Extensions================================================

    public static IQueryable<DeviceAlertDto> ToDeviceAlertDto(this IQueryable<DeviceAlert> query)
    {
        return query.Select(d => new DeviceAlertDto(
             Id: d.Id,
             DeviceId: d.DeviceId,
             DeviceName: d.Device != null ? d.Device.Name : null,
             AlertType:d.AlertType,
             AlertTypeName: d.AlertType.ToDisplayName(),
             Message: d.Message,
             Severity: d.Severity,
             SeverityName: d.Severity.ToDisplayName(),
             AlertTime: d.AlertTime,
             ResolvedTime: d.ResolvedTime,
             IsResolved: d.IsResolved,
             ResolutionNotes: d.ResolutionNotes,
             Created: d.Created
            ));
    }

    public static IQueryable<DeviceAlertSummaryDto> ToDeviceAlertSummaryDto(this IQueryable<DeviceAlert> query)
    {
        return query.Select(d => new DeviceAlertSummaryDto(
             Id: d.Id,
             DeviceName: d.Device != null ? d.Device.Name : null,
             AlertTypeName: d.AlertType.ToDisplayName(),
             Message: d.Message,
             SeverityName: d.Severity.ToDisplayName(),
             AlertTime: d.AlertTime,
             IsResolved: d.IsResolved
            ));
    }

    public static IQueryable<DeviceAlert> BuildSearchQuery(this IQueryable<DeviceAlert> query, SearchDeviceAlertsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(d => EF.Functions.ILike(d.Message, term)
            || (d.ResolutionNotes != null && EF.Functions.ILike(d.ResolutionNotes, term))
            );
        }
        if (search.AlertType.HasValue)
        {
            query = query.Where(d => d.AlertType == search.AlertType.Value);
        }
        if (search.Severity.HasValue)
        {
            query = query.Where(d => d.Severity == search.Severity.Value);
        }
        if (search.IsResolved.HasValue)
        {
            query = query.Where(d => d.IsResolved == search.IsResolved.Value);
        }
        if (search.StartAlertTime.HasValue)
        {
            query = query.Where(d => d.AlertTime >= search.StartAlertTime.Value);
        }
        if (search.EndAlertTime.HasValue)
        {
            query = query.Where(d => d.AlertTime <= search.EndAlertTime.Value);
        }
        return query;
    }

    /// <summary>
    /// Applies sorting to the DeviceAlert query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">alerttype, alerttime, severity</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<DeviceAlert> ApplySorting(this IQueryable<DeviceAlert> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderBy(a => a.IsResolved)
                .ThenByDescending(a => a.Created)
                .ThenByDescending(a => a.AlertTime);
        }
        return sortBy.ToLower() switch
        {
            "alerttype" => ascending ? query.OrderBy(a => a.AlertType) : query.OrderByDescending(a => a.AlertType),
            "alerttime" => ascending ? query.OrderBy(a => a.AlertTime) : query.OrderByDescending(a => a.AlertTime),
            "severity" => ascending ? query.OrderBy(a => a.Severity) : query.OrderByDescending(a => a.Severity),
            _ => query
        };
    }

    //===============================Equipment Queryable Extensions==============================================

    public static IQueryable<EquipmentDto> ToEquipmentDto(this IQueryable<Equipment> query)
    {
        return query.Select(e => new EquipmentDto(
             Id: e.Id,
             Name: e.Name,
             EquipmentType: e.EquipmentType,
             EquipmentTypeName: e.EquipmentType.ToDisplayName(),
             FarmId: e.FarmId,
             FarmName: e.Farm != null ? e.Farm.Name : null,
             Manufacturer: e.Manufacturer,
             Model: e.Model,
             SerialNumber: e.SerialNumber,
             PowerRating: e.PowerRating,
             Specifications: e.Specifications,
             PurchaseDate: e.PurchaseDate,
             PurchaseCost: e.PurchaseCost,
             CurrentValue: e.CurrentValue,
             Status: e.Status,
             StatusName: e.Status.ToDisplayName(),
             OperatingHours: e.OperatingHours,
             LastMaintenanceDate: e.LastMaintenanceDate,
             NextMaintenanceDate: e.NextMaintenanceDate,
             StorageLocation: e.StorageLocation,
             Notes: e.Notes,
             Created: e.Created
            ));
    }

    public static IQueryable<EquipmentSummaryDto> ToEquipmentSummaryDto(this IQueryable<Equipment> query)
    {
        return query.Select(e => new EquipmentSummaryDto(
             Id: e.Id,
             Name: e.Name,
             EquipmentTypeName: e.EquipmentType.ToDisplayName(),
             FarmName: e.Farm != null ? e.Farm.Name : null,
             StatusName: e.Status.ToDisplayName(),
             OperatingHours: e.OperatingHours,
             LastMaintenanceDate: e.LastMaintenanceDate,
             StorageLocation: e.StorageLocation
            ));
    }

    public static IQueryable<Equipment> BuildSearchQuery(this IQueryable<Equipment> query, SearchEquipmentsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(e => EF.Functions.ILike(e.Name, term)
            || (e.Manufacturer != null && EF.Functions.ILike(e.Manufacturer, term))
            || (e.Model != null && EF.Functions.ILike(e.Model, term))
            || (e.SerialNumber != null && EF.Functions.ILike(e.SerialNumber, term))
            );
        }
        if (search.EquipmentType.HasValue)
        {
            query = query.Where(e => e.EquipmentType == search.EquipmentType.Value);
        }
        if (!string.IsNullOrEmpty(search.FarmId))
        {
            query = query.Where(e => e.FarmId == search.FarmId);
        }
        if (search.Status.HasValue)
        {
            query = query.Where(e => e.Status == search.Status.Value);
        }
        if (search.LastMaintenanceDateFrom.HasValue)
        {
            query = query.Where(e => e.LastMaintenanceDate.HasValue && e.LastMaintenanceDate.Value >= search.LastMaintenanceDateFrom.Value);
        }
        if (search.LastMaintenanceDateTo.HasValue)
        {
            query = query.Where(e => e.LastMaintenanceDate.HasValue && e.LastMaintenanceDate.Value <= search.LastMaintenanceDateTo.Value);
        }
        if (search.NextMaintenanceDateFrom.HasValue)
        {
            query = query.Where(e => e.NextMaintenanceDate.HasValue && e.NextMaintenanceDate.Value >= search.NextMaintenanceDateFrom.Value);
        }
        if (search.NextMaintenanceDateTo.HasValue)
        {
            query = query.Where(e => e.NextMaintenanceDate.HasValue && e.NextMaintenanceDate.Value <= search.NextMaintenanceDateTo.Value);
        }
        return query;
    }

    /// <summary>
    /// Applies sorting to the Equipment query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">The field to sort by: name, equipmenttype, status</param>
    /// <param name="ascending">Whether to sort in ascending order</param>
    /// <returns></returns>
    public static IQueryable<Equipment> ApplySorting(this IQueryable<Equipment> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.EquipmentType);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "equipmenttype" => ascending ? query.OrderBy(a => a.EquipmentType) : query.OrderByDescending(a => a.EquipmentType),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    //===============================Farm Queryable Extensions================================================

    public static IQueryable<FarmDto> ToFarmDto(this IQueryable<Farm> query)
    {
        return query.Select(f => new FarmDto(
            Id: f.Id,
            Name: f.Name,
            Description: f.Description,
            TotalArea: f.TotalArea,
            CultivableArea: f.CultivableArea,
            Location: f.Location,
            Latitude: f.Latitude,
            Longitude: f.Longitude,
            FarmerId: f.FarmerId,
            FarmerName: f.Farmer != null ? f.Farmer.FullName : null,
            LicenseNumber: f.LicenseNumber,
            Status: f.Status,
            StatusName: f.Status.ToDisplayName(),
            EstablishedDate: f.EstablishedDate,
            Created: f.Created
            ));
    }
    public static IQueryable<FarmSummaryDto> ToFarmSummaryDto(this IQueryable<Farm> query)
    {
        return query.Select(f => new FarmSummaryDto(
            Id: f.Id,
            Name: f.Name,
            Location: f.Location,
            TotalArea: f.TotalArea,
            CultivableArea: f.CultivableArea,
            StatusName: f.Status.ToDisplayName()
            ));
    }

    public static IQueryable<Farm> BuildSearchQuery(this IQueryable<Farm> query, SearchFarmsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(f => EF.Functions.ILike(f.Name, term)
            || (f.Description != null && EF.Functions.ILike(f.Description, term))
            || (f.Location != null && EF.Functions.ILike(f.Location, term))
            || (f.LicenseNumber != null && EF.Functions.ILike(f.LicenseNumber, term))
            );
        }
        if (search.Status.HasValue)
        {
            query = query.Where(f => f.Status == search.Status.Value);
        }
        if (search.MinCultivableArea.HasValue)
        {
            query = query.Where(f => f.CultivableArea >= search.MinCultivableArea.Value);
        }
        if (search.MaxCultivableArea.HasValue)
        {
            query = query.Where(f => f.CultivableArea <= search.MaxCultivableArea.Value);
        }
        return query;
    }

    /// <summary>
    /// Applies sorting to the Farm query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">name, status, cultivablearea</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Farm> ApplySorting(this IQueryable<Farm> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.Name);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "cultivablearea" => ascending ? query.OrderBy(a => a.CultivableArea) : query.OrderByDescending(a => a.CultivableArea),
            _ => query
        };
    }

    //===============================Farmer Queryable Extensions================================================
    public static IQueryable<FarmerDto> ToFarmerDto(this IQueryable<Farmer> query)
    {
        return query.Select(f => new FarmerDto(
            Id: f.Id,
            FarmerCode: f.FarmerCode,
            FullName: f.FullName,
            FamilyMemberId: f.FamilyMemberId,
            Phone: f.Phone,
            Email: f.Email,
            IdentityNumber: f.IdentityNumber,
            Address: f.Address,
            Notes: f.Notes,
            Created: f.Created
        ));
    }
    public static IQueryable<FarmerSummaryDto> ToFarmerSummaryDto(this IQueryable<Farmer> query)
    {
        return query.Select(f => new FarmerSummaryDto(
            Id: f.Id,
            FarmerCode: f.FarmerCode,
            FullName: f.FullName,
            Phone: f.Phone,
            Email: f.Email
        ));
    }

    public static IQueryable<Farmer> BuildSearchQuery(this IQueryable<Farmer> query, SearchFarmersQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(f => EF.Functions.ILike(f.FullName, term)
            || (f.FarmerCode != null && EF.Functions.ILike(f.FarmerCode, term))
            || (f.Phone != null && EF.Functions.ILike(f.Phone, term))
            || (f.Email != null && EF.Functions.ILike(f.Email, term))
            || (f.IdentityNumber != null && EF.Functions.ILike(f.IdentityNumber, term))
            || (f.Address != null && EF.Functions.ILike(f.Address, term))
            );
        }
        return query;
    }
    /// <summary>
    /// Applies sorting to the Farmer query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">fullname, farmercode</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Farmer> ApplySorting(this IQueryable<Farmer> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.FullName);
        }
        return sortBy.ToLower() switch
        {
            "fullname" => ascending ? query.OrderBy(a => a.FullName) : query.OrderByDescending(a => a.FullName),
            "farmercode" => ascending ? query.OrderBy(a => a.FarmerCode) : query.OrderByDescending(a => a.FarmerCode),
            _ => query
        };
    }

    //===============================Field Queryable Extensions================================================

    public static IQueryable<FieldDto> ToFieldDto(this IQueryable<Field> query)
    {
        return query.Select(f => new FieldDto(
            Id: f.Id,
            Name: f.Name,
            Description: f.Description,
            Area: f.Area,
            FarmId: f.FarmId,
            FarmName: f.Farm != null ? f.Farm.Name : null,
            SoilType: f.SoilType,
            SoilCondition: f.SoilCondition,
            SoilConditionName: f.SoilCondition!=null? f.SoilCondition.ToDisplayName():null,
            Elevation: f.Elevation,
            Latitude: f.Latitude,
            Longitude: f.Longitude,
            Status: f.Status,
            StatusName: f.Status.ToDisplayName(),
            LastPreparationDate: f.LastPreparationDate,
            DrainageCondition: f.DrainageCondition,
            HasIrrigation: f.HasIrrigation,
            CropPlantingCount: f.CropPlantings.Count(),
            SensorCount: f.Sensors.Count(),
            SoilAnalysisCount: f.SoilAnalyses.Count(),
            TaskCount: f.Tasks.Count(),
            Created: f.Created
        ));
    }

    public static IQueryable<FieldSummaryDto> ToFieldSummaryDto(this IQueryable<Field> query)
    {
        return query.Select(f => new FieldSummaryDto(
            Id: f.Id,
            Name: f.Name,
            FarmName: f.Farm != null ? f.Farm.Name : null,
            Area: f.Area,
            SoilType: f.SoilType,
            SoilConditionName: f.SoilCondition != null ? f.SoilCondition.ToDisplayName() : null,
            StatusName: f.Status.ToDisplayName(),
            HasIrrigation: f.HasIrrigation
        ));
    }

    public static IQueryable<Field> BuildSearchQuery(this IQueryable<Field> query, SearchFieldsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(f => EF.Functions.ILike(f.Name, term)
            || (f.Description != null && EF.Functions.ILike(f.Description, term))
            || (f.SoilType != null && EF.Functions.ILike(f.SoilType, term))
            || (f.DrainageCondition != null && EF.Functions.ILike(f.DrainageCondition, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FarmId))
        {
            query = query.Where(f => f.FarmId == search.FarmId);
        }
        if (search.SoilCondition.HasValue)
        {
            query = query.Where(f => f.SoilCondition == search.SoilCondition.Value);
        }
        if (search.Status.HasValue)
        {
            query = query.Where(f => f.Status == search.Status.Value);
        }
        if (search.StartLastPreparationDate.HasValue)
        {
            query = query.Where(f => f.LastPreparationDate.HasValue && f.LastPreparationDate.Value >= search.StartLastPreparationDate.Value);
        }
        if (search.EndLastPreparationDate.HasValue)
        {
            query = query.Where(f => f.LastPreparationDate.HasValue && f.LastPreparationDate.Value <= search.EndLastPreparationDate.Value);
        }
        if (search.HasIrrigation.HasValue)
        {
            query = query.Where(f => f.HasIrrigation == search.HasIrrigation.Value);
        }
        return query;
    }

    /// <summary>
    /// Applies sorting to the Field query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">The field to sort by: "name", "status", "soilcondition"</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Field> ApplySorting(this IQueryable<Field> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.Name);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "soilcondition" => ascending ? query.OrderBy(a => a.SoilCondition) : query.OrderByDescending(a => a.SoilCondition),
            _ => query
        };
    }

    //===============================Sensor Queryable Extensions================================================

    public static IQueryable<SensorDto> ToSensorDto(this IQueryable<Sensor> query)
    {
        return query.Select(s => new SensorDto(
            Id: s.Id,
            Name: s.Name,
            SensorType: s.SensorType,
            SensorTypeName: s.SensorType.ToDisplayName(),
            Model: s.Model,
            SerialNumber: s.SerialNumber,
            FieldId: s.FieldId,
            FieldName: s.Field != null ? s.Field.Name : null,
            DeviceId: s.DeviceId,
            DeviceName: s.Device != null ? s.Device.Name : null,
            Latitude: s.Latitude,
            Longitude: s.Longitude,
            Depth: s.Depth,
            Status:s.Status,
            StatusName: s.Status.ToDisplayName(),
            LastReadingTime: s.LastReadingTime,
            BatteryLevel: s.BatteryLevel,
            SignalStrength: s.SignalStrength,
            InstallationDate: s.InstallationDate,
            NextCalibrationDate: s.NextCalibrationDate,
            ReadingCount: s.Readings.Count(),
            Created: s.Created
        ));
    }

    public static IQueryable<SensorSummaryDto> ToSensorSummaryDto(this IQueryable<Sensor> query)
    {
        return query.Select(s => new SensorSummaryDto(
            Id: s.Id,
            Name: s.Name,
            SensorTypeName: s.SensorType.ToDisplayName(),
            FieldName: s.Field != null ? s.Field.Name : null,
            DeviceName: s.Device != null ? s.Device.Name : null,
            StatusName: s.Status.ToDisplayName(),
            BatteryLevel: s.BatteryLevel,
            SignalStrength: s.SignalStrength,
            LastReadingTime: s.LastReadingTime
        ));
    }

    public static IQueryable<Sensor> BuildSearchQuery(this IQueryable<Sensor> query, SearchSensorsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(s => EF.Functions.ILike(s.Name, term)
            || (s.Model != null && EF.Functions.ILike(s.Model, term))
            || (s.SerialNumber != null && EF.Functions.ILike(s.SerialNumber, term))
            );
        }
        if (!string.IsNullOrEmpty(search.FieldId))
        {
            query = query.Where(s => s.FieldId == search.FieldId);
        }
        if (!string.IsNullOrEmpty(search.DeviceId))
        {
            query = query.Where(s => s.DeviceId == search.DeviceId);
        }
        if (search.SensorType.HasValue)
        {
            query = query.Where(s => s.SensorType == search.SensorType.Value);
        }
        if (search.Status.HasValue)
        {
            query = query.Where(s => s.Status == search.Status.Value);
        }
        if (search.StartInstallationDate.HasValue)
        {
            query = query.Where(s => s.InstallationDate >= search.StartInstallationDate.Value);
        }
        if (search.EndInstallationDate.HasValue)
        {
            query = query.Where(s => s.InstallationDate <= search.EndInstallationDate.Value);
        }
        return query;
    }
    /// <summary>
    /// Applies sorting to the Sensor query based on the specified sortBy field and order (ascending or descending).
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">name, sensortype, status</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Sensor> ApplySorting(this IQueryable<Sensor> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created)
                .ThenBy(a => a.Name);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "sensortype" => ascending ? query.OrderBy(a => a.SensorType) : query.OrderByDescending(a => a.SensorType),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }
}