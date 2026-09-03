namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateWorkShiftRequest(
    string Id,
    string? Name = null,
    TimeOnly? StartTime = null,
    TimeOnly? EndTime = null
);
