namespace InfoManager.Shared.Dtos.SFMS.HR;

public record UpdateEmployeeContractRequest(
    string Id,
    string? ContractNumber = null,
    string? ContractType = null,
    DateTimeOffset? StartDate = null,
    DateTimeOffset? EndDate = null,
    SalaryType? SalaryType = null,
    decimal? BaseSalary = null,
    bool? IsActive = null
);