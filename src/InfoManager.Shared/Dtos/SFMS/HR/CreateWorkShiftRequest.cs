namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateWorkShiftRequest(
    string Name,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string FarmId
);