namespace InfoManager.Shared.Dtos.FamilyEventOccurrences;

// ========== Create ==========
public record CreateFamilyEventOccurrenceRequest(
    string FamilyEventId,
    DateOnly? OccurrenceDate,
    string? Location,
    string? Notes,
    decimal? Cost = null
);

// ========== Update ==========
public record UpdateFamilyEventOccurrenceRequest(
    string Id,
    DateOnly? OccurrenceDate,
    string? Location,
    string? Notes,
    decimal? Cost
);

// ========== Summary (dùng cho danh sách) ==========
public record FamilyEventOccurrenceSummaryDto(
    string Id,
    string? EventTitle,                // lấy từ FamilyEvent.Title
    string? MemberName,                // lấy từ FamilyMember.FullName
    DateOnly? OccurrenceDate,
    string? Location,
    decimal? Cost
);

// ========== Detail (nếu cần xem chi tiết) ==========
public record FamilyEventOccurrenceDto(
    string Id,
    string FamilyEventId,
    string? EventTitle,
    string? MemberName,
    DateOnly? OccurrenceDate,
    string? Location,
    string? Notes,
    decimal? Cost
);