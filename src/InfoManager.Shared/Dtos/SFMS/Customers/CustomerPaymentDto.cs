namespace InfoManager.Shared.Dtos.SFMS.Customers;

// ======================== CustomerPayment ========================

public record CustomerPaymentDto(
    string Id,
    string CustomerId,
    string? CustomerName,
    string FarmId,
    string? FarmName,
    string? SaleId,
    string? FarmRevenueId,
    decimal Amount,
    DateTimeOffset PaymentDate,
    string? PaymentMethod,
    string PaymentStatusName,
    string? ReferenceNumber,
    string? Notes,
    DateTimeOffset Created
);

public record CustomerPaymentSummaryDto(
    string Id,
    string? CustomerName,
    decimal Amount,
    DateTimeOffset PaymentDate,
    string? PaymentMethod,
    string PaymentStatusName
);
public record SearchCustomerPaymentRequest(string? Term,
                                           DateTimeOffset? StartPaymentDate,
                                           DateTimeOffset? EndPaymentDate,
                                           int PageNumber,
                                           int PageSize);
public record CreateCustomerPaymentRequest(
    string CustomerId,
    string FarmId,
    decimal Amount,
    DateTimeOffset PaymentDate ,
    string? SaleId,
    string? FarmRevenueId,
    string? PaymentMethod,
    PaymentStatus PaymentStatus,
    string? ReferenceNumber,
    string? Notes
);

public record UpdateCustomerPaymentRequest(
    string Id,
    decimal? Amount,
    DateTimeOffset? PaymentDate,
    string? SaleId,
    string? FarmRevenueId,
    string? PaymentMethod,
    PaymentStatus? PaymentStatus,
    string? ReferenceNumber,
    string? Notes
);

