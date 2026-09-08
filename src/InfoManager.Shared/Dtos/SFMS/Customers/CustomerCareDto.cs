namespace InfoManager.Shared.Dtos.SFMS.Customers;

// ======================== CustomerCare ========================

public record CustomerCareDto(
    string Id,
    string CustomerId,
    string? CustomerName,
    string FarmId,
    string? FarmName,
    CustomerCareType CareType,
    string CareTypeName,
    string Subject,
    string? Content,
    DateTimeOffset CareDate,
    DateTimeOffset? NextFollowUpDate,
    CustomerCareStatus Status,
    string StatusName,
    string? HandledBy,
    string? Result,
    DateTimeOffset Created
);

public record CustomerCareSummaryDto(
    string Id,
    string? CustomerName,
    string CareTypeName,
    string Subject,
    DateTimeOffset CareDate,
    DateTimeOffset? NextFollowUpDate,
    string StatusName
);

public record SearchCustomerCareRequest(string? Term,
                                       DateTimeOffset? StartCareDate,
                                       DateTimeOffset? EndCareDate,
                                       DateTimeOffset? StartNextFollowUpDate,
                                       DateTimeOffset? EndNextFollowUpDate,
                                       int PageNumber,
                                       int PageSize);

public record CreateCustomerCareRequest(
    string CustomerId,
    string FarmId,
    string Subject,
    CustomerCareType CareType ,
    string? Content ,
    DateTimeOffset CareDate ,
    DateTimeOffset? NextFollowUpDate ,
    CustomerCareStatus Status ,
    string? HandledBy ,
    string? Result 
);

public record UpdateCustomerCareRequest(
    string Id,
    CustomerCareType? CareType ,
    string? Subject ,
    string? Content ,
    DateTimeOffset? CareDate ,
    DateTimeOffset? NextFollowUpDate ,
    CustomerCareStatus? Status ,
    string? HandledBy ,
    string? Result 
);