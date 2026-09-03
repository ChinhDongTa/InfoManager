namespace InfoManager.Shared.Dtos.SFMS.HR;

public record WorkShiftSummaryDto(
    string Id,
    string Name,
    TimeOnly StartTime,
    TimeOnly EndTime
);