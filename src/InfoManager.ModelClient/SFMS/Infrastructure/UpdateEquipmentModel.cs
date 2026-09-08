using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class UpdateEquipmentModel
{
    /// <summary>ID thiết bị. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thiết bị.</summary>
    public string? Name { get; set; }

    /// <summary>Loại thiết bị.</summary>
    public EquipmentType? EquipmentType { get; set; }

    /// <summary>ID nông trại liên kết.</summary>
    public string? FarmId { get; set; }

    /// <summary>Tên nhà sản xuất.</summary>
    public string? Manufacturer { get; set; }

    /// <summary>Số model.</summary>
    public string? Model { get; set; }

    /// <summary>Số serial.</summary>
    public string? SerialNumber { get; set; }

    /// <summary>Công suất (HP).</summary>
    public decimal? PowerRating { get; set; }

    /// <summary>Thông số kỹ thuật / dung tích.</summary>
    public string? Specifications { get; set; }

    /// <summary>Ngày mua.</summary>
    public DateTimeOffset? PurchaseDate { get; set; }

    /// <summary>Giá mua.</summary>
    public decimal? PurchaseCost { get; set; }

    /// <summary>Giá trị hiện tại.</summary>
    public decimal? CurrentValue { get; set; }

    /// <summary>Trạng thái thiết bị.</summary>
    public EquipmentStatus? Status { get; set; }

    /// <summary>Số giờ vận hành.</summary>
    public decimal? OperatingHours { get; set; }

    /// <summary>Ngày bảo trì gần nhất.</summary>
    public DateTimeOffset? LastMaintenanceDate { get; set; }

    /// <summary>Ngày bảo trì kế tiếp.</summary>
    public DateTimeOffset? NextMaintenanceDate { get; set; }

    /// <summary>Vị trí lưu trữ.</summary>
    public string? StorageLocation { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateEquipmentModel(string id, EquipmentDto dto)
    {
        Id = id;
        Name = dto.Name;
        EquipmentType = dto.EquipmentType;
        FarmId = dto.FarmId;
        Manufacturer = dto.Manufacturer;
        Model = dto.Model;
        SerialNumber = dto.SerialNumber;
        PowerRating = dto.PowerRating;
        Specifications = dto.Specifications;
        PurchaseDate = dto.PurchaseDate;
        PurchaseCost = dto.PurchaseCost;
        CurrentValue = dto.CurrentValue;
        Status = dto.Status;
        OperatingHours = dto.OperatingHours;
        LastMaintenanceDate = dto.LastMaintenanceDate;
        NextMaintenanceDate = dto.NextMaintenanceDate;
        StorageLocation = dto.StorageLocation;
        Notes = dto.Notes;
    }

    public UpdateEquipmentRequest CreateRequest()
    {
        return new UpdateEquipmentRequest
        (
            Id: this.Id,
            Name: this.Name,
            EquipmentType: this.EquipmentType,
            FarmId: this.FarmId,
            Manufacturer: this.Manufacturer,
            Model: this.Model,
            SerialNumber: this.SerialNumber,
            PowerRating: this.PowerRating,
            Specifications: this.Specifications,
            PurchaseDate: this.PurchaseDate,
            PurchaseCost: this.PurchaseCost,
            CurrentValue: this.CurrentValue,
            Status: this.Status,
            OperatingHours: this.OperatingHours,
            LastMaintenanceDate: this.LastMaintenanceDate,
            NextMaintenanceDate: this.NextMaintenanceDate,
            StorageLocation: this.StorageLocation,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateEquipmentModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}