using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Monitoring;

namespace InfoManager.ModelClient.SFMS.Monitoring;

public class UpdateEnvironmentalReadingModel
{
    /// <summary>ID lần đo. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Chất lượng dữ liệu.</summary>
    public DataQuality? Quality { get; set; }

    /// <summary>Có trong khoảng kỳ vọng.</summary>
    public bool? IsWithinRange { get; set; }

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public UpdateEnvironmentalReadingModel(string id, EnvironmentalReadingDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        Quality = dto.Quality;
        IsWithinRange = dto.IsWithinRange;
        Notes = dto.Notes;
    }

    public UpdateEnvironmentalReadingRequest CreateRequest()
    {
        return new UpdateEnvironmentalReadingRequest
        (
            Id: this.Id,
            Quality: this.Quality,
            IsWithinRange: this.IsWithinRange,
            Notes: this.Notes
        );
    }

    public bool HasChanges(UpdateEnvironmentalReadingModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
