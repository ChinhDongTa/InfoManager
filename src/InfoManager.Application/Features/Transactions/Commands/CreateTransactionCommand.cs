namespace InfoManager.Application.Features.Transactions.Commands;
public record CreateTransactionCommand : IRequest<Result<string>>
{
    public decimal Amount { get; init; }
    public string? CategoryId    {        get; init;    }
    public string? Description { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public DateTime? TransactionDate { get; init; }
    public TransactionType TransactionType { get; init; }
}
public class CreateTransactionCommandHandler : BaseCreateCommandHandler<CreateTransactionCommand, Transaction>
{
    public CreateTransactionCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateTransactionCommand> validator,
                                            ILogger<CreateTransactionCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override Transaction CreateEntity(CreateTransactionCommand request)
    {
        return new Transaction
        {
            Amount = request.Amount,
            CategoryId = request.CategoryId,
            Description = request.Description?.Trim(),
            PaymentMethod = request.PaymentMethod,
            TransactionDate = request.TransactionDate,
            TransactionType = request.TransactionType
        };
    }
    protected override async Task AddEntityAsync(Transaction entity, CancellationToken cancellationToken)
    {
        await Context.Transactions.AddAsync(entity, cancellationToken);
    }
}
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền giao dịch", 0));
       
    }
}