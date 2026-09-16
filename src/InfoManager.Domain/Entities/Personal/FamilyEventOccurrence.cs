namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Thông tin về một lần tổ chức cụ thể của sự kiện gia đình
/// </summary>
public class FamilyEventOccurrence : BaseAuditableEntity
{
    public string FamilyEventId { get; set; }
    public FamilyEvent? FamilyEvent { get; set; }

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

    // Có thể thêm: Photos, Guests, Cost... sau này
}