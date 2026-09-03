using InfoManager.Enum.SFMS;
namespace InfoManager.Shared.Dtos.SFMS.HR;

public record CreateEmployeeContractRequest(
    string HREmployeeId,
    string ContractNumber,
    string ContractType,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate ,
    SalaryType SalaryType ,
    decimal BaseSalary ,
    bool IsActive 
);
