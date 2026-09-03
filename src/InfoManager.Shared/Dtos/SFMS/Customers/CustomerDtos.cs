
namespace InfoManager.Shared.Dtos.SFMS.Customers;

// ======================== Customer ========================

public record CustomerDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CustomerCode,
    string Name,
    string CustomerTypeName,
    string? Phone,
    string? Email,
    string? Address,
    string? TaxCode,
    string? ContactPerson,
    decimal? CreditLimit,
    string StatusName,
    string? Notes,
    DateTimeOffset Created
);

public record CustomerSummaryDto(
    string Id,
    string? CustomerCode,
    string Name,
    string CustomerTypeName,
    string? Phone,
    string StatusName
);

public record SearchCustomerRequest(
    string? Term,
    CustomerType? CustomerType,
    decimal? MinCreditLimit,
    decimal? MaxCreditLimit,
    CustomerStatus? Status,
    int PageNumber,
    int PageSize
    );

public record CreateCustomerRequest(
    string FarmId,
    string Name,
    string? CustomerCode,
    CustomerType CustomerType,
    string? Phone,
    string? Email,
    string? Address,
    string? TaxCode,
    string? ContactPerson,
    decimal? CreditLimit,
    CustomerStatus Status,
    string? Notes
);

public record UpdateCustomerRequest(
    string Id,
    string? FarmId,
    string? CustomerCode,
    string? Name,
    CustomerType? CustomerType,
    string? Phone,
    string? Email,
    string? Address,
    string? TaxCode,
    string? ContactPerson,
    decimal? CreditLimit,
    CustomerStatus? Status,
    string? Notes
);