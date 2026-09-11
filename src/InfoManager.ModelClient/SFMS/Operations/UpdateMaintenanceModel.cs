using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Operations;

namespace InfoManager.ModelClient.SFMS.Operations;

public class UpdateMaintenanceModel
{
    /// <summary>ID bản ghi bảo trì. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID thiết bị liên quan.</summary>
    public string? EquipmentId { get; set; }

    /// <summary>Ngày thực hiện bảo trì.</summary>
    public DateTimeOffset? MaintenanceDate { get; set; }

    /// <summary>Loại bảo trì.</summary>
    public MaintenanceType? MaintenanceType { get; set; }

    /// <summary>Mô tả công việc bảo trì.</summary>
    public string? Description { get; set; }

    /// <summary>Phụ tùng đã thay/sử dụng.</summary>
    public string? PartReplaced { get; set; }

    /// <summary>Chi phí bảo trì.</summary>
    public decimal? Cost { get; set; }

    /// <summary>Nhà cung cấp dịch vụ / kỹ thuật viên.</summary>
    public string? ServiceProvider { get; set; }

    /// <summary>Số giờ vận hành tại thời điểm bảo trì.</summary>
    public decimal? OperatingHours { get; set; }

    /// <summary>Trạng thái bảo trì.</summary>
    public MaintenanceStatus? Status { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    /// <summary>URL tài liệu / hóa đơn.</summary>
    public string? DocumentUrl { get; set; }

    public UpdateMaintenanceModel(string id, MaintenanceDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        EquipmentId = dto.EquipmentId;
        MaintenanceDate = dto.MaintenanceDate;
        MaintenanceType = dto.MaintenanceType;
        Description = dto.Description;
        PartReplaced = dto.PartReplaced;
        Cost = dto.Cost;
        ServiceProvider = dto.ServiceProvider;
        OperatingHours = dto.OperatingHours;
        Status = dto.Status;
        Notes = dto.Notes;
        DocumentUrl = dto.DocumentUrl;
    }

    public UpdateMaintenanceRequest CreateRequest()
    {
        return new UpdateMaintenanceRequest
        (
            Id: this.Id,
            EquipmentId: this.EquipmentId,
            MaintenanceDate: this.MaintenanceDate,
            MaintenanceType: this.MaintenanceType,
            Description: this.Description,
            PartReplaced: this.PartReplaced,
            Cost: this.Cost,
            ServiceProvider: this.ServiceProvider,
            OperatingHours: this.OperatingHours,
            Status: this.Status,
            Notes: this.Notes,
            DocumentUrl: this.DocumentUrl
        );
    }

    public bool HasChanges(UpdateMaintenanceModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
