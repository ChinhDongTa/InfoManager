namespace InfoManager.Shared.Dtos.SFMS.HR;

public record EmployeeContractSummaryDto(
    string Id,
    string? EmployeeName,
    string ContractNumber,
    string ContractType,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    bool IsActive
);