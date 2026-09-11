using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class UpdatePesticideApplicationModel
{
    /// <summary>ID lần sử dụng thuốc. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID nông trại.</summary>
    public string? FarmId { get; set; }

    /// <summary>ID thuốc BVTV.</summary>
    public string? PesticideId { get; set; }

    /// <summary>Ngày phun / xử lý.</summary>
    public DateTimeOffset? AppliedDate { get; set; }

    /// <summary>Khối lượng đã dùng.</summary>
    public decimal AppliedQuantity { get; set; }

    /// <summary>ID thửa đất.</summary>
    public string? FieldId { get; set; }

    /// <summary>ID lần trồng.</summary>
    public string? CropPlantingId { get; set; }

    /// <summary>ID kế hoạch sử dụng thuốc.</summary>
    public string? PesticidePlanId { get; set; }

    /// <summary>Đơn vị.</summary>
    public string Unit { get; set; } = "lít";

    /// <summary>Phương pháp phun / xử lý.</summary>
    public string? ApplicationMethod { get; set; }

    /// <summary>Người thực hiện.</summary>
    public string? AppliedBy { get; set; }

    /// <summary>Chi phí.</summary>
    public decimal? Cost { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdatePesticideApplicationModel(string id, PesticideApplicationDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        FarmId = dto.FarmId;
        PesticideId = dto.PesticideId;
        AppliedDate = dto.AppliedDate;
        AppliedQuantity = dto.AppliedQuantity;
        FieldId = dto.FieldId;
        CropPlantingId = dto.CropPlantingId;
        PesticidePlanId = dto.PesticidePlanId;
        Unit = dto.Unit ?? "lít";
        ApplicationMethod = dto.ApplicationMethod;
        AppliedBy = dto.AppliedBy;
        Cost = dto.Cost;
        Notes = dto.Notes;
    }

    public UpdatePesticideApplicationRequest CreateRequest()
    {
        return new UpdatePesticideApplicationRequest
        (
            Id: this.Id,
            FarmId: this.FarmId,
            PesticideId: this.PesticideId,
            AppliedDate: this.AppliedDate,
            AppliedQuantity: this.AppliedQuantity,
            FieldId: this.FieldId,
            CropPlantingId: this.CropPlantingId,
            PesticidePlanId: this.PesticidePlanId,
            Unit: this.Unit,
            ApplicationMethod: this.ApplicationMethod,
            AppliedBy: this.AppliedBy,
            Cost: this.Cost,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdatePesticideApplicationModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
