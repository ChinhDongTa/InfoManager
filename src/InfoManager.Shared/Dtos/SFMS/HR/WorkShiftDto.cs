namespace InfoManager.Shared.Dtos.SFMS.HR;

// ======================== WorkShift ========================
public record WorkShiftDto(
    string Id,
    string Name,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string FarmId,
    string? FarmName,
    DateTimeOffset Created
);