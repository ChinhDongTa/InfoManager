namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateDepartmentRequest(
    string Id,
    string? Name = null,
    string? Description = null,
    string? ParentId = null
);
