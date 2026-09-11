using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Weather;

public class UpdatePesticidePlanModel
{
    /// <summary>ID kế hoạch sử dụng thuốc. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID thuốc BVTV.</summary>
    public string? PesticideId { get; set; }

    /// <summary>Tên kế hoạch.</summary>
    public string? PlanName { get; set; }

    /// <summary>Đối tượng phòng trừ.</summary>
    public string? Target { get; set; }

    /// <summary>Ngày dự kiến phun.</summary>
    public DateTimeOffset? PlannedDate { get; set; }

    /// <summary>Khối lượng dự kiến.</summary>
    public decimal? PlannedQuantity { get; set; }

    /// <summary>Đơn vị.</summary>
    public string? Unit { get; set; }

    /// <summary>Phương pháp phun.</summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>Trạng thái.</summary>
    public PesticidePlanStatus? Status { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdatePesticidePlanModel(string id, PesticidePlanDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        PesticideId = dto.PesticideId;
        PlanName = dto.PlanName;
        Target = dto.Target;
        PlannedDate = dto.PlannedDate;
        PlannedQuantity = dto.PlannedQuantity;
        Unit = dto.Unit;
        ApplicationMethod = dto.ApplicationMethod;
        Status = dto.Status;
        Notes = dto.Notes;
    }

    public UpdatePesticidePlanRequest CreateRequest()
    {
        return new UpdatePesticidePlanRequest
        (
            Id: this.Id,
            PesticideId: this.PesticideId,
            PlanName: this.PlanName,
            Target: this.Target,
            PlannedDate: this.PlannedDate,
            PlannedQuantity: this.PlannedQuantity,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            Status: this.Status,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdatePesticidePlanModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
