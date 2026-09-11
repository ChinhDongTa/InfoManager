using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Operations;

namespace InfoManager.ModelClient.SFMS.Operations;

public class CreateMaintenanceModel
{
    /// <summary>
    /// ID bản ghi bảo trì
    /// </summary>
    [Required]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// ID thiết bị liên quan
    /// </summary>
    [Required]
    public string EquipmentId { get; set; } = string.Empty;

    /// <summary>
    /// Ngày thực hiện bảo trì
    /// </summary>
    [Required]
    public DateTimeOffset MaintenanceDate { get; set; }

    /// <summary>
    /// Loại bảo trì
    /// </summary>
    [Required]
    public MaintenanceType MaintenanceType { get; set; }

    /// <summary>
    /// Mô tả công việc bảo trì
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Phụ tùng đã thay/sử dụng
    /// </summary>
    public string? PartReplaced { get; set; }

    /// <summary>
    /// Chi phí bảo trì
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Nhà cung cấp dịch vụ / kỹ thuật viên
    /// </summary>
    public string? ServiceProvider { get; set; }

    /// <summary>
    /// Số giờ vận hành tại thời điểm bảo trì
    /// </summary>
    public decimal? OperatingHours { get; set; }

    /// <summary>
    /// Trạng thái bảo trì
    /// </summary>
    public MaintenanceStatus? Status { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// URL tài liệu / hóa đơn
    /// </summary>
    public string? DocumentUrl { get; set; }

    public CreateMaintenanceRequest CreateRequest()
    {
        return new CreateMaintenanceRequest
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
}