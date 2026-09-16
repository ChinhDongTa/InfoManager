using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.ModelClient.Families;

public class UpdateFamilyEventOccurrenceModel
{
    [Required]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Ngày tổ chức thực tế năm đó (có thể lệch vài ngày so với OriginalDate)
    /// </summary>
    public DateOnly? OccurrenceDate { get; set; }

    [MaxLength(200)]
    public string? Location { get; set; }

    [MaxLength(2000)]
    public string? Notes { get; set; } // "Năm nay tổ chức tại nhà chú Ba, có 30 người..."

    /// <summary>
    /// Chi phí tổ chức sự kiện (nếu có)
    /// </summary>
    public decimal? Cost { get; set; }

    public UpdateFamilyEventOccurrenceModel(FamilyEventOccurrenceDto dto)
    {
        Id = dto.Id;
        OccurrenceDate = dto.OccurrenceDate;
        Location = dto.Location;
        Notes = dto.Notes;
        Cost = dto.Cost;
    }

    public UpdateFamilyEventOccurrenceRequest CreateRequest() => new(
            Id: this.Id,
            OccurrenceDate: this.OccurrenceDate,
            Location: this.Location,
            Notes: this.Notes,
            Cost: this.Cost
        );

    public bool HasChanges(UpdateFamilyEventOccurrenceModel originalModel) => ClientUpdateHelper.HasChanges(this, originalModel);
}