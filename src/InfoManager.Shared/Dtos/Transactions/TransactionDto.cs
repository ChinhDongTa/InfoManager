namespace InfoManager.Shared.Dtos.Transactions;

public record TransactionDto(string Id,
                             decimal Amount,
                             string? CategoryName,
                             string? Description,
                             DateTime? TransactionDate,
                             string TransactionTypeName,
                             string? CategoryId,
                             string? PaymentMethodName,
                             PaymentMethod PaymentMethod,
                             TransactionType TransactionType);
public record TransactionSummaryDto(string Id,
                             decimal Amount,
                             string? CategoryName,
                             DateTime? TransactionDate,
                             string? Description);
