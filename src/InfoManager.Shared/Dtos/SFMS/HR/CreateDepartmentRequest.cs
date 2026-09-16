namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateDepartmentRequest(
    string Name,
    string? Description,
    string? ParentId,
    string FarmId
);