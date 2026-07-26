namespace InfoManager.Application.Features.Transactions.Commands;

public record UpdateTransactionCommand : IRequest<Result>
{
    public required string Id { get; set; }
    public decimal? Amount { get; init; }
    public string? CategoryId { get; init; }
    public string? Description { get; init; }
    public PaymentMethod? PaymentMethod { get; init; }
    public DateTimeOffset? TransactionDate { get; init; }
    public TransactionType? TransactionType { get; init; }
}
public class UpdateTransactionCommandHandler : BaseUpdateCommandHandler<UpdateTransactionCommand, Transaction>
{
    public UpdateTransactionCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateTransactionCommand> validator,
                                           ILogger<UpdateTransactionCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<Transaction?> GetEntityAsync(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        return await Context.Transactions.FindAsync([request.Id], cancellationToken);
    }
    protected override void UpdateEntityProperties(Transaction entity, UpdateTransactionCommand request)
    {
        if (request.Amount.HasValue && request.Amount.Value != entity.Amount)
            entity.Amount = request.Amount.Value;

        if (request.CategoryId.IsDifferentFrom(entity.CategoryId))
            entity.CategoryId = request.CategoryId;

        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;

        if (request.PaymentMethod.HasValueAndIsDifferentFrom(entity.PaymentMethod))
            entity.PaymentMethod = request.PaymentMethod!.Value;

        if (request.TransactionDate.IsDifferentFrom(entity.TransactionDate))
            entity.TransactionDate = request.TransactionDate;

        if (request.TransactionType.HasValueAndIsDifferentFrom(entity.TransactionType))
            entity.TransactionType = request.TransactionType!.Value;
    }
}
public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
    }
}