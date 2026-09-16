using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của Equipment.
/// </summary>
public static class EquipmentMappings
{
    public static CreateEquipmentCommand ToCreateCommand(CreateEquipmentRequest request)
        => new()
        {
            Name = request.Name,
            EquipmentType = request.EquipmentType,
            FarmId = request.FarmId,
            Manufacturer = request.Manufacturer,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            PowerRating = request.PowerRating,
            Specifications = request.Specifications,
            PurchaseDate = request.PurchaseDate,
            PurchaseCost = request.PurchaseCost,
            CurrentValue = request.CurrentValue,
            Status = request.Status,
            OperatingHours = request.OperatingHours,
            LastMaintenanceDate = request.LastMaintenanceDate,
            NextMaintenanceDate = request.NextMaintenanceDate,
            StorageLocation = request.StorageLocation,
            Notes = request.Notes
        };

    public static UpdateEquipmentCommand ToUpdateCommand(UpdateEquipmentRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            EquipmentType = request.EquipmentType,
            FarmId = request.FarmId,
            Manufacturer = request.Manufacturer,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            PowerRating = request.PowerRating,
            Specifications = request.Specifications,
            PurchaseDate = request.PurchaseDate,
            PurchaseCost = request.PurchaseCost,
            CurrentValue = request.CurrentValue,
            Status = request.Status,
            OperatingHours = request.OperatingHours,
            LastMaintenanceDate = request.LastMaintenanceDate,
            NextMaintenanceDate = request.NextMaintenanceDate,
            StorageLocation = request.StorageLocation,
            Notes = request.Notes
        };

    public static SearchEquipmentsQuery ToSearchQuery(SearchEquipmentsRequest request)
        => new(Term: request.Term,
               EquipmentType: request.EquipmentType,
               FarmId: request.FarmId,
               Status: request.Status,
               LastMaintenanceDateFrom: request.LastMaintenanceDateFrom,
               LastMaintenanceDateTo: request.LastMaintenanceDateTo,
               NextMaintenanceDateFrom: request.NextMaintenanceDateFrom,
               NextMaintenanceDateTo: request.NextMaintenanceDateFrom,
               PageNumeber: request.PageNumber,
               PageSize: request.PageSize);
}