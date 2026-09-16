using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.ModelClient.SFMS.Resources;

public class UpdateFertilizerModel
{
    /// <summary>ID phân bón. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Tên phân bón.</summary>
    public string? Name { get; set; }

    /// <summary>Loại phân bón.</summary>
    public FertilizerType? FertilizerType { get; set; }

    /// <summary>Tỷ lệ đạm (%).</summary>
    [Range(0, 100)]
    public decimal? NitrogenPercent { get; set; }

    /// <summary>Tỷ lệ lân (%).</summary>
    [Range(0, 100)]
    public decimal? PhosphorusPercent { get; set; }

    /// <summary>Tỷ lệ kali (%).</summary>
    [Range(0, 100)]
    public decimal? PotassiumPercent { get; set; }

    /// <summary>Đơn vị.</summary>
    public string? Unit { get; set; }

    /// <summary>Nhà sản xuất.</summary>
    public string? Manufacturer { get; set; }

    /// <summary>Đang hoạt động.</summary>
    public bool? IsActive { get; set; }

    /// <summary>Ghi chú.</summary>
    public string? Notes { get; set; }

    public UpdateFertilizerModel(string id, FertilizerDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        Name = dto.Name;
        FertilizerType = dto.FertilizerType;
        NitrogenPercent = dto.NitrogenPercent;
        PhosphorusPercent = dto.PhosphorusPercent;
        PotassiumPercent = dto.PotassiumPercent;
        Unit = dto.Unit;
        Manufacturer = dto.Manufacturer;
        IsActive = dto.IsActive;
        Notes = dto.Notes;
    }

    public UpdateFertilizerRequest CreateRequest()
    {
        return new UpdateFertilizerRequest
        (
            Id: this.Id,
            Name: this.Name,
            FertilizerType: this.FertilizerType,
            NitrogenPercent: this.NitrogenPercent,
            PhosphorusPercent: this.PhosphorusPercent,
            PotassiumPercent: this.PotassiumPercent,
            Unit: this.Unit,
            Manufacturer: this.Manufacturer,
            IsActive: this.IsActive,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateFertilizerModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}