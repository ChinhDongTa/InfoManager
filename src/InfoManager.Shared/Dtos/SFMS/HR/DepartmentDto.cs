namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== Department ========================
public record DepartmentDto(
    string Id,
    string Name,
    string? Description,
    string? ParentId,
    string? ParentName,
    string FarmId,
    string? FarmName,
    DateTimeOffset Created
);