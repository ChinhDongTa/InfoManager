using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class UpdatePesticideModel
{
    /// <summary>ID thuốc BVTV. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên thuốc BVTV.</summary>
    public string? Name { get; set; }

    /// <summary>Hoạt chất.</summary>
    public string? ActiveIngredient { get; set; }

    /// <summary>Loại thuốc.</summary>
    public PesticideType? PesticideType { get; set; }

    /// <summary>Mức độc tính.</summary>
    public ToxicityLevel? ToxicityLevel { get; set; }

    /// <summary>Thời gian cách ly trước thu hoạch (ngày).</summary>
    [Range(0, int.MaxValue)]
    public int? PreHarvestIntervalDays { get; set; }

    /// <summary>Đơn vị.</summary>
    public string? Unit { get; set; }

    /// <summary>Nhà sản xuất.</summary>
    public string? Manufacturer { get; set; }

    /// <summary>Số đăng ký.</summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>Đang hoạt động.</summary>
    public bool? IsActive { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdatePesticideModel(string id, PesticideDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        Name = dto.Name;
        ActiveIngredient = dto.ActiveIngredient;
        PesticideType = dto.PesticideType;
        ToxicityLevel = dto.ToxicityLevel;
        PreHarvestIntervalDays = dto.PreHarvestIntervalDays;
        Unit = dto.Unit;
        Manufacturer = dto.Manufacturer;
        RegistrationNumber = dto.RegistrationNumber;
        IsActive = dto.IsActive;
        Notes = dto.Notes;
    }

    public UpdatePesticideRequest CreateRequest()
    {
        return new UpdatePesticideRequest
        (
            Id: this.Id,
            Name: this.Name,
            ActiveIngredient: this.ActiveIngredient,
            PesticideType: this.PesticideType,
            ToxicityLevel: this.ToxicityLevel,
            PreHarvestIntervalDays: this.PreHarvestIntervalDays,
            Unit: this.Unit,
            Manufacturer: this.Manufacturer,
            RegistrationNumber: this.RegistrationNumber,
            IsActive: this.IsActive,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdatePesticideModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}