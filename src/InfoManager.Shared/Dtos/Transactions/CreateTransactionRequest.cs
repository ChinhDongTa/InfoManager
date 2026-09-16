namespace InfoManager.Shared.Dtos.Transactions;

public record CreateTransactionRequest
{
    public decimal Amount { get; init; }
    public string? CategoryId { get; init; }
    public string? Description { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public DateTimeOffset? TransactionDate { get; init; }
    public TransactionType TransactionType { get; init; }
}